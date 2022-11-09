namespace Academy.ConsoleSpaceWars {

    public abstract class Enemy : Actor {

        protected readonly int score;

        public Enemy(int xCoord, int yCoord, float speed, int health, int score) : base(xCoord, yCoord, speed, health) {
            this.score = score;
        }
    }
}