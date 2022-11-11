using System;

namespace Academy.ConsoleSpaceWars {

    public class BigEnemy : Enemy {

        private const float INITIAL_SPEED = 0.2f;
        private const int SCORE = 10;
        private const int HEALTH = 10;

        private double fractionalX;

        private FpsTimer fireTimer;

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

            fireTimer = new FpsTimer(60, false, true);
            fireTimer.OnCompleted += FireShot;
            fireTimer.Start();
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            fractionalX -= speed;

            X = (int)Math.Max(fractionalX, 0);

            if (fireTimer != null) { fireTimer.Update(); }

            base.Update();
        }

        public override void Destroy() {
            if (fireTimer != null) {
                fireTimer.Stop();
                fireTimer.OnCompleted -= FireShot;
            }

            base.Destroy();
        }

        private void FireShot() {
            Fire(X, Y + 1, BulletType.ARROW, DirectionType.LEFT);
        }
    }
}