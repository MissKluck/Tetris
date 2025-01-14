using System.Collections.Generic;

namespace Tetris
{
    public abstract class Block
    {
        //we will create a subclass for each specific block
        //each block will have a two dimensional array which contains the tile position in the four rotation states
        protected abstract Position[][] Tiles { get; }
        //a start offset which decides where the block spawns in the grid
        protected abstract Position StartOffset { get; }
        //an integer id which we need to distinguish the blocks
        public abstract int Id { get; }
        //we will also store the current rotation state and the current offset
        private int rotationState;
        private Position offset;

        //create a constructor and set the offset equl to the start offset
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        //create a method which returns the grid positions occupied by the block factoring in the current rotation and offset
        //the method loops over the tile positions in the current rotation state and adds the row offset and column offset
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        //the next method rotates the block 90 degrees clockwise
        //we do tht by incrementing the current rotation stte, wrapping around to zero if it's in the final state
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        //add a method to rotate counter-clockwise
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        //add a move method which moves the block a given number of rows and columns
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        //add reset method which resets the rotation and position
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}