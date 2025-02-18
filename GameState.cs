namespace Tetris
{
    //this class will handle the interactions between the parts we've added so far
    public class GameState
    {
        //add a property with a backing field for the current block
        private Block currentBlock;

        //when we update the current block the reset method is called to set the correct start position and rotation
        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        //add properties for the game grid, the block queue and a game over boolean
        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }

        //in the constructor we initilize the game grid with 22 row and 10 columns. we aalso initialise the block queue and use it to get a random block for the current block property 
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        //add a methos that checks if the current block is in a legal position or not - the method loops over the tile positions of the current block and if aany of them are outside the grid or overlapping another tile then we return false, otherwise if we get through the entire loop, we return true
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }

            return true;
        }

        //add a method that rotates the current block clockwise, but only if it's possible to do from where it is
        //the way we do it is simply to rotate the block and if it ends up in an illegal position then we rotate it back
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        //add a method that rotates the current block counter clockwise and works in the same way as the one above
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateBlockCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        //add methods for moving the current block left and right - our strategy will be the same as above; if we try to move it and it ends up in an illegal/impossible position, then we move it back
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        //add a method to check if the game is over
        //the way it does that is by checking the hidden rows at the top, and if either of those is not empty, meaning if it is filled, then the game is lost
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        //a method that will be called when the current block cannot be moved down
        //first it looks over the tile positions of the current block and sets those positions in the gamegrid equal to the blocks ID
        //then we clear any potentially full rows and check if the game is over
        //if the game is over, we set the gameover property to true
        //if the game isn't over, we update the current block
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        //add a move down method
    }
}