namespace Tetris
{
    public class Position
    {
        //This class will determine the position of the block being moved on the grid
        //store a row and a column
        public int Row { get; set; }
        public int Column { get; set; }
        //simple constructor
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}