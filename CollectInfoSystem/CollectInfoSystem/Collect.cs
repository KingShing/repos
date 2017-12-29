using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectInfoSystem
{
    public partial class Collect : Form
    {
        private List<string> list;
        private int x = 5;
        private int y = 10;
        private Dictionary<Label, TextBox> plug = new Dictionary<Label, TextBox>();
        public Collect(List<string> l)
        {
            InitializeComponent();
            this.list = l;
        }

        private void Collect_Load(object sender, EventArgs e)
        {         
            this.InitData();
            this.DrawPlug();
            this.DrawButton("提交");
        }
        public void  DrawButton(string s) {
            Button b = new Button();
                b.Click += B_Click;
                b.Text = s;
               b.Location = new Point(this.ClientRectangle.Width/2-b.Width/2,this.ClientRectangle.Height-b.Height);
            this.Controls.Add(b);
        }

        private void B_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DataAnalyze(plug).ShowDialog();
        }

        public void InitData()
        {
            foreach (string s in list) {
                this.AddPlug(s);
            }     
        }

        private  void DrawPlug()
        {
            
                for (int i = 0; i < plug.Count; i++)
                {
                    Label l = plug.ElementAt(i).Key;
                    l.Location = new Point(x, y);
               
                    x += l.Width;
                    TextBox b = plug.ElementAt(i).Value;
               
                        b.Location = new Point(x, y);
                        x += b.Width;
                        this.Controls.Add(l);
                        this.Controls.Add(b);
                        y += (b.Height + 15); x = 5;
              
            }
        }

        private void AddPlug(string name) {
            Label l = new Label {
                Name = "lable_" + name,
                Text = name,
                Width = 80,
                Height = 30,
            };
            TextBox b = new TextBox
            {
                Name = "TextBox_" + name,
                Width = 100,
                Height = 30,
            };
            plug.Add(l, b);
        }
    }
}
