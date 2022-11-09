using System;
using System.Diagnostics;
using System.Timers;

namespace Academy.ConsoleSpaceWars {

    public class FlatEnemy : Enemy {

        private const float INITIAL_SPEED = 0.08f;
        private const int SCORE = 5;
        private const int HEALTH = 10;

        private double fractionalX;

        private Timer t;

        private TimeSpan shootDelay = TimeSpan.FromMilliseconds(2000);
        private Stopwatch shootStopwatch = new Stopwatch();

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

            shootStopwatch.Start();
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            fractionalX -= speed;

            X = (int)Math.Max(fractionalX, 0);

            if (shootStopwatch.Elapsed > shootDelay) {
                TripleShot();
            }

            base.Update();
        }

        private void TripleShot() {
            int targetCount = 3;
            int bulletCount = 0;

            t = new Timer(200);
            t.Elapsed += (object sender, ElapsedEventArgs e) => {
                Fire(X, Y + 1, BulletType.LASER, DirectionType.LEFT);

                bulletCount++;

                if (bulletCount == targetCount) {
                    t.Stop();
                    t.Dispose();
                    t = null;
                }
            };
            t.Start();

            shootStopwatch.Restart();
        }

        public override void Destroy() {
            if (t != null) {
                t.Stop();
                t.Dispose();
                t = null;
            }

            base.Destroy();
        }
    }
}