using System;

namespace Academy.ConsoleSpaceWars {

    public abstract class Bullet : Entity {

        private int damage;
        private DirectionType direction;

        private double fractionalX;

        public Bullet(int x, int y, float speed, int dmg, DirectionType dir) : base(x, y, speed) {
            damage = dmg;
            direction = dir;

            fractionalX = x;
        }

        public override void Update() {
            previousX = X;

            fractionalX += speed * (int)direction;
            X = (int)fractionalX;
        }
    }
}
