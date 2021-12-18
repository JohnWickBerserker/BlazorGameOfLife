namespace BlazorGameOfLife.Core
{
    public class GameOfLife
    {
        public GameOfLife(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;

            Cells = new bool[rows][];
            for (var i = 0; i < rows; i++)
            {
                Cells[i] = new bool[cols];
            }
        }

        public int Rows { get; }
        public int Columns { get; }

        public bool[][] Cells;

        public void PlaceObject(int row, int colum)
        {
            Cells[row + 0][colum + 1] = true;
            Cells[row + 1][colum + 2] = true;
            Cells[row + 2][colum + 0] = true;
            Cells[row + 2][colum + 1] = true;
            Cells[row + 2][colum + 2] = true;
        }

        public void Loop()
        {
            bool[][] temp = new bool[Rows][];
            for (var i = 0; i < Rows; i++)
            {
                temp[i] = Cells[i].ToArray();
            }

            var dr = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
            var dc = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    var neighbours = 0;
                    for (var k = 0; k < 8; k++)
                    {
                        var r = i + dr[k];
                        var c = j + dc[k];
                        if (r < 0)
                        {
                            r = Rows - 1;
                        }
                        if (c < 0)
                        {
                            c = Columns - 1;
                        }
                        if (r >= Rows)
                        {
                            r = 0;
                        }
                        if (c >= Columns)
                        {
                            c = 0;
                        }
                        if (temp[r][c])
                        {
                            neighbours++;
                        }
                    }
                    if (neighbours == 3)
                    {
                        Cells[i][j] = true;
                    }
                    if (neighbours != 2 && neighbours != 3)
                    {
                        Cells[i][j] = false;
                    }
                }
            }
        }

        public void MakeCellAlive(int row, int column)
        {
            if (row < Cells.Length)
            {
                if (column < Cells[row].Length)
                {
                    Cells[row][column] = true;
                }
            }
        }

        public void MakeCellDead(int row, int column)
        {
            if (row < Cells.Length)
            {
                if (column < Cells[row].Length)
                {
                    Cells[row][column] = false;
                }
            }
        }
    }
}
