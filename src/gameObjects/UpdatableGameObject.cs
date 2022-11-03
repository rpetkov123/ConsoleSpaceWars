namespace Academy.ConsoleSpaceWars {

    public abstract class UpdatableGameObject : GameObject, IUpdatable {

        public UpdatableGameObject(int xCoord, int yCoord) : base(xCoord, yCoord) { }

        public abstract void Update();
    }
}