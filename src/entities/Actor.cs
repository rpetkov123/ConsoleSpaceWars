using System;
using System.Collections.Generic;

namespace Academy.ConsoleSpaceWars {

    public abstract class Actor : Entity, IDamagable {

        public int CurrentHealth { get; protected set; }
        public int MaxHealth { get; protected set; }

        public Action<int> OnHealthChanged;

        public List<Bullet> Bullets { get; protected set; }

        protected Actor(int xCoord, int yCoord, float speed, int health) : base(xCoord, yCoord, speed) {
            CurrentHealth = health;
            MaxHealth = health;

            Bullets = new List<Bullet>();
        }

        public override void Update() {
            DestroyBulletOutOfBounds();

            foreach (Bullet b in Bullets) {
                b.Update();
            }
        }

        public override void Render() {
            base.Render();

            foreach (Bullet b in Bullets) {
                b.Render();
            }
        }

        public void Fire(int x, int y, BulletType type, DirectionType dir) {
            Bullet b;

            switch (type) {
                case BulletType.LASER:
                    b = new LaserBullet(x, y, dir);
                    break;

                case BulletType.ARROW:
                    b = new ArrowBullet(x, y, dir);
                    break;

                default:
                    b = new LaserBullet(x, y, dir);
                    break;
            }

            Bullets.Add(b);
        }

        public bool IsCollidingAt(Rect rect) {
            return (X < rect.x + rect.w) && (X + picture[0].Length > rect.x) &&
                (Y < rect.y + rect.h) && (Y + picture.Length > rect.y);
        }

        public override void Destroy() {
            for (int i = 0; i < Bullets.Count; i++) {
                Bullets[i].Destroy();
                Bullets.RemoveAt(i);

                i--;
            }
            base.Destroy();
        }

        private void DestroyBulletOutOfBounds() {
            for (int i = 0; i < Bullets.Count; i++) {
                if (Bullets[i].X + Bullets[i].ToRect().w >= Console.WindowWidth || Bullets[i].X <= 0) {
                    Bullets[i].Destroy();
                    Bullets.RemoveAt(i);

                    i--;
                }
            }
        }

        public void ApplyDamage(int dmg) {
            CurrentHealth -= dmg;

            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }
}