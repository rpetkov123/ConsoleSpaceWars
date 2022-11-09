using System;

namespace Academy.ConsoleSpaceWars {

    public class FlatEnemy : Enemy {

        private const float INITIAL_SPEED = 0.08f;
        private const int SCORE = 5;
        private const int HEALTH = 10;

        private double fractionalX;

        private int shootDelayInFrames = 0;
        private int shootDelayTarget = 120;
        private bool shooting = false;
        private int shootDelayBetweenShots = 0;
        private int shootDelayBetweenShotsTarget = 15;
        private int bulletsShot = 0;
        private int bulletsShotTarget = 3;

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
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            fractionalX -= speed;

            X = (int)Math.Max(fractionalX, 0);

            TripleShotFps();

            base.Update();
        }

        private void TripleShotFps() {
            if (shooting) {
                shootDelayBetweenShots++;

                if (shootDelayBetweenShots >= shootDelayBetweenShotsTarget) {
                    Fire(X, Y + 1, BulletType.LASER, DirectionType.LEFT);
                    bulletsShot++;

                    shootDelayBetweenShots = 0;

                    if (bulletsShot == bulletsShotTarget) {
                        bulletsShot = 0;
                        shooting = false;
                    }
                }
            } else {
                shootDelayInFrames++;

                if (shootDelayInFrames >= shootDelayTarget) {
                    Fire(X, Y + 1, BulletType.LASER, DirectionType.LEFT);
                    bulletsShot++;

                    shootDelayInFrames = 0;
                    shooting = true;
                }
            }
        }

        public override void Destroy() {
            base.Destroy();
        }
    }
}