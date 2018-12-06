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
    public partial class Login : Form
    {
        public ServerHelper Helper;
        public string DatabaseType = "Access";
        public Login()
        {
            InitializeComponent();
            Helper = new ServerHelper(DatabaseType, ".", @"C:\Users\XJ\Documents\Visual Studio 2013\Projects\HrSystem\HrSystem\bin\Debug\Database1.accdb", "UserName", "sa", "123");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resault = MessageBox.Show("是否关闭？", "", MessageBoxButtons.OKCancel);
            if (resault == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "" || textBox2.Text == "")
            //{
            //    MessageBox.Show("用户名或密码不得为空");
            //    return;
            //}
            //for (int i = 0; i != Helper.SelectUsername().Count; i++)
            //{
            //    if (textBox1 .Text== Helper.SelectUsername()[i].UserName)
            //    {
            //        if (textBox2.Text == Helper.SelectUsername()[i].PassWord)
            //        {
            //            MessageBox.Show("登录成功!");
            //            this.Hide();
            //            frmMain form = new frmMain();
            //            form.Username = Helper.SelectUsername()[i].UserName;
            //            form.Competence = Helper.SelectUsername()[i].Competence;
            //            form.Show();
            //            return;
            //        }
            //    }
            //}
            //MessageBox.Show("登录失败！ 用户名不存在或密码不正确！");
            frmMain form = new frmMain();
            form.Show();
            return;
        }
    }
}
