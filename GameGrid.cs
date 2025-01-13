namespace Tetris
{
    public class GameGrid
    {
        //Creating the game grid
        private readonly int[,] grid;
        //Adding the properties for the number of rows and columns
        public int Rows { get; }
        public int Columns { get; }
        //Define an indexer to provide easy access to the array --> "with this in place we can use indexing directly on a gamegrid object." - OttoBotCode
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        //The constructor will take the number of rows and columns as parameters
        public GameGrid(int rows, int columns)
        {
            //save the number of rows and columns
            Rows = rows;
            Columns = columns;
            //initialize the array
            grid = new int[rows, columns];
        }

        //Creating some convenience methods
        //check if a given row and column is inside the grid or not

    }
}