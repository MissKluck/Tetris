namespace Tetris
{
    public class Position
    {
        //store the row and column
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