using System;

namespace Academy.ConsoleSpaceWars {

    public class FlatEnemy : Enemy {

        private const float INITIAL_SPEED = 0.08f;
        private const int SCORE = 5;
        private const int HEALTH = 10;

        private double fractionalX;

        public FlatEnemy(int xCoord, int yCoord) : base(xCoord, yCoord, HEALTH, INITIAL_SPEED, SCORE) {
            picture = new string[] {
                @"   __O__   ",
                @"-=<_‗_‗_>=-"
            };

            blank = new string[] {
                @"           ",
                @"           "
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