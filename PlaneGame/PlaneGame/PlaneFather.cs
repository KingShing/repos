using System.Drawing;

namespace PlaneGame
{
    abstract class PlaneFather : GameObject
    {
        //声明一个存储飞机图片的字段
        private Image plane;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="img"></param>
        /// <param name="life"></param>
        /// <param name="speed"></param>
        /// <param name="dir"></param>
        public PlaneFather(int x, int y, Image img, int life, int speed, Direction dir)
            : base(x, y, img.Width, img.Height, speed, life, dir)
        {
            this.plane = img;
        }


    }
}