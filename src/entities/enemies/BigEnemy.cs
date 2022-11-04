using System;

namespace Academy.ConsoleSpaceWars {

    public class BigEnemy : Enemy {

        private const float INITIAL_SPEED = 0.2f;
        private const int SCORE = 10;
        private const int HEALTH = 10;

        private double fractionalX;

        public BigEnemy(int xCoord, int yCoord) : base(xCoord, yCoord, HEALTH, INITIAL_SPEED, SCORE) {
            picture = new string[] {
                @"  _/\_  ",
                @" /_OO_\ ",
                @"() () ()"
            };

            blank = new string[] {
                @"        ",
                @"        ",
                @"        "
            };

            fractionalX = X;
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            fractionalX -= speed;

            X = (int)Math.Max(fractionalX, 0);
        }
    }
}