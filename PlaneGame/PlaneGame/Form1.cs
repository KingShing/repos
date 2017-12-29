using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneGame
{
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                InitialGame();
            }

            static Random r = new Random();

            /// <summary>
            /// 初始化游戏
            /// </summary>
            /// 
            public void InitialGame()
            {
                //首先初始化背景
                SingleObject.GetSingle().AddGameObject(new BackGround(0, -568, 5));

                //初始化玩家飞机
                SingleObject.GetSingle().AddGameObject(new PlaneHero(200, 200, 20, 5, GameObject.Direction.Up));
            }

            /// <summary>
            /// 不应该每次都把打飞机（boss）初始化出来，有一定的几率
            /// </summary>
            private void InitialPlaneEnemy()
            {
                for (int i = 0; i < 3; i++)
                    SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -200, 5, 8, r.Next(0, 2)));

                //几率的实现：通过随机生成实现
                if (r.Next(0, 100) > 80)
                    SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -200, 5, 8, 2));
            }

            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                //窗体被绘制的时候，会执行当前事件（绘制背景）
                SingleObject.GetSingle().DrawGameobject(e.Graphics);//我们通过单例来实现与窗体的交互
            }

            private void timerBG_Tick(object sender, EventArgs e)
            {
                //每50毫秒就重绘制
                this.Invalidate();
                int PlaneNum = SingleObject.GetSingle().listPlaneEnemy.Count;
                if (PlaneNum < 3)
                    InitialPlaneEnemy();
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                //将图像绘制到缓冲区，减少闪烁
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            }
            /// <summary>
            /// 玩家飞机跟随移动
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                //当鼠标在移动的时候，会调用此函数，让玩家飞机跟随鼠标移动，就是将鼠标的
                //坐标值赋值给飞机的坐标
                SingleObject.GetSingle().Hero.MouseMove(e);
            }

            /// <summary>
            /// 玩家飞机发射子弹
            /// </summary>
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                //按下左键
                SingleObject.GetSingle().Hero.Fire();
            }

           
            /// <summary>
            /// 不断生成飞机
            /// </summary>
            private void JudgeFJ_Tick(object sender, EventArgs e)
            {
           
            int PlaneNum = SingleObject.GetSingle().listPlaneEnemy.Count;
            }
        }
    }

