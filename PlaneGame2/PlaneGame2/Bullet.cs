using PlaneGame2.Resources;
using System.Drawing;
using System.Windows.Forms;

namespace PlaneGame2
{
    internal class Bullet : Element
    {

        private int power;
        public Bullet(Image ElementImage, int x, int y, int speed, int power) : base(ElementImage, x, y, speed)
        {
            this.Width = ElementImage.Width;
            this.Width = ElementImage.Height;
            this.power = power;
        }

        public override void Update(char c)
        {
            int h = Util.Panel_height;
            int w = Util.Panel_width;

            switch (c)
            {
                case 'w': this.Y -= Speed; break;
                case 's': this.Y += Speed; break;

            }
            if (this.Y >= h - this.Height) this.Y = h - this.Height;
            if (this.Y <= 0) this.Y = 0;
            if (this.X >= w - this.Width) this.X = w - this.Width;
            if (this.X <= 0) this.X = 0;
        }


        public new void Draw(PaintEventArgs e)
        {
           
            e.Graphics.DrawImage(this.ElementImage, this.X, this.Y);
        }

    }
}