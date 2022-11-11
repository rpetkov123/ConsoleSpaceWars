using System;

namespace Academy.ConsoleSpaceWars {

    public class FlatEnemy : Enemy {

        private const float INITIAL_SPEED = 0.08f;
        private const int SCORE = 5;
        private const int HEALTH = 10;

        private double fractionalX;

        private int bulletsShot = 0;
        private int bulletsShotTarget = 3;

        private FpsTimer fireTimer;
        private FpsTimer tripleShotTimer;

        public FlatEnemy(int xCoord, int yCoord) : base(xCoord, yCoord, INITIAL_SPEED, HEALTH, SCORE) {
            picture = new string[] {
                @"   __O__   ",
                @"-=<_‗_‗_>=-"
            };

            blank = new string[] {
                @"           ",
                @"           "
            };

            fractionalX = X;

            fireTimer = new FpsTimer(120, false, true);
            fireTimer.OnCompleted += TripleShot;
            fireTimer.Start();
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            fractionalX -= speed;

            X = (int)Math.Max(fractionalX, 0);

            if (fireTimer != null) { fireTimer.Update(); }
            if (tripleShotTimer != null) { tripleShotTimer.Update(); }

            base.Update();
        }

        public override void Destroy() {
            if (fireTimer != null) {
                fireTimer.Stop();
                fireTimer.OnCompleted -= TripleShot;
            }

            if (tripleShotTimer != null) {
                tripleShotTimer.Stop();
                tripleShotTimer.OnCompleted -= FireShot;
            }

            base.Destroy();
        }

        private void TripleShot() {
            Fire(X, Y + 1, BulletType.LASER, DirectionType.LEFT);
            bulletsShot++;

            tripleShotTimer = new FpsTimer(15, false, true);
            tripleShotTimer.OnCompleted += FireShot;
            tripleShotTimer.Start();
        }

        private void FireShot() {
            Fire(X, Y + 1, BulletType.LASER, DirectionType.LEFT);
            bulletsShot++;

            if (bulletsShot >= bulletsShotTarget) {
                tripleShotTimer.Stop();
                tripleShotTimer.OnCompleted -= FireShot;

                bulletsShot = 0;
            }
        }
    }
}