using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PlaneGame2.Resources
{
    class Util
    {

        private Random random = new Random();
        
        private SoundPlayer boom_wav = new SoundPlayer(System.Environment.CurrentDirectory + @"\..\..\Resources\" + "boom.wav");
        private SoundPlayer end_wav = new SoundPlayer(System.Environment.CurrentDirectory + @"\..\..\Resources\" + "end.wav");
        private SoundPlayer fire_wav = new SoundPlayer(System.Environment.CurrentDirectory + @"\..\..\Resources\" + "fire.wav");
        private Image bgImg = Resource1.bg_700_1024;
        private Image playerImg = Resource1.space_shuttle_2.GetThumbnailImage(50, 50, null, new IntPtr());
        private Image enemyImg_1 = Resource1.alien_1.GetThumbnailImage(50, 50, null, new IntPtr());
        private Image enemyImg_2 = Resource1.space_capsule.GetThumbnailImage(50, 50, null, new IntPtr());
        private Image enemyImg_3 = Resource1.ufo.GetThumbnailImage(50, 50, null, new IntPtr());

        private static Image bulletImg = Resource1.space_shuttle.GetThumbnailImage(10, 10, null, new IntPtr());
        private static Image fire_8_8 = Resource1.fire_31_15.GetThumbnailImage(8, 8, null, new IntPtr());
        private static Image bullet2Img = RotateImg2(bulletImg, 180);
        
        private Util() { }
        private static int panel_height;
        private static int panel_width;
        private static Util UTIL;
        public static Util GetUtilInstance() {
            if (UTIL == null) UTIL = new Util();
            
            return UTIL;
            
        }
        


        public Image BgImg { get => bgImg; }
        public Image PlayerImg { get => playerImg; }
        public Image EnemyImg_1 { get => enemyImg_1; }
        public Image EnemyImg_2 { get => enemyImg_2; }
        public Image EnemyImg_3 { get => enemyImg_3; }
        public  Random Random { get => random;  }
        public static int Panel_height { get => panel_height; set => panel_height = value; }
        public static int Panel_width { get => panel_width; set => panel_width = value; }
        public static Image BulletImg { get => bulletImg;  }
        public static Image Bullet2Img { get => bullet2Img; }
       
        public SoundPlayer Boom_wav { get => boom_wav; }
        public SoundPlayer End_wav1 { get => end_wav; }
        public SoundPlayer Fire_wav { get => fire_wav; }
        public static Image Fire_8_8 { get => fire_8_8;  }

        //产生n个不同的随机数
        public int[] GetRandomNumber(int min, int max, int n)
        {   int[] arr = new int[n];
            List<int> list = new List<int>();
            for (int i =0;i<n;){
                int r = Random.Next(min, max);
                if (!list.Contains(r))
                {
                    list.Add(r);
                    arr[i] = r;
                    i++;
                }
            }
            return arr;
        }
        //判断两矩形是否相交
        public  static bool CheckCross(Rectangle r1, Rectangle r2)
        {
            PointF c1 = new PointF(r1.Left + r1.Width / 2.0f, r1.Top + r1.Height / 2.0f);
            PointF c2 = new PointF(r2.Left + r2.Width / 2.0f, r2.Top + r2.Height / 2.0f);
            return (Math.Abs(c1.X - c2.X) <= r1.Width / 2.0 + r2.Width / 2.0 && Math.Abs(c2.Y - c1.Y) <= r1.Height / 2.0 + r2.Height / 2.0);
        }

        //图片的旋转
        public static  Image RotateImg2(Image b, float angle)
        {
            angle = angle % 360;            //弧度转换  
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高  
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图  
            Image dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //计算偏移量  
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致  
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移  
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换  
            g.ResetTransform();
            g.Save();
            g.Dispose();
            //dsImage.Save("yuancd.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);  
            return dsImage;
        }

    }
}
