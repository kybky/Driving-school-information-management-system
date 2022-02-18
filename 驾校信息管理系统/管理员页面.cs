using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 驾校信息管理系统
{
    public partial class 管理员页面 : Form
    {
        public 管理员页面()
        {
            InitializeComponent();
        }

        private void 管理员页面_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "登录用户：" + 登录页面.strname; //显示登录用户
            toolStripStatusLabel2.Text = "  ||   登录时间：" + DateTime.Now.ToString();
            label1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void 添加管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            dataGridView1.Visible = false;

            添加管理员页面 添加管理员 = new 添加管理员页面();
            添加管理员.MdiParent = this;
            添加管理员.StartPosition = FormStartPosition.CenterScreen;
            添加管理员.Show(); 
            //this.Hide();

        }

        private void 添加教练ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            dataGridView1.Visible = false;

            添加教练页面 添加教练 = new 添加教练页面();
            添加教练.MdiParent = this;
            //this.Hide();
            添加教练.Show();
        }

        private void 添加学员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            dataGridView1.Visible = false;

            添加学员页面 添加学员 = new 添加学员页面();
            添加学员.MdiParent = this;
            //this.Hide();
            添加学员.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //返回登录页面
            登录页面 登录 = new 登录页面();
            登录.Show();
            this.Hide();
        }

        private void 退出账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //返回登录页面
            登录页面 登录 = new 登录页面();
            登录.Show();
            this.Hide();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            dataGridView1.Visible = false;

            账户设置 账户设置页面 = new 账户设置();
            账户设置页面.MdiParent = this;
            账户设置页面.Show();

        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            dataGridView1.Visible = false;
            System.Diagnostics.Process.Start("chrome.exe", "https://www.ujs.edu.cn/");
        }

        private void 检查更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            dataGridView1.Visible = false;
            MessageBox.Show("当前已是最新版本！");
        }

        private void 查询管理员基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            dataGridView1.Visible = true;
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select *  from  管理员表", con);
            DataSet mytb = new DataSet();
            sqlDataAdapter.Fill(mytb, "管理员表");
            dataGridView1.DataSource = mytb.Tables["管理员表"];
            label1.Text = "管理员表基本信息";
        }

        private void 查询教练信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            dataGridView1.Visible = true;
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select *  from  教练表", con);
            DataSet mytb = new DataSet();
            sqlDataAdapter.Fill(mytb, "教练表");
            dataGridView1.DataSource = mytb.Tables["教练表"];
            label1.Text = "教练表基本信息";

        }

        private void 查询学员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            label1.Visible = true;
            dataGridView1.Visible = true;
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select *  from  学员表", con);
            DataSet mytb = new DataSet();
            sqlDataAdapter.Fill(mytb, "学员表");
            dataGridView1.DataSource = mytb.Tables["学员表"];
            label1.Text = "学员表基本信息";
        }

        private void 公告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            dataGridView1.Visible = false;
            公告页面 信息公告 = new 公告页面();
            信息公告.MdiParent = this;
            信息公告.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 我的消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理员消息页面 管理员消息 = new 管理员消息页面();
            管理员消息.MdiParent = this;
            管理员消息.Show();
        }

        private void 请假信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            dataGridView1.Visible = true;
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select *  from  教练请假表", con);
            DataSet mytb = new DataSet();
            sqlDataAdapter.Fill(mytb, "教练请假表");
            dataGridView1.DataSource = mytb.Tables["教练请假表"];
            label1.Text = "教练请假表基本信息";
        }
    }
}
