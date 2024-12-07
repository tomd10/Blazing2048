namespace Blazing2048
{
    public class ExtendedGame : Game
    {
        public ExtendedGame(int dimX, int dimY, int spawnCount)
        {
            this.dimX = dimX;
            this.dimY = dimY;
            this.spawnCount = spawnCount;
            gameBoard = new int[dimX, dimY];

            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    gameBoard[i, j] = 0;
                }
            }

            GenerateTiles(2);
        }

        public ExtendedGame(string s)
        {
            //2048#dimX#dimY#spawnCount#winFlag#score#arr1,arr2,....
            try
            {
                string[] words = s.Split('#');
                dimX = int.Parse(words[1]);
                dimY = int.Parse(words[2]);
                spawnCount = int.Parse(words[3]);
                wonFlag = bool.Parse(words[4]);
                score = int.Parse(words[5]);

                gameBoard = new int[dimX, dimY];

                List<string> board = words[6].Split(",").ToList();

                for (int i = 0; i < dimX; i++)
                {
                    for (int j = 0; j < dimY; j++)
                    {
                        gameBoard[i, j] = int.Parse(board[0]);
                        board.RemoveAt(0);
                    }
                }
            }
            catch
            {
                score = -1;
            }
        }
    }
}
