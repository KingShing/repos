using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 投篮
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
      

        
        Point point;
        Graphics g;
        Image ball;
        Image basket;
        // 按比例缩放图片
        public Image ZoomPicture(Image SourceImage, int TargetWidth, int TargetHeight)
        {
            int IntWidth; //新的图片宽
            int IntHeight; //新的图片高
            try
            {
                System.Drawing.Imaging.ImageFormat format = SourceImage.RawFormat;
                System.Drawing.Bitmap SaveImage = new System.Drawing.Bitmap(TargetWidth, TargetHeight);
                Graphics g = Graphics.FromImage(SaveImage);
                g.Clear(Color.White);

                //计算缩放图片的大小

                if (SourceImage.Width > TargetWidth && SourceImage.Height <= TargetHeight)//宽度比目的图片宽度大，长度比目的图片长度小
                {
                    IntWidth = TargetWidth;
                    IntHeight = (IntWidth * SourceImage.Height) / SourceImage.Width;
                }
                else if (SourceImage.Width <= TargetWidth && SourceImage.Height > TargetHeight)//宽度比目的图片宽度小，长度比目的图片长度大
                {
                    IntHeight = TargetHeight;
                    IntWidth = (IntHeight * SourceImage.Width) / SourceImage.Height;
                }
                else if (SourceImage.Width <= TargetWidth && SourceImage.Height <= TargetHeight) //长宽比目的图片长宽都小
                {
                    IntHeight = SourceImage.Width;
                    IntWidth = SourceImage.Height;
                }
                else//长宽比目的图片的长宽都大
                {
                    IntWidth = TargetWidth;
                    IntHeight = (IntWidth * SourceImage.Height) / SourceImage.Width;
                    if (IntHeight > TargetHeight)//重新计算
                    {
                        IntHeight = TargetHeight;
                        IntWidth = (IntHeight * SourceImage.Width) / SourceImage.Height;
                    }
                }

                g.DrawImage(SourceImage, (TargetWidth - IntWidth) / 2, (TargetHeight - IntHeight) / 2, IntWidth, IntHeight);
                SourceImage.Dispose();

                return SaveImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            panel1.BackColor = System.Drawing.Color.White;
            basket = Resource1.basket;
            ball = Resource1.ball;
            pictureBox1.Height = ball.Height;
            pictureBox1.Width = ball.Width;
            pictureBox2.Height = basket.Height;
            pictureBox2.Width = basket.Width;
        }

        //
        public void GetCircular(PointF P1, PointF P2, PointF P3, out float R, out PointF PCenter)
        {
            float a = 2 * (P2.X - P1.X);
            float b = 2 * (P2.Y - P1.Y);
            float c = P2.X * P2.X + P2.Y * P2.Y - P1.X * P1.X - P1.Y * P1.Y;
            float d = 2 * (P3.X - P2.X);
            float e = 2 * (P3.Y - P2.Y);
            float f = P3.X * P3.X + P3.Y * P3.Y - P2.X * P2.X - P2.Y * P2.Y;
            float x = (b * f - e * c) / (b * d - e * a);
            float y = (d * c - a * f) / (b * d - e * a);
            float r = (float)Math.Sqrt((double)((x - P1.X) * (x - P1.X) + (y - P1.Y) * (y - P1.Y)));
            R = r;
            PointF pc = new PointF(x, y);
            PCenter = pc;
        }


        private void panel1_Click(object sender, EventArgs e)
        {
          
            float r;
            PointF p;
            GetCircular(new Point(13,374),new PointF(417,142),new PointF(234,153), out r, out p);
            // ZoomPicture(Resource1.basket, 200, 200);
            // Bitmap basketMap = new Bitmap(400, 400);
            // g = Graphics.FromImage(basketMap);
            // g.DrawImage(basket, point);

            pictureBox2.Image = basket;

            MouseEventArgs ee = (MouseEventArgs)e;
            point = ee.Location;
            // ZoomPicture(Resource1.ball, 100, 100);
            // Bitmap ballMap = new Bitmap(100, 100);
            // g = Graphics.FromImage(ballMap);
            // g.DrawImage(ball, point);
            int  StartX = point.X;
            int y;
            
            for (int  x =StartX;x<=400;x=x+10) {
               y= (int)Math.Sqrt(r * r - x * x);
                
               
               DrawBall(new Point((int)x, y), ball);
               //System.Threading.Thread.Sleep(50);
               DialogResult res= MessageBox.Show(x+"  "+y,"");
               
                
            }
            // MessageBox.Show(ee.X.ToString()+"  "+ee.Y.ToString(),"");
            // MessageBox.Show(r+"  "+p , "");
          

        }

      

        private void DrawBall(Point pp ,Image im)
        {

            pictureBox1.Left = pp.X;
            pictureBox1.Top = pp.Y;
            pictureBox1.Image = ball;
           // 
        }

    }
}
