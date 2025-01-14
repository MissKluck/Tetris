namespace Tetris
{
    public class IBlock : Block
    {
        //store the tile positions for the four rotation states
        private readonly Position[][] tiles = new Position[][]
        {
            //State 0
            new Position[] { new(1,0), new(1,1), new(1,2), new(1,3)},
            //State 1
            new Position[] { new(0,2), new(1,2), new(2,2), new(3,2)},
            //State 2
            new Position[] { new(2,0), new(2,1), new(2,2), new(2,3)},
            //State 3
            new Position[] { new(0,1), new(1,1), new(2,1), new(3,1)}
        };
        //fill out the required properties for the I-Block
        //The ID should be 1
        public override int Id => 1;
        //the start offset should be -1 3 - this will make the block spawn in the middle of the tow row
        protected override Position StartOffset => new Position(-1, 3);

        //for the tiles property we return the tiles array above
        protected override Position[][] Tiles => tiles;


    }
}