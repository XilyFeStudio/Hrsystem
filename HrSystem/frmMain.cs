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
    public partial class frmMain : Form
    {
        public string Username;
        private bool open = false;
        public string DatabaseType = "Access";
        public string Competence;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tsl1.Text = "用户名： " + Username;
            tsl2.Text = "登入时间： " + System.DateTime.Now.ToString();
            tsl3.Text = "权限: " + Competence;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resault = MessageBox.Show("是否关闭？", "", MessageBoxButtons.OKCancel);
            if (resault == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
        }

        private void 人事管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee form = new Employee();
            form.Username = Username;
            form.Show();
            return;
        }

        private void 备忘记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note form = new Note(DatabaseType);
            form.Show();
            return;
        }

        private void 系统管理ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!open)
            {
                this.Size = new Size(this.Size.Width + 194, this.Size.Height);
                treeView1.Visible = true;
                open = true;
            }
            else
            {
                this.Size = new Size(this.Size.Width - 194, this.Size.Height);
                treeView1.Visible = false;
                open = false;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "设置")
            {
                Admin admin = new Admin(DatabaseType);
                admin.Show();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            退出ToolStripMenuItem_Click(sender, e);
        }
    }
}
