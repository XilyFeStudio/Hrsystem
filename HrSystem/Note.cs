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
    public partial class Note : Form
    {
        public ServerHelper Helper;
        public Note(string Base)
        {
            InitializeComponent();
            Helper = new ServerHelper(Base, ".", @"C:\Users\XJ\Documents\Visual Studio 2013\Projects\HrSystem\HrSystem\bin\Debug\Database1.accdb", "UserName", "sa", "123");
            Break();
        }
        private bool None (ComboBox cb1, TextBox tb1, TextBox tb2)
        {
            if (cb1.Text != "" && tb1.Text != "" && tb2.Text != "")
            { return true; }
            else
            { return false; }
        }
        private void Break()
        {
            string sql = "select [Id], [Time], [Class], [Idea], [Message] from [Note]";
            dataGridView1.DataSource = Helper.BindData(sql).Tables[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (None(comboBox2, textBox1, textBox2))
            {
                string sql = "insert into [Note] ([Time], [Class], [Idea], [Message]) values('{0}', '{1}', '{2}', '{3}')";
                string Sql = String.Format(sql, dateTimePicker2.Text, comboBox2.Text, textBox1.Text, textBox2.Text);
                Helper.Data(Sql);
                Break();
            }
            else
            { 
                MessageBox.Show("请不要输入空字段");
                return; 
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int row = Convert.ToInt32(dataGridView1.CurrentRow.Index);
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[row].Cells[1].Value.ToString());
                comboBox2.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string sql = "select [Id], [Time], [Class], [Idea], [Message] from [Note] where [Time] = '" + dateTimePicker1.Text + "'";
                dataGridView1.DataSource = Helper.BindData(sql).Tables[0];
            }
            else
            {
                if (comboBox1.Text != "")
                {
                    string sql = "select [Id], [Time], [Class], [Idea], [Message] from [Note] where [Class] = '" + comboBox1.Text + "'";
                    dataGridView1.DataSource = Helper.BindData(sql).Tables[0];
                }
                else { MessageBox.Show("主题不允许为空"); return; }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(dataGridView1.CurrentRow.Index);
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string sql = "delete from [Note] where [Id] = " + id + "";
            Helper.Data(sql);
            MessageBox.Show("已成功删除");
            Break();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Break();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (None(comboBox2, textBox1, textBox2))
            {
                int row = Convert.ToInt32(dataGridView1.CurrentRow.Index);
                string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
                string sql = "update [Note] set [Time]='{0}', [Class]='{1}', [Idea]='{2}', [Message]='{3}' where [Id]={4}";
                string Sql = String.Format(sql, dateTimePicker2.Text, comboBox2.Text, textBox1.Text, textBox2.Text, id);
                Helper.Data(Sql);
                Break();
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("请不要输入空字段");
                return;
            }
        }
    }
}
