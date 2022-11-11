using System;

namespace Academy.ConsoleSpaceWars {

    public class FpsTimer : UpdatableGameObject {

        public Action OnCompleted;

        private int currentFrameCount;
        private int framesTarget;

        private bool enabled;
        private bool autoRestart;

        public FpsTimer(int framesTarget, bool autoStart = false, bool autoRestart = false) : base(0, 0) {
            currentFrameCount = 0;
            this.framesTarget = framesTarget;

            enabled = autoStart;
            this.autoRestart = autoRestart;
        }

        public void Start() {
            enabled = true;
        }

        public void Restart() {
            currentFrameCount = 0;
            enabled = true;
        }

        public void Stop() {
            enabled = false;
        }

        public override void Update() {
            if (!enabled) {
                return;
            }

            currentFrameCount++;

            if (currentFrameCount >= framesTarget) {
                OnCompleted?.Invoke();

                if (autoRestart) {
                    Restart();
                } else {
                    enabled = false;
                }
            }
        }
    }
}