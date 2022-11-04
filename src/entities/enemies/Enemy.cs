namespace Academy.ConsoleSpaceWars {

    public abstract class Enemy : Entity {

        protected readonly int score;

        public Enemy(int xCoord, int yCoord, int health, float speed, int score) : base(xCoord, yCoord, health, speed) {
            this.score = score;
        }
    }
}