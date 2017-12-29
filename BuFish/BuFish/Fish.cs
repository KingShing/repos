using System;
using System.Drawing;

namespace BuFish
{
    internal class Fish:Elements
    {
        private bool alive=true;
        private int life;
        private int speed;
        private bool isBack=false;
        public Fish(Image image,int x,int y,int life,int speed):base(image,x,y)
        {
            this.life = life;
            this.speed = speed;
        }

        public bool IsBack { get => isBack; set => isBack = value; }
        public bool Alive { get => alive; set => alive = value; }

        public override void Update(BuFish game) {
            if (!this.IsBack)
            {

                this.X += speed;
                if (this.Y >= 33 && this.Y <= game.ClientRectangle.Height - 20 && game.Rm.Next(1, 60) == 3)
                    this.Y += game.Rm.Next(-2, 5);
                if (this.X > game.ClientRectangle.Width - 70 /*&& game.Rm.Next(1, 15) == 2*/)
                {
                    this.ElementImage = MyUtil.RotateImg(this.ElementImage, 180);
                    this.IsBack = !this.IsBack;
                    this.life++;
                }
            }
            else {
                this.X -= speed;
                if(game.Rm.Next(1, 60) == 3)
                this.Y += game.Rm.Next(-3, 3);
            }
        }

    }
}