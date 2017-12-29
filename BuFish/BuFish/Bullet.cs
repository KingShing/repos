using System;
using System.Drawing;

namespace BuFish
{
    internal class Bullet:Elements
    {
        private int diretion_angle;
        private double diretion_length=0;
        private int power;
        private int speed;
        public Bullet(Image bulletImage, int x, int y,int power,int speed) :base(bulletImage,x,y)
        {
            this.speed = speed;
            this.power = power;       
        }

        public int Diretion_angle { get => diretion_angle; set => diretion_angle = value; }

        public override void Update(BuFish game)
        {   
            double radius = (game.MyCannon.Diretion_angle+90) * Math.PI / 180.0;
            this.diretion_length += speed;
            this.X -= Convert.ToInt32(this.diretion_length * Math.Cos(radius));
            this.Y -= Convert.ToInt32(this.diretion_length * Math.Sin(radius));
        }
    }
}