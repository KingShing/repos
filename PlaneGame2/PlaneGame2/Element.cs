using PlaneGame2.Resources;
using System.Drawing;
using System.Windows.Forms;

namespace PlaneGame2
{
    internal class Element
    {
        private Image elementImage;
        private int x;
        private int y;
        private int width;
        private int height;
        private int life ;
        private int speed ;

        public Image ElementImage { get => elementImage; set => elementImage = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int Life { get => life; set => life = value; }
        public int Speed { get => speed; set => speed = value; }

        public Element(Image ElementImage, int x, int y, int speed)
        {
            this.ElementImage = ElementImage;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.speed = speed;
        }


        public virtual void Update(char c) { }


        public  void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.ElementImage, this.x, this.y);
        }   
      
        public virtual Rectangle GetRectImage()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }

    }
}