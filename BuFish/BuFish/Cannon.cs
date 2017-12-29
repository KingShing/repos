using System;
using System.Collections.Generic;
using System.Drawing;

namespace BuFish
{
    internal class Cannon:Elements
    {
        private int diretion_angle=0;
        private int rotateAngle = 10;
        private int bulletFiredNum = 0;
        private int bulletNumber;
        private List<Bullet> cannonBullets = new List<Bullet>();

        public  List<Bullet> CannonBullets { get => cannonBullets; set => cannonBullets = value; }
        public int BulletFiredNum { get => bulletFiredNum; set => bulletFiredNum = value; }
        public int BulletNumber { get => bulletNumber; set => bulletNumber = value; }
        public int Diretion_angle { get => diretion_angle; set => diretion_angle = value; }
        public int RotateAngle { get => rotateAngle; set => rotateAngle = value; }

        public Cannon(Image cannon_image,int x,int y,int bulletNumber) :base(cannon_image, x,y)
        {
            this.bulletNumber = bulletNumber;
            this.Width = cannon_image.Width + 5;
            this.Height = cannon_image.Width + 5;
        }

        public override void Update(BuFish game)
        {
            switch (game.MyKeypress.KeyChar)
            {

                case 'a':
                    if (diretion_angle >= -70) {
                        diretion_angle -= rotateAngle;
                        if (diretion_angle == 0){
                            this.ElementImage = MyResource.cannon1;
                        }else{
                            this.ElementImage = MyUtil.RotateImg(this.ElementImage, -rotateAngle);
                        }
                    }
                    break;
                case 'd':
                    if (diretion_angle <= 70){
                        diretion_angle += rotateAngle;
                        if (diretion_angle == 0) {
                        this.ElementImage = MyResource.cannon1;
                        } else {
                            this.ElementImage = MyUtil.RotateImg(this.ElementImage, rotateAngle);
                        }
                    }
                    break;
            }

        }
       
        public void Fire(BuFish game) {
                    BulletFiredNum++;
                    bulletNumber--;   
        }
    }
}