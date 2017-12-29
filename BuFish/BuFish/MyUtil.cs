using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuFish
{
    class MyUtil
    {

        public static bool CheckCross(Rectangle r1, Rectangle r2)
        {
            PointF c1 = new PointF(r1.Left + r1.Width / 2.0f, r1.Top + r1.Height / 2.0f);
            PointF c2 = new PointF(r2.Left + r2.Width / 2.0f, r2.Top + r2.Height / 2.0f);
            return (Math.Abs(c1.X - c2.X) <= r1.Width / 2.0 + r2.Width / 2.0 && Math.Abs(c2.Y - c1.Y) <= r1.Height / 2.0 + r2.Height / 2.0);
        }
     
        public static Image RotateImg(Image b, int angle)
        {
            int w = b.Width;
            int h = b.Height;
            Bitmap dsImage = new Bitmap(b.Width,b.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;      
            angle = angle % 360;
            g.TranslateTransform(w/2, h/2);
            g.RotateTransform(angle);
            g.TranslateTransform(-w/2, -h/2);
            g.DrawImage(b, 0,0);
            g.ResetTransform();
            g.Save();
            g.Dispose();
            b.Dispose();
            return dsImage;

        }

    
    }
}
