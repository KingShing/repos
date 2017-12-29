using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuFish
{
    public partial class BuFish : Form
    {
        public BuFish()
        {
            InitializeComponent();
        }
        private Random rm;
        private PaintEventArgs myPaint;
        private MouseEventArgs myMouse;
        private EventArgs MyClick;
        private Timer MyTimer;
        private Cannon myCannon;
        private List<Fish> myFishItem;
        private KeyPressEventArgs myKeypress;
        private Image[] FishImages = new Image[] { MyResource.fish0,MyResource.fish8,MyResource.shark1};
        private int fishNumber = 10;
        public PaintEventArgs MyPaint { get => myPaint; set => myPaint = value; }
        public MouseEventArgs MyMouse { get => myMouse; set => myMouse = value; }
        public EventArgs MyClick1 { get => MyClick; set => MyClick = value; }
        internal Cannon MyCannon { get => myCannon; set => myCannon = value; }
        public KeyPressEventArgs MyKeypress { get => myKeypress; set => myKeypress = value; }
        public Random Rm { get => rm; set => rm = value; }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = MyResource.bgImage.GetThumbnailImage(this.ClientRectangle.Width,this.ClientRectangle.Height,null,new IntPtr());
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.MyTimer = new Timer();
            rm = new Random();
            MyTimer.Interval = 1000 / 30;   //  FPS:30
            MyTimer.Start();
            MyTimer.Tick += RePaint;
            this.MouseMove += BuFish_MouseMove;
            this.Click += BuFish_Click;
            this.Paint += BuFish_Paint;
            this.KeyPress += BuFish_KeyPress;
            if (myCannon == null)
                myCannon = new Cannon(MyResource.cannon1,this.ClientRectangle.Width/2-10, this.ClientRectangle.Height - MyResource.cannon1.Height, 1000);           
        }

        private void BuFish_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyKeypress = e;
            if(e.KeyChar=='j')
            if (myCannon.BulletFiredNum <= myCannon.BulletNumber)
            {
                Bullet b = new Bullet(MyUtil.RotateImg(MyResource.bullet.GetThumbnailImage(30, 30, null, new IntPtr()),MyCannon.Diretion_angle), MyCannon.X + 35, MyCannon.Y+32, 1, 5);
                myCannon.CannonBullets.Add(b);
                myCannon.BulletFiredNum++;
                myCannon.Fire(this);
            }
            
           
            myCannon.Update(this);
        }

        private void RePaint(object sender, EventArgs e){ this.Refresh(); }

        private void BuFish_Click(object sender, EventArgs e)
        {
            MyClick = e;
            if (myCannon.BulletFiredNum <= myCannon.BulletNumber)
            {
                Bullet b = new Bullet(MyUtil.RotateImg(MyResource.bullet.GetThumbnailImage(30, 30, null, new IntPtr()), MyCannon.Diretion_angle), MyCannon.X + 35, MyCannon.Y + 32, 1, 5);
                myCannon.CannonBullets.Add(b);
                // myCannon.BulletFiredNum++;
                myCannon.Fire(this);
            }

        }

        private void BuFish_Paint(object sender, PaintEventArgs e)
        {
            MyPaint = e;
            MyPaint.Graphics.DrawImage(MyResource.bottomBar.GetThumbnailImage(this.ClientRectangle.Width, 80,null,new IntPtr()),0,this.ClientRectangle.Height-80);
            //draw  Fish
            if (myFishItem == null)
                myFishItem = new List<Fish>();
            if (myFishItem.Count <= fishNumber)
            { if (rm.Next(1,30)==5)
                    myFishItem.Add(new Fish(FishImages[rm.Next(0, FishImages.Length)].GetThumbnailImage(100, 100, null, new IntPtr()), 0, rm.Next(0, this.Height - 200), 1, 5));
            }
            for(int i=0;i<myFishItem.Count;i++)
            {   Fish f=myFishItem[i];
                f.Update(this);
                if (f.X > this.ClientRectangle.Width)
                {
                    myFishItem.Remove(f);
                }
                else {
                    for(int j=0;j< this.MyCannon.CannonBullets.Count;j++)
                    {
                        Bullet b = this.MyCannon.CannonBullets[j];                    
                        bool isHurt= MyUtil.CheckCross(b.GetRectImage(), f.GetRectImage());
                        bool b_isOut = b.X <= 0||b.Y<=0;
                        bool f_isOut = f.X >= this.ClientRectangle.Width;
                        if (b_isOut)
                            MyCannon.CannonBullets.Remove(b);
                        if (f_isOut)
                            myFishItem.Remove(f);
                        if (isHurt)
                            {
                                myFishItem.Remove(f);
                                MyCannon.CannonBullets.Remove(b);
                            }
                        }
                f.Draw(this);              
                    }
            }
            //Draw Bullet
            if (this.MyCannon.CannonBullets != null)
                for (int i = 0; i < this.MyCannon.CannonBullets.Count; i++)
                {
                    Bullet b = this.MyCannon.CannonBullets[i];
                    b.Update(this);
                    b.Draw(this);
                }

            //draw Cannon            
            myCannon.Draw(this);

        }

       

        private void BuFish_MouseMove(object sender, MouseEventArgs e)
        {
            myMouse = e;           
         }
    }
}
