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

        public void ClearOnOutOfBounds() {
            Console.SetCursorPosition(X, Y);
            Console.Write(blank);
        }

        public override void Update() {
            previousX = X;
            // previousY = y;

            if (direction == DirectionType.RIGHT) {
                fractionalX += speed;
                X = (int)(Math.Min(fractionalX, Console.WindowWidth));
            } else {
                fractionalX -= speed;
                X = (int)(Math.Max(fractionalX, 0));
            }
        }
    }
}
