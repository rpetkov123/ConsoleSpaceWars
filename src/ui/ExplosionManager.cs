using System;
using System.Collections.Generic;

namespace Academy.ConsoleSpaceWars {

    public class ExplosionManager : UpdatableAndRenderableGameObject {

        private List<Explosion> explosions;

        public ExplosionManager() : base(0, 0) {
            explosions = new List<Explosion>();
        }

        public void SpawnExplosionAt(int x, int y) {
            Explosion explosion = new Explosion(x, y);
            explosions.Add(explosion);
        }

        public override void Update() {
            CheckForCompleted();

            foreach (Explosion expl in explosions) {
                expl.Update();
            }
        }

        public override void Render() {
            foreach (Explosion expl in explosions) {
                expl.Render();
            }
        }

        private void CheckForCompleted() {
            for (int i = 0; i < explosions.Count; i++) {
                if (explosions[i].Completed) {
                    explosions.RemoveAt(i);

                    i--;
                }
            }
        }
    }
}

