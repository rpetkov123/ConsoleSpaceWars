using System;

namespace Academy.ConsoleSpaceWars {

    public class Player : Entity {

        private const int MAX_DISTANCE_X = 90;
        private const float INITIAL_SPEED = 1;

        private double fractionalX;

        private ConsoleKey? currentlyPressedKey;

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

            blank = new string[] {
                @"       ",
                @"       ",
                @"       "
            };

            fractionalX = X;
        }

        public void OnInputReceived(ConsoleKey? key) {
            currentlyPressedKey = key;
        }

        public override void Update() {
            HandleInput();
        }

        private void HandleInput() {
            if (currentlyPressedKey == null) {
                return;
            }

            // if (Console.KeyAvailable) {
                previousX = X;
                previousY = Y;

                switch (currentlyPressedKey) {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        Y = (int)Math.Max(Y - speed, 0);
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        Y = (int)Math.Min(Y + speed, Console.WindowHeight - picture.Length);
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        X = (int)Math.Min(X + speed, MAX_DISTANCE_X);
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        X = (int)Math.Max(X - speed, 0);
                        break;

                    case ConsoleKey.Spacebar:
                        //TODO: implement me!
                        break;
                }
            // }
        }
    }
}
