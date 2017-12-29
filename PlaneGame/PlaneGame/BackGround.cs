using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    class BackGround : GameObject
    {
        //将导入的背景图片绘制到窗体上
        private static Image imgBG = Resources.background_1;//用一个字段将要绘制的图片引用储存起来
       
        //构造函数调用父类构造函数
        public BackGround(int x, int y, int speed) 
        :base(x, y, imgBG.Width, imgBG.Height, speed, 0, Direction.Down)//注意哪些是需要从外界传入的就需要设置参数
        {

        }

        
        //绘制背景   
        public override void Draw(Graphics g)
        {
            this.Y += this.Speed;
            if (this.Y >= 0)
            {
                this.Y = -268;
            }
            g.DrawImage(imgBG, this.X, this.Y);
        }
    }
}
