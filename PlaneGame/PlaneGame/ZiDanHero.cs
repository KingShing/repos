using System.Drawing;
using System.Windows.Forms;

namespace PlaneGame
{
    class ZiDanHero : ZiDanFather
    {
        private static Image ZDhero = Resources.bullet1;

        /// <summary>
        /// 构造函数初始化
        /// </summary>
       
        public ZiDanHero(PlaneFather pf, int speed, int power)
            : base(pf, ZDhero, speed, power) { }
       
        internal void MouseMove(MouseEventArgs e)
        {
            this.X = e.X;
            this.Y = e.Y;
        }

    }
}