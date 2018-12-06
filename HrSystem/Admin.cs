using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrSystem
{
    public partial class Admin : Form
    {
        public ServerHelper Helper;
        public Admin(string DatabaseType)
        {
            InitializeComponent();
            Helper = new ServerHelper(DatabaseType, ".", @"C:\Users\XJ\Documents\Visual Studio 2013\Projects\HrSystem\HrSystem\bin\Debug\Database1.accdb", "UserName", "sa", "123");
            Rebuild();
        }
        private void Rebuild()
        {dataGridView1.DataSource = Helper.BindData("select * from UserName").Tables[0];}

        private void Admin_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "管理员数量: " + Helper.Line("UserName").ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Str = "insert into [UserName] ([Sa], [Username], [Password], [Competence]) values('{0}', '{1}', '{2}', '{3}')";
            string StrData = String.Format(Str, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text);
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("导入信息不得为空!");
                return;
            }
            Helper.Data(StrData);
            Rebuild();
            MessageBox.Show("导入成功!");
            
        }

    }
}
