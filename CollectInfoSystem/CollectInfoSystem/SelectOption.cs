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
    public partial class SelectOption : Form
    {
        public SelectOption()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
          
            if (this.checkBox1.Checked) {
                list.Add(this.checkBox1.Text);
            }
            if (this.checkBox2.Checked)
            {
                list.Add(this.checkBox2.Text);
            }
            if (this.checkBox3.Checked)
            {
                list.Add(this.checkBox3.Text);
            }
            if (this.checkBox4.Checked)
            {
                list.Add(this.checkBox4.Text);
            }
            if (this.checkBox5.Checked)
            {
                list.Add(this.checkBox5.Text);
            }
            if (this.checkBox6.Checked)
            {
                list.Add(this.checkBox6.Text);
            }
            if (this.checkBox7.Checked)
            {
                list.Add(this.checkBox7.Text);
            }
            if (this.checkBox8.Checked)
            {
                list.Add(this.checkBox8.Text);
            }
            this.Hide();
            new Collect(list).ShowDialog();
        }
    }
}
