using PlaneGame2.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneGame2
{
    class Player
    {
        private Image PlayerImage;
        private int x;
        private int y;
        private int width;
        private int height;
        private int life=3;
        private int speed =7 ;
        private int score=0;
        private List<Bullet> player_bullets;

        public Image PlayerImage1 { get => PlayerImage; }
        public int X { get => x;  }
        public int Y { get => y; }
        public int Width { get => width;  }
        public int Height { get => height; }
    
        public int Score { get => score; }
        public int Life { get => life; set => life = value; }
        public int Score1 { get => score; set => score = value; }

        public Player(Image PlayerImage, int x, int y, int width, int height)
        {
            this.PlayerImage = PlayerImage;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            if (player_bullets == null)
                player_bullets = new List<Bullet>();
        }
      

        public void Update(KeyPressEventArgs cc)
        {
            char c = cc.KeyChar;
            int h = Util.Panel_height;
            int w = Util.Panel_width;

            switch (c)
            { 
                case 'w': this.y -= speed; break;
                case 's': this.y += speed; break;
                case 'a': this.x -= speed; break;
                case 'd': this.x += speed; break;     
            }
            if (this.y >= h - this.height) this.y = h - this.height;
            if (this.y <= 0) this.y = 0;
            if (this.x >= w - this.width)this.x = w - this.width;
            if (this.x <= 0) this.x = 0;
        }

        //public void Update(MouseEventArgs mm)
        //{
        //    this.x = mm.X - this.width/2; ;
        //    this.y = mm.Y-this.height/2;
        //    int h = Util.Panel_height;
        //    int w = Util.Panel_width;
        //    if (this.y >= h - this.height) this.y = h - this.height;
        //    if (this.y <= 0) this.y = 0;
        //    if (this.x >= w - this.width) this.x = w - this.width;
        //    if (this.x <= 0) this.x = 0;
        //}


        public void Draw(PaintEventArgs e,List<Enemy> enemys)
        {
            //draw player
          
            e.Graphics.DrawImage(this.PlayerImage, this.x, this.y);
            
            //draw bullet
            for(int b=0;b<player_bullets.Count;b++)//foreach (Bullet b in player_bullets)
            {
                Bullet bb = player_bullets[b];
                for (int k=0;k<enemys.Count;k++)
                {
                    Enemy ee = enemys[k];
                    bool isOut = bb.Y <= 0;
                    bool isCross = Util.CheckCross(ee.GetRectImage(), bb.GetRectImage());
                    if (isCross||isOut) {                            
                        player_bullets.Remove(bb);
                        if (isCross)
                        {
                            //爆炸效果
                           
                            
                            //音效
                            Util.GetUtilInstance().Boom_wav.Play();
                            //
                            enemys.Remove(ee);
                            this.score += 10;
                        }
                    } else {
                         bb.Update('w');
                         bb.Draw(e);
                    }
                }
                
               
            }
        }
        public void Fire() {
            Util.GetUtilInstance().Fire_wav.Play();
            player_bullets.Add(new Bullet(Util.BulletImg, this.X + this.width / 2-5, this.Y, 3, 3));
        }

        internal void Boom()
        {
            throw new NotImplementedException();
        }

        public Rectangle GetRectImage()
        {
            return new Rectangle(this.x, this.y, this.width, this.height);
        }

        internal void Move(bool key_a, bool key_d, bool key_s, bool key_w)
        {
            if (key_a && key_w  && !key_s&&!key_d) {
                // left front
                this.x -= speed;
                this.y -= speed;
            }
            if (!key_a && key_w && !key_s && key_d)
            {
                // right front
                this.x += speed;
                this.y -= speed;
            }
            if (key_a && !key_w && key_s && !key_d)
            {
                // left back
                this.x -= speed;
                this.y += speed;
            }
            if (!key_a && !key_w && key_s && key_d)
            {
                // right back
                this.x += speed;
                this.y += speed;
            }
        }
    }
}
