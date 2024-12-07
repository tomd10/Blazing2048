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

        //protected bool isWon = false;

        public bool isWon { get; protected set; } = false;
        public bool wonFlag { get; protected set; } = false;

        public bool isLost { get; protected set; } = false;

        public int score { get; protected set; }
    }
}
