namespace Blazing2048
{
    public class StandardGame : Game
    {

        public StandardGame()
        {
            score = 0;
            dimX = 4;
            dimY = 4;
            spawnCount = 1;
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
