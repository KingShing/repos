using System.Drawing;

namespace PlaneGame
{
    class ZiDanFather : GameObject
    {
        private Image imgZidan;

        //子弹威力
        public int Power
        {
            set;
            get;
        }

        /// <summary>
        /// 构造函数需要传递是谁发射的这个子弹，子弹是什么图片，速度是多少，威力是多大
        /// </summary>
       
        public ZiDanFather(PlaneFather pf, Image img, int speed, int power) : base(pf.X + pf.Width / 4 - 3, pf.Y, img.Width, img.Height, speed, 0, pf.Dir)//飞机朝上，子弹朝上，飞机朝下，子弹朝下
        {
            this.imgZidan = img;
            this.Power = power;
        }
        public override void Draw(Graphics g)
        {
            this.Move();
            g.DrawImage(imgZidan, this.X, this.Y, this.Width / 2, this.Height / 2);
        }


        public override void Move()
        {
            switch (Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
            }
            //由于子弹发出后，穿过窗体，要重写move函数
            if (this.Y <= 0)
                this.Y = -100;
            if (this.Y >= 780)
                this.Y = 1000;
        }
    }
}