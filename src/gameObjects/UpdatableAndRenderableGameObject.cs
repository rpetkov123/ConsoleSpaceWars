namespace Academy.ConsoleSpaceWars {

    public abstract class UpdatableAndRenderableGameObject : GameObject, IUpdatable, IRenderable {

        public UpdatableAndRenderableGameObject(int xCoord, int yCoord) : base(xCoord, yCoord) { }

        public abstract void Update();
        public abstract void Render();
    }
}