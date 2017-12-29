using PlaneGame2.Resources;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PlaneGame2
{
    internal class Enemy
    {  
        private int x;
        private int y;
        private int width;
        private int height;
        private Image enemyImg_1;
        private int life;
        private int difficult;// 1 or 2
        private int speed=3;
        private List<Bullet> enemy_bullets;
        public Enemy(Image enemyImg_1, int width, int height, int life,int x,int y)
        {
            this.enemyImg_1 = enemyImg_1;
            this.width = width;
            this.height = height;
            this.life = life;
            this.x = x;
            this.y = y;
            this.difficult= Util.GetUtilInstance().Random.Next(1, 2);
            if (enemy_bullets == null)
                enemy_bullets = new List<Bullet>();
        }

        public int X { get => x;}
        public int Y { get => y; }
        public int Width { get => width;  }
        public int Height { get => height; }
        public Image EnemyImg_1 { get => enemyImg_1; }
        public int Life { get => life; }
        internal List<Bullet> Enemy_bullets { get => enemy_bullets; set => enemy_bullets = value; }

        public void Update()
        {
            int h = Util.Panel_height;
            int w = Util.Panel_width;
            this.y += speed;
            if (difficult==2)
            {  
                this.x = this.x+Util.GetUtilInstance().Random.Next(-speed, speed);
            }
            
            if (this.x >= w - this.width) this.x = w - this.width;
            if (this.x <= 0) this.x = 0;
            Fire();
        }
        internal void Draw(PaintEventArgs e,Player player)
        {
            //draw enemy
            
            e.Graphics.DrawImage(this.enemyImg_1, this.x, this.y);

            //Draw bullet
            for (int i =0;i<enemy_bullets.Count;i++ ) {
                Bullet b = enemy_bullets[i];
                bool isHurt = Util.CheckCross(b.GetRectImage(),player.GetRectImage());
                bool isOut = b.Y >=Util.Panel_height;
                if (isHurt||isOut)
                {
                    if(isHurt) player.Life -= 1;
                    enemy_bullets.Remove(b);
                }
                else {
                     b.Update('s');
                     b.Draw(e);
                }
            }
        }
        public void Fire()
        {
            if(Util.GetUtilInstance().Random.Next(1,100)==3)
            enemy_bullets.Add(new Bullet(Util.Bullet2Img, this.X+this.width/2, this.Y+this.height, 4, 2));
        }
        public Rectangle GetRectImage()
        {
            return new Rectangle(this.x, this.y, this.width, this.height);
        }
    }
}