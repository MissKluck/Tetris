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
        /*
        check if a given row and column is inside the grid or not
        to be inside the grid, the row must be greater than or equal to 0, and less than the number of rows
        the same applies for the columns
        */
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        /*
        Method that checks if a given cell is empty or not
        the cell must be inside the grid, and the value at that entry in the array must be zero
        */
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        /*
        Method that checks if an entire row is full
        */
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                return false;
            }

            return true;
        }

        /*
        Method that checks if an entire row is empty
        */
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}