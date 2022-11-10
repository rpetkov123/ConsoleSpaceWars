using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Academy.ConsoleSpaceWars {

    public class EnemyDestroyedData {
        public int x;
        public int y;
        public int score;
    }

    public class EnemySpawner : UpdatableAndRenderableGameObject {

        public Action<EnemyDestroyedData> OnEnemyDestroyed;

        private readonly int SPAWN_X = Console.WindowWidth - 20;

        public List<Enemy> Enemies { get; private set; }

        private Random rnd = new Random();

        //INFO: we are using a premade system, might have to implement it ourselfs
        private readonly TimeSpan bigEnemyInterval = TimeSpan.FromMilliseconds(6000);
        private readonly TimeSpan flatEnemyInterval = TimeSpan.FromMilliseconds(7000);
        private readonly TimeSpan roundEnemyInterval = TimeSpan.FromMilliseconds(8200);
        private readonly TimeSpan squareEnemyInterval = TimeSpan.FromMilliseconds(12500);
        private readonly TimeSpan tallEnemyInterval = TimeSpan.FromMilliseconds(7000);

        private Stopwatch bigEnemyStopwatch = new Stopwatch();
        private Stopwatch flatEnemyStopwatch = new Stopwatch();
        private Stopwatch roundEnemyStopwatch = new Stopwatch();
        private Stopwatch squareEnemyStopwatch = new Stopwatch();
        private Stopwatch tallEnemyStopwatch = new Stopwatch();

        //INFO: could be based on its position
        public EnemySpawner(/* int xCoord, int yCoord */) : base(0, 0) {
            Enemies = new List<Enemy>();

            bigEnemyStopwatch.Start();
            flatEnemyStopwatch.Start();
            // roundEnemyStopwatch.Start();
            // squareEnemyStopwatch.Start();
            // tallEnemyStopwatch.Start();
        }

        public override void Update() {
            DestroyOutOfBounds();

            SpawnEnemies();

            foreach (Enemy e in Enemies) {
                e.Update();
            }
        }

        public override void Render() {
            foreach (Enemy e in Enemies) {
                e.Render();
            }
        }

        public bool IsPlayerBulletCollidingWithEnemy(Bullet b) {
            bool result = false;

            for (int i = 0; i < Enemies.Count; i++) {
                if (Enemies[i].IsCollidingAt(b.ToRect())) {
                    DestroyEnemy(i);

                    result = true;

                    break;
                }
            }

            return result;
        }

        public bool IsPlayerCollidingWithEnemy(Player pl) {
            bool result = false;
            for (int i = 0; i < Enemies.Count; i++) {
                if (pl.IsCollidingAt(Enemies[i].ToRect())) {
                    DestroyEnemy(i);

                    result = true;
                    break;
                }
            }

            return result;
        }

        public bool IsEnemyBulletsCollidingWithPlayer(Player player) {
            bool result = false;

            foreach (Enemy e in Enemies) {
                for (int i = 0; i < e.Bullets.Count; i++) {
                    if (player.IsCollidingAt(e.Bullets[i].ToRect())) {
                        e.Bullets[i].Destroy();
                        e.Bullets.RemoveAt(i);

                        result = true;

                        i--;
                    }
                }
            }

            return result;
        }

        private void DestroyOutOfBounds() {
            for (int i = 0; i < Enemies.Count; i++) {
                if (Enemies[i].X <= 0) {
                    DestroyEnemy(i);

                    i--;
                }
            }
        }

        private void SpawnEnemies() {
            if (bigEnemyStopwatch.Elapsed >= bigEnemyInterval) {
                SpawnEnemy(typeof(BigEnemy));

                bigEnemyStopwatch.Restart();
            }

            if (flatEnemyStopwatch.Elapsed >= flatEnemyInterval) {
                SpawnEnemy(typeof(FlatEnemy));

                flatEnemyStopwatch.Restart();
            }

            if (roundEnemyStopwatch.Elapsed >= roundEnemyInterval) {
                SpawnEnemy(typeof(RoundEnemy));

                roundEnemyStopwatch.Restart();
            }

            if (squareEnemyStopwatch.Elapsed >= squareEnemyInterval) {
                SpawnEnemy(typeof(SquareEnemy));

                squareEnemyStopwatch.Restart();
            }

            if (tallEnemyStopwatch.Elapsed >= tallEnemyInterval) {
                SpawnEnemy(typeof(TallEnemy));

                tallEnemyStopwatch.Restart();
            }
        }

        private void SpawnEnemy(Type type) {
            Enemy e;

            if (type == typeof(BigEnemy)) {
                e = new BigEnemy(SPAWN_X, rnd.Next(3, 27));      //TODO: magic numbers
            } else if (type == typeof(FlatEnemy)) {
                e = new FlatEnemy(SPAWN_X, rnd.Next(2, 28));
            } else if (type == typeof(RoundEnemy)) {
                e = new RoundEnemy(SPAWN_X, rnd.Next(3, 27));
            } else if (type == typeof(SquareEnemy)) {
                e = new SquareEnemy(SPAWN_X, rnd.Next(3, 27));
            } else if (type == typeof(TallEnemy)) {
                e = new TallEnemy(SPAWN_X, rnd.Next(5, 25));
            } else {
                //something is not OK
                return;
            }

            Enemies.Add(e);
        }

        private void DestroyEnemy(int enemyIndex) {
            EnemyDestroyedData data = new EnemyDestroyedData() {
                x = Enemies[enemyIndex].X,
                y = Enemies[enemyIndex].Y,
                score = Enemies[enemyIndex].Score
            };
            OnEnemyDestroyed?.Invoke(data);

            Enemies[enemyIndex].Destroy();
            Enemies[enemyIndex] = null;

            Enemies.RemoveAt(enemyIndex);
        }
    }
}