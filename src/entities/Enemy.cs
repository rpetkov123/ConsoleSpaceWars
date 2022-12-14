using System;

namespace Academy.ConsoleSpaceWars {

    public class Enemy : Entity {

        private const float INITIAL_SPEED = 0.1f;

        private double fractionalX;

        public Enemy(int xCoord, int yCoord, int health) : base(xCoord, yCoord, health, INITIAL_SPEED) {

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
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            fractionalX -= speed;

            X = (int)Math.Max(fractionalX, 0);
        }

        /* public override void Render() {
            for (int i = 0; i < picture.Length; i++) {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(picture[i]);
            }
        } */
    }
}