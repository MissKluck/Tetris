namespace Tetris
{
    public class TBlock : Block
    {
        //store the tile positions for the four rotation states
        private readonly Position[][] tiles = new Position[][]
        {
            //State 0
            new Position[] { new(0,1), new(1,0), new(1,1), new(1,2)},
            //State 1
            new Position[] { new(0,1), new(1,1), new(1,2), new(2,1)},
            //State 2
            new Position[] { new(1,0), new(1,1), new(1,2), new(2,1)},
            //State 3
            new Position[] { new(0,1), new(1,0), new(1,1), new(2,1)}
        };
        //fill out the required properties for the T-Block
        //The ID should be 6
        public override int Id => 6;
        //the start offset should be 0 3
        protected override Position StartOffset => new Position(0, 3);

        //for the tiles property we return the tiles array above
        protected override Position[][] Tiles => tiles;
    }
}