using System;

namespace Academy.ConsoleSpaceWars {

    public class SquareEnemy : Enemy {

        private const float INITIAL_SPEED = 1f;
        private const int SCORE = 5;
        private const int HEALTH = 10;

        public SquareEnemy(int xCoord, int yCoord) : base(xCoord, yCoord, HEALTH, INITIAL_SPEED, SCORE) {
            picture = new string[] {
                @" _!_!_ ",
                @"|_o-o_|",
                @" ^^^^^ "
            };

            blank = new string[] {
                @"       ",
                @"       ",
                @"       "
            };
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            X = (int)Math.Max(X - speed, 0);
        }
    }
}