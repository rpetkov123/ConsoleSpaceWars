using System;

namespace Academy.ConsoleSpaceWars {

    public abstract class Entity : UpdatableAndRenderableGameObject {

        protected string[] picture;
        protected string[] blank;

        protected int previousX;
        protected int previousY;

        protected float speed;

        protected Entity(int xCoord, int yCoord, float speed) : base(xCoord, yCoord) {
            previousX = xCoord;
            previousY = yCoord;

            this.speed = speed;
        }

        public override void Render() {
            Clear();

            for (int i = 0; i < picture.Length; i++) {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(picture[i]);
            }
        }

        public Rect ToRect() {
            return new Rect() {
                x = X,
                y = Y,
                w = picture[0].Length,
                h = picture.Length
            };
        }

        private void Clear() {
            for (int i = 0; i < blank.Length; i++) {
                Console.SetCursorPosition(previousX, previousY + i);
                Console.Write(blank[i]);
            }
        }

        public virtual void Destroy() {
            for (int i = 0; i < blank.Length; i++) {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(blank[i]);
            }
        }
    }
}