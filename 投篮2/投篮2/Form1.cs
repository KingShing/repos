using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 投篮2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics graphics;
        PaintEventArgs paintEvent;
        int index = 1;
        Point[] points;
        Image ball;
        Image basket = Resource1.basket;
        Timer timer;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
             timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(Timer_Tick);
             points = new Point[] { new Point(34, 377), new Point(40, 355), new Point(50, 343), new Point(66, 321), new Point(95, 293), new Point(165, 251), new Point(218, 228), new Point(334, 188), new Point(402, 175), new Point(502, 167) };
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
           Graphics gg=  this.CreateGraphics();
            gg.DrawImage(ball,points[index]);
            index++;
            if (index >= points.Length) {
                timer.Stop();
                return;
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            paintEvent = e;
            ball = Resource1.ball;
            Point point = new Point(10, 400);
            Point endPoint = new Point(point.X+500,point.Y-300);
            graphics = e.Graphics;
            e.Graphics.DrawImage(ball,point);
            e.Graphics.DrawImage(basket, endPoint);
            e.Graphics.DrawArc(new Pen(Color.Black),new Rectangle(point.X,180,2*(endPoint.X-point.X),2*(point.Y-endPoint.Y)),190,90);
            timer.Start();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
           MouseEventArgs ee = (MouseEventArgs)e;
            MessageBox.Show(ee.Location.ToString(), "");
        }
    }
}
