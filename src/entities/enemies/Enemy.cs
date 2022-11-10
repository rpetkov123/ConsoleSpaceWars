namespace Academy.ConsoleSpaceWars {

    public abstract class Enemy : Actor {

        public int Score { get; protected set; }

        public Enemy(int xCoord, int yCoord, float speed, int health, int score) : base(xCoord, yCoord, speed, health) {
            Score = score;
        }
    }
}