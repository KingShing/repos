using PlaneGame2.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneGame2

{

    public partial class PlaneGame : Form
    {


        public PlaneGame()
        {
            InitializeComponent();
            if (timer == null)
                timer = new Timer();
            if (enemys == null)
                enemys = new List<Enemy>();
           
        }
        private PaintEventArgs paintEventArgs;
        private Timer timer;
        private List<Enemy> enemys;
        private Util UTIL;
        private Player player;
      
        private bool key_w;
        private bool key_s;
        private bool key_a;
        private bool key_d;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UTIL = Util.GetUtilInstance();
            BackgroundInit();
            int fps = 30;
            timer.Tick += Timer_Tick;
            timer.Interval = 1000 / fps;
            timer.Start();
            this.Cursor = Cursors.NoMove2D;
         
        }

        private void Timer_Tick(object sender, EventArgs ev)
        {
            if (player.Life <= 0)
            {
                timer.Stop();
                MessageBox.Show("GameOver", "Dead");
                return;
            }
           
            this.Refresh();
        }

        private void BackgroundInit()
        {
            Util.Panel_height = this.ClientRectangle.Height;
            Util.Panel_width = this.ClientRectangle.Width;
            this.BackgroundImage = UTIL.BgImg;
            this.Paint += new PaintEventHandler(Panel1_Paint);
            this.KeyPress += Form1_KeyPress;
            this.PreviewKeyDown += Form1_PreviewKeyDown;
            this.KeyUp += Form1_KeyUp;
            this.MouseClick += PlaneGame_MouseClick;
            //this.MouseMove += PlaneGame_MouseMove;
        }

        //private void PlaneGame_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (player == null) return;
        //    player.Update(e);
        //}

        private void PlaneGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (player == null) return;
            if (e.Button==MouseButtons.Left)
                player.Fire();
            if (e.Button == MouseButtons.Right)
                player.Boom();
            this.Refresh();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            paintEventArgs = e;
            Init_Player(e);
            Init_Enemy(e);
        }
        private void Init_Enemy(PaintEventArgs e)
        {

            if (enemys.Count <= 4 && (Util.GetUtilInstance().Random.Next(1, 15) == 1))
            {
                enemys.Add(new Enemy(UTIL.EnemyImg_2, UTIL.EnemyImg_1.Width, UTIL.EnemyImg_1.Height, 10, Util.GetUtilInstance().Random.Next(0, Util.Panel_width), 0));
            }
            for (int i = 0; i < enemys.Count; i++)
            {
                Enemy ee = enemys[i];
                if (ee.Y >= Util.Panel_height)
                {
                    enemys.Remove(ee);
                }
                else
                {
                    ee.Update();
                    ee.Draw(e, player);
                }
            }
        }

        private void Init_Player(PaintEventArgs e)
        {

            if (player == null)
                player = new Player(UTIL.PlayerImg, (Util.Panel_width - UTIL.PlayerImg.Width) / 2, Util.Panel_height - UTIL.PlayerImg.Height, UTIL.PlayerImg.Width, UTIL.PlayerImg.Height);
            player.Draw(e, enemys);

            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            player.Update(e);
            if (e.KeyChar == 'j')
                player.Fire();
            if (e.KeyChar == 'k')
                player.Boom();
            // todo

            this.Refresh();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 'w':
                    if (key_w == false)
                        key_w = true;            
                    break;
                case 's':
                    if (key_s == false)

                        key_s = true;            
                    break;
                case 'a':
                    if (key_a == false)

                        key_a = true;           
                    break;
                case 'd':
                    if (key_d == false)

                        key_d = true;           
                    break;

            }

           player.Move(key_a,key_d,key_s,key_w);
        }

       
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 'w':
                    if (key_w == true)
                        key_w = false;
                    break;
                case 's':
                    if (key_s == true)

                        key_s = false;
                    break;
                case 'a':
                    if (key_a == true)

                        key_a = false;
                    break;
                case 'd':
                    if (key_d == true)

                        key_d = false;
                    break;

            }
            player.Move(key_a, key_d, key_s, key_w);
        }
    }
}
