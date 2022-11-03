using System;

namespace Academy.ConsoleSpaceWars {

    public abstract class Entity : UpdatableAndRenderableGameObject {

        protected string[] picture;
        protected string[] blank;

        protected int previousX;
        protected int previousY;

        protected float speed;
        protected int health;

        protected Entity(int xCoord, int yCoord, int health, float speed) : base(xCoord, yCoord) {
            previousX = xCoord;
            previousY = yCoord;

            this.speed = speed;
            this.health = health;
        }

        public override void Render() {
            Clear();

            //anchor at 0:0
            for (int i = 0; i < picture.Length; i++) {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(picture[i]);
            }

            //anchor at (~) 0.5 : 0.5
            // for (int i = 0; i < picture.Length; i++) {
            //     Console.SetCursorPosition(X - (picture[0].Length / 2), (Y - (int)Math.Floor((float)picture.Length / 2)) + i);
            //     Console.Write(picture[i]);
            // }
        }

        private void Clear() {
            for (int i = 0; i < blank.Length; i++) {
                Console.SetCursorPosition(previousX, previousY + i);
                Console.Write(blank[i]);
            }
        }
    }
}