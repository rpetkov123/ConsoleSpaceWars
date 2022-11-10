using System;

namespace Academy.ConsoleSpaceWars {

    public class Player : Actor {

        private const int MAX_DISTANCE_X = 50;
        private const float INITIAL_SPEED = 1;
        private const int MAX_HEALTH = 10;

        private double fractionalX;

        private ConsoleKey? currentlyPressedKey;

        public Player(int xCoord, int yCoord) : base(xCoord, yCoord, INITIAL_SPEED, MAX_HEALTH) {

            picture = new string[] {
                @"=| \\  ",
                @"  |   >",
                @"=| //  "
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

            base.Update();
        }

        public override void Render() {
            base.Render();
        }

        private void HandleInput() {
            if (currentlyPressedKey == null) {
                return;
            }

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
                    BulletType bulletType = (BulletType)new Random().Next(0, Enum.GetNames(typeof(BulletType)).Length);
                    Fire(X + picture[0].Length - 1, Y + picture.Length / 2, bulletType, DirectionType.RIGHT);
                    break;
            }
        }
    }
}
