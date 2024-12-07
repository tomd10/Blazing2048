namespace Blazing2048
{
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
    }
}
