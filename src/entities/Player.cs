using System;

namespace Academy.ConsoleSpaceWars {

    public class Player : Entity {

        private const float INITIAL_SPEED = 1;

        private double fractionalX;

        public Player(int xCoord, int yCoord, int health) : base(xCoord, yCoord, health, INITIAL_SPEED) {

            picture = new string[] {
                @"=| \\  ",
                @"  |   >",
                @"=| //  "
                // @"-----------",
                // @"-----------",
                // @"-----------",
                // @"-----------",
                // @"-----------",
            };

            fractionalX = X;
        }

        public override void Update() {
            previousX = X;
            previousY = Y;

            // fractionalX += speed;

            // X = (int)Math.Max(fractionalX, 0);
        }
    }
}
