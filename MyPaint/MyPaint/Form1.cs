using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Graphics g; 
        Point spoint;
        Point epoint;
        Timer t;
        Rectangle rect;
        TextureBrush textureBrush;
        bool drawing= false;
        private void Form1_Load(object sender, EventArgs e)
        { 

           
            pictureBox1.MouseDown += new MouseEventHandler(this.PictureBox1_MouseDown);
            pictureBox1.MouseUp   += new MouseEventHandler(this.PictureBox1_MouseUp);
            pictureBox1.MouseMove += new MouseEventHandler(this.PictureBox1_MouseMove);
            pictureBox1.Paint += PictureBox1_Paint;
            rect   = new Rectangle();
            bitmap = new Bitmap(600,600);
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
           
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                if (drawing)
                {
                    g = Graphics.FromImage(bitmap);
                    g.Clear(Color.White);
                    g.DrawLine(new Pen(Color.Black), spoint, e.Location);
                   
                    this.pictureBox1.Image = bitmap;
                    textureBrush = new TextureBrush(bitmap);
                    rect = GetRectangleFromPoints(spoint, e.Location);
                    bitmap.MakeTransparent(Color.White);
                }        
            }
        }
        protected Rectangle GetRectangleFromPoints(Point p1, Point p2)
        {
            Point oPoint;
            Rectangle rect;

            if ((p2.X > p1.X) && (p2.Y > p1.Y))
            {
                rect = new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
            }
            else if ((p2.X < p1.X) && (p2.Y < p1.Y))
            {
                rect = new Rectangle(p2, new Size(p1.X - p2.X, p1.Y - p2.Y));
            }
            else if ((p2.X > p1.X) && (p2.Y < p1.Y))
            {
                oPoint = new Point(p1.X, p2.Y);
                rect = new Rectangle(oPoint, new Size(p2.X - p1.X, p1.Y - oPoint.Y));
            }
            else
            {
                oPoint = new Point(p2.X, p1.Y);
                rect = new Rectangle(oPoint, new Size(p1.X - p2.X, p2.Y - p1.Y));
            }
            return rect;
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            spoint = e.Location;
            rect.Location = e.Location;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            // g.Dispose();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
