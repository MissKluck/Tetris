namespace Tetris
{
    public class GameGrid
    {
        //Creating the game grid
        private readonly int[,] grid;
        //Adding the properties for the number of rows and columns
        public int Rows { get; }
        public int Columns { get; }
        //Creating an indexer to provide easy access to the array
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }


    }
}