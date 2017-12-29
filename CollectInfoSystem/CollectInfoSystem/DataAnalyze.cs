using System;
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
    public partial class DataAnalyze : Form
    {
        private Dictionary<Label, TextBox> plug;

        private List<string> list;
        private int x = 5;
        private int y = 10;
        

        public DataAnalyze(Dictionary<Label, TextBox> plug)
        {
            InitializeComponent();
            this.plug = plug;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.DrawPlug();


        }
       

        private void DrawPlug()
        {

            for (int i = 0; i < plug.Count; i++)
            {
                Label l = plug.ElementAt(i).Key;
                l.Location = new Point(x, y);

                x += l.Width;
                TextBox b = plug.ElementAt(i).Value;
                b.Enabled = false;
                b.Location = new Point(x, y);
                x += b.Width;
                this.Controls.Add(l);
                this.Controls.Add(b);
               
                y += (b.Height + 15);
                x = 5;

            }
        }

        private void AddPlug(string name)
        {
            Label l = new Label
            {
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
