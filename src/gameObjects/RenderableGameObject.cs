namespace Academy.ConsoleSpaceWars {

    public abstract class RenderableGameObject : GameObject, IRenderable {

        public RenderableGameObject(int xCoord, int yCoord) : base(xCoord, yCoord) { }

        public abstract void Render();
    }
}