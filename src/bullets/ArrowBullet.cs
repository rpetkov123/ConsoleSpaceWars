namespace Academy.ConsoleSpaceWars {

    public class ArrowBullet : Bullet {

        private const int DAMAGE = 1;
        private const float INITIAL_SPEED = 1f;

        private string[] pictureVariants = new string[] {
            "---->",
            "<----"
        };

        public ArrowBullet(int x, int y, DirectionType dir) : base(x, y, INITIAL_SPEED, DAMAGE, dir) {
            string pic = (dir == DirectionType.RIGHT) ? pictureVariants[0] : pictureVariants[1];

            picture = new string[] { pic };
            blank = new string[] { @"     " };
        }
    }
}