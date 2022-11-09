namespace Academy.ConsoleSpaceWars {

    public class LaserBullet : Bullet {

        private const int DAMAGE = 2;
        private const float INITIAL_SPEED = 0.5f;

        public LaserBullet(int x, int y, DirectionType dir) : base(x, y, INITIAL_SPEED, DAMAGE, dir) {
            picture = new string[] { @"*" };
            blank = new string[] { @" " };
        }
    }
}