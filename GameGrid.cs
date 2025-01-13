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

        /*
        Method to remove full rows and move the rows above down
        Using the variable "cleared", it will check each row if it's full, if it is then it will clear it from the board and increment the value once. if it isn't then it will move on to the next. 
        However before it moves on, if the row below a not cleared row was cleared, it will move that row down before it continues
        The remaining rows which haven't been cleared are moved down based on the amount of the cleared rows
        */

        //Method that clears a row
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        //Method that moved a row down by  certain number of rows
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        //Method that clears full rows --> clear variable starts at 0, and we move from the bottom row towards the top
        public int ClearFullRows()
        {
            int cleared = 0;
            //check if the current row is full, if it is, clear it and increment cleared variable
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                //if cleared is greater than 0, we move the current row down by the numbr of cleared rows
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
                //then finally we return the number of cleared rows
            }
            return cleared;
        }


    }
}