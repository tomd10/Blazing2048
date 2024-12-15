namespace Blazing2048
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    public abstract class Game
    {
        protected Random rnd = new Random();

        public int[,] gameBoard { get; protected set; }
        public int[,] previousGameBoard { get; protected set; } = null;

        protected int dimX;
        protected int dimY;
        protected int spawnCount;

        public bool isWon { get; protected set; } = false;
        public bool wonFlag { get; protected set; } = false;

        public bool isLost { get; protected set; } = false;

        public int score { get; protected set; }

        public void GenerateTiles(int amount)
        {
            for (int count = 0; count < amount; count++)
            {
                //Find indexes of zeroes (empty tiles)
                List<int[]> freeIndexes = new List<int[]>();
                for (int i = 0; i < dimX; i++)
                {
                    for (int j = 0; j < dimY; j++)
                    {
                        if (gameBoard[i, j] == 0)
                        {
                            freeIndexes.Add(new int[] { i, j });
                        }
                    }
                }

                //Check for empty array
                if (freeIndexes.Count == 0) return;

                //Select random empty tile
                int[] selectedIndexes = freeIndexes[rnd.Next(freeIndexes.Count)];
                gameBoard[selectedIndexes[0], selectedIndexes[1]] = 2;

                //10% probability for a new 4 tile
                if (rnd.Next(0, 10) == 0)
                {
                    gameBoard[selectedIndexes[0], selectedIndexes[1]] = 4;
                }
            }
        }

        public bool CheckForWin()
        {
            if (wonFlag == true)
            {
                isWon = false;
                return false;
            }

            foreach (int i in gameBoard)
            {
                if (i == 2048)
                {
                    isWon = true;
                    wonFlag = true;
                    return true;
                }
            }
            return false;
        }

        public void CheckForLose()
        {
            Console.WriteLine(Move(Direction.Left, false) + " " + Move(Direction.Right, false) + " " + Move(Direction.Up, false) + " " + Move(Direction.Down, false));
            isLost = !Move(Direction.Left, false) && !Move(Direction.Right, false)
                && !Move(Direction.Up, false) && !Move(Direction.Down, false);
        }
        public bool Move(Direction dir, bool perform)
        {
            //Deep gameBoard copy
            int[,] gameBoardCopy = new int[dimX, dimY];
            Array.Copy(gameBoard, gameBoardCopy, dimX * dimY);



            if (dir == Direction.Up || dir == Direction.Down)
            {
                //Get columns
                for (int colNumber = 0; colNumber < dimY; colNumber++)
                {
                    List<int> column = new List<int>();
                    for (int rowNumber = 0; rowNumber < dimX; rowNumber++)
                    {
                        column.Add(gameBoardCopy[rowNumber, colNumber]);
                    }

                    column = AuxMethods.RemoveZeroes(column);
                    if (column.Count > 1)
                    {
                        if (dir == Direction.Up)
                        {
                            //Add tiles together
                            for (int i = 0; i < column.Count - 1;)
                            {
                                if (column[i] == column[i + 1])
                                {
                                    column[i] = column[i] + column[i + 1];
                                    if (perform) score = score + column[i];
                                    column[i + 1] = 0;
                                    i = i + 2;
                                }
                                else
                                {
                                    i = i + 1;
                                }
                            }
                        }
                        else
                        {
                            for (int i = column.Count - 1; i > 0;)
                            {
                                if (column[i] == column[i - 1])
                                {
                                    column[i] = column[i] + column[i - 1];
                                    if (perform) score = score + column[i];
                                    column[i - 1] = 0;
                                    i = i - 2;
                                }
                                else
                                {
                                    i = i - 1;
                                }
                            }
                        }

                    }
                    column = AuxMethods.RemoveZeroes(column);

                    //Fill the rest of column with zeroes
                    int emptySpaces = dimX - column.Count;
                    if (dir == Direction.Up)
                    {
                        for (int i = 0; i < emptySpaces; i++) column.Add(0);

                    }
                    else
                    {
                        for (int i = 0; i < emptySpaces; i++) column.Insert(0, 0);
                    }

                    //Load shifted column into gameBoardCopy
                    for (int i = 0; i < column.Count; i++)
                    {
                        gameBoardCopy[i, colNumber] = column[i];
                    }


                }
            }
            else
            {
                for (int rowNumber = 0; rowNumber < dimX; rowNumber++)
                {
                    List<int> row = new List<int>();
                    for (int colNumber = 0; colNumber < dimY; colNumber++)
                    {
                        row.Add(gameBoardCopy[rowNumber, colNumber]);
                    }

                    row = AuxMethods.RemoveZeroes(row);
                    if (row.Count > 1)
                    {
                        if (dir == Direction.Left)
                        {
                            for (int i = 0; i < row.Count - 1;)
                            {
                                if (row[i] == row[i + 1])
                                {
                                    row[i] = row[i] + row[i + 1];
                                    if (perform) score = score + row[i];

                                    row[i + 1] = 0;
                                    i = i + 2;
                                }
                                else
                                {
                                    i = i + 1;
                                }
                            }
                        }
                        else
                        {
                            for (int i = row.Count - 1; i > 0;)
                            {
                                if (row[i] == row[i - 1])
                                {
                                    row[i] = row[i] + row[i - 1];
                                    if (perform) score = score + row[i];

                                    row[i - 1] = 0;
                                    i = i - 2;
                                }
                                else
                                {
                                    i = i - 1;
                                }
                            }
                        }

                    }
                    row = AuxMethods.RemoveZeroes(row);

                    int emptySpaces = dimY - row.Count;
                    if (dir == Direction.Left)
                    {
                        for (int i = 0; i < emptySpaces; i++) row.Add(0);

                    }
                    else
                    {
                        for (int i = 0; i < emptySpaces; i++) row.Insert(0, 0);
                    }

                    for (int i = 0; i < row.Count; i++)
                    {
                        gameBoardCopy[rowNumber, i] = row[i];
                    }
                }
            }

            //Check whether we moved a tile
            bool isSame = true;
            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    if (gameBoard[i, j] != gameBoardCopy[i, j])
                    {
                        isSame = false;
                    }
                }
            }

            //Save the move
            if (perform)
            {
                previousGameBoard = gameBoard;
                gameBoard = gameBoardCopy;

                CheckForWin();
                CheckForLose();

                if (!isLost && !isSame) GenerateTiles(spawnCount);
            }

            return !isSame;
        }

        public override string ToString()
        {
            //2048#dimX#dimY#spawnCount#winFlag#score#arr1,arr2,....
            string s = "2048#" + dimX.ToString() + "#" + dimY.ToString() + "#" + spawnCount.ToString() + "#" + wonFlag.ToString() + "#" + score.ToString() + "#";
            foreach (int i in gameBoard)
            {
                s = s + i.ToString() + ",";
            }
            s = s.Substring(0, s.Length - 1) + "#";
            s = s + AuxMethods.GetChecksum(s);

            return s;
        }
    }
}
