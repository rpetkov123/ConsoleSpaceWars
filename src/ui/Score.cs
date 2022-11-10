using System;

namespace Academy.ConsoleSpaceWars {

    public class Score : RenderableGameObject {

        public int CurrentScore { get; private set; }

        public Score(int x, int y, int currentScore) : base(x, y) {
            CurrentScore = currentScore;
        }

        public void SetScore(int value) {
            if (value < 0) {
                return;
            }

            CurrentScore = value;
        }

        public override void Render() {
            Console.SetCursorPosition(X, Y);
            Console.Write($"Score: {CurrentScore}");
        }
    }
}

