using System;

namespace Academy.ConsoleSpaceWars {

    public class RoundEnemy : Enemy {

        private const float INITIAL_SPEED = 1f;
        private const int SCORE = 5;
        private const int HEALTH = 10;

        public RoundEnemy(int xCoord, int yCoord) : base(xCoord, yCoord, HEALTH, INITIAL_SPEED, SCORE) {
            picture = new string[] {
                @" _!_ ",
                @"(_o_)",
                @" ^^^ "
            };

            blank = new string[] {
                @"     ",
                @"     ",
                @"     "
            };
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            X = (int)Math.Max(X - speed, 0);
        }
    }
}