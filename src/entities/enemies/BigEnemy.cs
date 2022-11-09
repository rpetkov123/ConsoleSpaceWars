using System;

namespace Academy.ConsoleSpaceWars {

    public class BigEnemy : Enemy {

        private const float INITIAL_SPEED = 0.2f;
        private const int SCORE = 10;
        private const int HEALTH = 10;

        private double fractionalX;

        private int shootDelayInFrames = 0;
        private int shootDelayTarget = 60;

        public BigEnemy(int xCoord, int yCoord) : base(xCoord, yCoord, INITIAL_SPEED, HEALTH, SCORE) {
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

            // shootStopwatch.Start();
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            fractionalX -= speed;

            X = (int)Math.Max(fractionalX, 0);

            shootDelayInFrames++;
            if (shootDelayInFrames >= shootDelayTarget) {
                Fire(X, Y + 1, BulletType.ARROW, DirectionType.LEFT);
                shootDelayInFrames = 0;
            }

            base.Update();
        }
    }
}