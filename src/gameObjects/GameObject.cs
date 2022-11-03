namespace Academy.ConsoleSpaceWars {

    public abstract class GameObject {

        //members
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public GameObject(int xCoord, int yCoord) {
            X = xCoord;
            Y = yCoord;
        }
    }
}