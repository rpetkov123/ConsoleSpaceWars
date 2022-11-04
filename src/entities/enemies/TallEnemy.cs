using System;

namespace Academy.ConsoleSpaceWars {

    public class TallEnemy : Enemy {

        private const float INITIAL_SPEED = 2f;
        private const int SCORE = 10;
        private const int HEALTH = 10;

        public TallEnemy(int xCoord, int yCoord) : base(xCoord, yCoord, HEALTH, INITIAL_SPEED, SCORE) {
            picture = new string[] {
                @"      !      ",
                @"     /!\     ",
                @"    /_O_\    ",
                @"   <_‗_‗_>   ",
                @"     \_/     "
            };

            blank = new string[] {
                @"             ",
                @"             ",
                @"             ",
                @"             ",
                @"             "
            };
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            X = (int)Math.Max(X - speed, 0);
        }
    }
}