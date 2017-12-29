using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuFish
{
    class Elements
    {
        private Image elementImage;
        private int x;
        private int y;
        private int width;
        private int height;
      

        public Image ElementImage { get => elementImage; set => elementImage = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
      

        public Elements(Image ElementImage, int x, int y)
        {
            this.ElementImage = ElementImage;
            this.X = x;
            this.Y = y;
            this.Width = ElementImage.Width;
            this.Height = ElementImage.Height;
        
        }


        public virtual void Update(BuFish game) {


        }


        public void Draw(BuFish game)
        {
            game.MyPaint.Graphics.DrawImage(this.ElementImage, this.X, this.Y);
        }

        public virtual Rectangle GetRectImage()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }

    }

}

