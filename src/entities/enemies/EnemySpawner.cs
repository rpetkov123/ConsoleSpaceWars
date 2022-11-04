using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Academy.ConsoleSpaceWars {

    public class EnemySpawner : UpdatableAndRenderableGameObject {

        private readonly int SPAWN_X = Console.WindowWidth - 20;

        private List<Enemy> enemies;

        private Random rnd = new Random();

        //INFO: we are using a premade system, might have to implement it ourselfs
        private readonly TimeSpan bigEnemyInterval = TimeSpan.FromMilliseconds(4000);
        private readonly TimeSpan flatEnemyInterval = TimeSpan.FromMilliseconds(3000);
        private readonly TimeSpan roundEnemyInterval = TimeSpan.FromMilliseconds(2200);
        private readonly TimeSpan squareEnemyInterval = TimeSpan.FromMilliseconds(2500);
        private readonly TimeSpan tallEnemyInterval = TimeSpan.FromMilliseconds(7000);

        private Stopwatch bigEnemyStopwatch = new Stopwatch();
        private Stopwatch flatEnemyStopwatch = new Stopwatch();
        private Stopwatch roundEnemyStopwatch = new Stopwatch();
        private Stopwatch squareEnemyStopwatch = new Stopwatch();
        private Stopwatch tallEnemyStopwatch = new Stopwatch();

        //INFO: could be based on its position
        public EnemySpawner(/* int xCoord, int yCoord */) : base(0, 0) {
            enemies = new List<Enemy>();

            bigEnemyStopwatch.Start();
            flatEnemyStopwatch.Start();
            roundEnemyStopwatch.Start();
            squareEnemyStopwatch.Start();
            tallEnemyStopwatch.Start();
        }

        public override void Update() {
            SpawnEnemies();

            foreach (Enemy e in enemies) {
                e.Update();
            }
        }

        public override void Render() {
            foreach (Enemy e in enemies) {
                e.Render();
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

            enemies.Add(e);
        }
    }
}