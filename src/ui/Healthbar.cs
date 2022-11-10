using System;

namespace Academy.ConsoleSpaceWars {

    public class HealthBar : RenderableGameObject {

        private int currentHealth;
        private int maxHealth;

        public HealthBar(int x, int y, int curHealth, int maxHealth) : base(x, y) {
            this.currentHealth = curHealth;
            this.maxHealth = maxHealth;
        }

        public void SetHealth(int value) {
            if (value < 0 || value > maxHealth) {
                return;
            }

            currentHealth = value;
        }

        public override void Render() {
            string picture = "[";

            for (int i = 0; i < currentHealth; i++) {
                picture += "-";
            }
            for (int i = currentHealth; i < maxHealth; i++) {
                picture += " ";
            }
            picture += "]";

            float healthRatio = (float)currentHealth / (float)maxHealth;

            if (healthRatio >= 0.8) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else if (healthRatio >= 0.4) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.SetCursorPosition(X, Y);
            Console.Write(picture);
            Console.ResetColor();
        }
    }
}