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
    public partial class Employee : Form
    {
        public ServerHelper Helper;
        public string Username;
        public string Competence;
        public string DatabaseType = "Access";
        public Employee()
        {
            InitializeComponent();
            Helper = new ServerHelper(DatabaseType, ".", @"C:\Users\XJ\Documents\Visual Studio 2013\Projects\HrSystem\HrSystem\bin\Debug\Database1.accdb", "UserName", "sa", "123");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resault = MessageBox.Show("是否关闭？", "", MessageBoxButtons.OKCancel);
            if (resault == DialogResult.OK)
            {
                frmMain form = new frmMain();
                form.Username = Username;
                form.Show();
                this.Close();
            }
        }
        private void Break()
        {
            string sql = "select Id, Name, Age, Sex, Time, Dept, Telephone from Personal";
            dataGridView1.DataSource = Helper.BindData(sql).Tables[0];
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            Break();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string Tree = e.Node.Text;
            if (Tree == "所有部门")
            {
                string sql = "select Id, Name from Personal";
                dataGridView1.DataSource = Helper.BindData(sql).Tables[0];
            }
            else
            {
                string sql = "select Id, Name from Personal where Dept='" + Tree + "'";
                dataGridView1.DataSource = Helper.BindData(sql).Tables[0];
            }
        }



        private void Employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain form = new frmMain();
            form.Show();
        }

    }
}
