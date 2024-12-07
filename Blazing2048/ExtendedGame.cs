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
    }
}
