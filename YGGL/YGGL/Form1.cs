using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace YGGL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string debug_path = System.Environment.CurrentDirectory;
        private  List<Staff> staffs_list = new List<Staff>();
        private int currRows;
       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = File.Open(debug_path+@"\staffs.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            StreamWriter sw = new StreamWriter(fs);
            StreamReader sr = new StreamReader(fs);

             string s = sr.ReadToEnd();


            //staffs_list.Add(new Staff() { Name = "张三", Age = "18", Id = "01", Address = "宝山寺", Tel = "123456", Department = "采购部", Sex = "男" });
            //staffs_list.Add(new Staff() { Name = "李四", Age = "34", Id = "02", Address = "宝山寺", Tel = "133456", Department = "采购部", Sex = "男" });
            //string ss = Serialize<List<Staff>>(staffs_list);
            // sw.Write(ss);


            staffs_list = Deserialize(typeof(List<Staff>), s) as List<Staff>;
            this.dataGridView1.Rows.Add(staffs_list.Count);
            drawTable();
          
            sw.Close();
            fs.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Open(debug_path + @"\staffs.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            Staff s = new Staff(textBox1.Text, textBox2.Text, textBox6.Text, textBox3.Text, textBox7.Text, textBox5.Text, textBox4.Text);
            staffs_list.Add(s);
            this.dataGridView1.Rows.Add(1);
            drawTable();
            fs.SetLength(0);
            string str = Serialize<List<Staff>>(staffs_list);
            //MessageBox.Show(str, "");
            sw.Write(str);     
            sw.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currRows <0 || currRows > staffs_list.Count) return;
            DialogResult res = MessageBox.Show("确定修改该行？", "提示", MessageBoxButtons.OKCancel);
            if (res.Equals(DialogResult.Cancel)) return;
            FileStream fs = File.Open(debug_path + @"\staffs.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            Staff s= staffs_list.ElementAt(currRows);
            s.Name = textBox1.Text;
            s.Sex = textBox2.Text;
            s.Age = textBox6.Text;
            s.Id = textBox3.Text;
            s.Address = textBox7.Text;
            s.Tel = textBox5.Text;
            s.Department = textBox4.Text;
            drawTable();
            fs.SetLength(0);
            string str = Serialize<List<Staff>>(staffs_list);
            sw.Write(str);
            sw.Close();
            fs.Close();
        }

        private void  drawTable() {
            for (int num = 0; num < staffs_list.Count; num++)
            {
                this.dataGridView1.Rows[num].DefaultCellStyle.BackColor = Color.LightBlue;
                this.dataGridView1.Rows[num].DefaultCellStyle.Font = new Font("黑体", 11);
                this.dataGridView1.Rows[num].Height = 20;
                this.dataGridView1.Rows[num].Cells[0].Value = staffs_list[num].Name;

                this.dataGridView1.Rows[num].Cells[1].Value = staffs_list[num].Sex;
                this.dataGridView1.Rows[num].Cells[2].Value = staffs_list[num].Id;
                this.dataGridView1.Rows[num].Cells[3].Value = staffs_list[num].Department;
                this.dataGridView1.Rows[num].Cells[4].Value = staffs_list[num].Tel;
                this.dataGridView1.Rows[num].Cells[5].Value = staffs_list[num].Age;
                this.dataGridView1.Rows[num].Cells[6].Value = staffs_list[num].Address;

            }
        }
 
     
        [Serializable]
        public  class Staff {        
           
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("sex")]
            public string Sex { get; set; }
            [XmlElement("age")]
            public string Age { get; set; }
            [XmlElement("id")]
            public string Id { get; set; }
            [XmlElement("address")]
            public string Address { get; set; }
            [XmlElement("tel")]
            public string Tel { get; set; }
            [XmlElement("department")]
            public string Department { get; set; }
            public Staff() { }
            public Staff(string name, string sex, string age, string id, string address, string tel, string department)
            {
                this.Name = name;
                this.Sex = sex;
                this.Age = age;
                this.Id = id;
                this.Address = address;
                this.Tel = tel;
                this.Department = department;
            }

         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currRows = e.RowIndex;
            if (e.RowIndex <0|| e.RowIndex >= staffs_list.Count) return;
            Staff s = staffs_list.ElementAt(e.RowIndex);
           
            textBox1.Text = s.Name;
            textBox2.Text = s.Sex;
            textBox6.Text = s.Age;
            textBox3.Text = s.Id;
            textBox7.Text = s.Address;
            textBox5.Text = s.Tel;
            textBox4.Text = s.Department;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= staffs_list.Count) return;
            DialogResult res =MessageBox.Show("确定删除该行？", "提示", MessageBoxButtons.OKCancel);
            if (res.Equals(DialogResult.Cancel)) return;
            FileStream fs = File.Open(debug_path + @"\staffs.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            this.staffs_list.RemoveAt(e.RowIndex);
            this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            fs.SetLength(0);
            string str = Serialize<List<Staff>>(staffs_list);
            sw.Write(str);
            sw.Close();
            fs.Close();
        }


        //xml
     
        public static string Serialize<T>(T t)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(t.GetType());
                xz.Serialize(sw, t);
                return sw.ToString();
            }
        }

       
        public static object Deserialize(Type type, string s)
        {
            using (StringReader sr = new StringReader(s))
            {
                XmlSerializer xz = new XmlSerializer(type);
                return xz.Deserialize(sr);
            }
        }

      
    }



}
