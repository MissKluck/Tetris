namespace Tetris
{
    //This will be a little different from the rest of the blocks as the O block looks the same no matter how it is rotated, therefore it required only one rotation state
    public class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0,0), new(0,1), new(1,0), new(1,1)}
        };

        public override int Id => 4;
        protected override Position StartOffset => new Position(0, 4);
        protected override Position[][] Tiles => tiles;
    }
}