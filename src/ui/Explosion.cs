using System;

namespace Academy.ConsoleSpaceWars {

    public class Explosion : UpdatableAndRenderableGameObject {

        private string[,] picture = new string[9, 5]
            {
				// 0
				{   @"           ",
                    @"   █████   ",
                    @"   █████   ",
                    @"   █████   ",
                    @"           "  },
				// 1		  ,
				{   @"           ",
                    @"           ",
                    @"     *     ",
                    @"           ",
                    @"           "  },
				// 2		  ,
				{   @"           ",
                    @"     *     ",
                    @"    *#*    ",
                    @"     *     ",
                    @"           "  },
				// 3		  ,
				{   @"           ",
                    @"    *#*    ",
                    @"   *#*#*   ",
                    @"    *#*    ",
                    @"           "  },
				// 4		  ,
				{   @"     *     ",
                    @"   *#*#*   ",
                    @"  *#* *#*  ",
                    @"   *#*#*   ",
                    @"     *     "  },
				// 5		  ,
				{   @"    *#*    ",
                    @"  *#* *#*  ",
                    @" *#*   *#* ",
                    @"  *#* *#*  ",
                    @"    *#*    "  },
				// 6		  ,
				{   @"   *   *   ",
                    @" **     ** ",
                    @"**       **",
                    @" **     ** ",
                    @"   *   *   "  },
				// 7		  ,
				{   @"   *   *   ",
                    @" *       * ",
                    @"*         *",
                    @" *       * ",
                    @"   *   *   "  },
				// 8
				{
                    @"           ",
                    @"           ",
                    @"           ",
                    @"           ",
                    @"           " }
            };

        private int currentFrameIndex;
        private int framesPassed = 0;
        private int framesTarget = 10;

        public bool Completed { get; private set; }

        public Explosion(int x, int y) : base(x, y) {
            currentFrameIndex = 0;
            Completed = false;
        }

        public override void Update() {
            if (Completed) {
                return;
            }

            framesPassed++;

            if (framesPassed >= framesTarget) {
                currentFrameIndex++;

                if (currentFrameIndex >= picture.GetLength(0)) {
                    Completed = true;
                    currentFrameIndex--;        //a bit of a hack: we don't want to exceed the array size
                } else {
                    framesPassed = 0;
                }
            }
        }

        public override void Render() {
            for (int i = 0; i < picture.GetLength(1); i++) {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(picture[currentFrameIndex, i]);
            }
        }
    }
}
