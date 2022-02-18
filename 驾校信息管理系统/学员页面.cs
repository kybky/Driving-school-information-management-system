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
    public partial class 学员页面 : Form
    {
        public 学员页面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //返回登录页面
            登录页面 登录 = new 登录页面();
            登录.Show();
            this.Hide();
        }

        private void 学员页面_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "登录用户：" + 登录页面.strname; //显示登录用户
            toolStripStatusLabel2.Text = "  ||   登录时间：" + DateTime.Now.ToString();
        }

        private void button_yuyue_Click(object sender, EventArgs e)
        {
            预约练车页面 form1 = new 预约练车页面();
            form1.Show();
        }

        private void button_geren_Click(object sender, EventArgs e)
        {
            学员个人信息页面 form1 = new 学员个人信息页面();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            驾考成绩页面 form1 = new 驾考成绩页面();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tiba.jsyks.com/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select count(用户名) as A from 签到表 where 日期='" + monthCalendar1.SelectionStart.ToString() + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            if (dt.Read())
            {
                string x = dt["A"].ToString();
                dt.Close();
                if (x == "1")
                {
                    MessageBox.Show("已完成签到，勿重复签到。");
                }
                else
                {
                    sqlCommand = new SqlCommand("insert into 签到表 values ('" + 登录页面.strname + "','" + monthCalendar1.SelectionStart.ToString() + "')", con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("签到成功！");
                    dt.Close();
                    con.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            消息页面 form1 = new 消息页面();
            form1.Show();
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    string sqlc = "Server=DESKTOP-4C0LIDG\\SQLEXPRESS;User Id=KIANA;Pwd=123456;DataBase=驾校管理系统";
        //    SqlConnection con = new SqlConnection(sqlc);
        //    con.Open();
        //    SqlCommand sqlCommand = new SqlCommand("select 学员姓名  from 学员表  where  学员用户名 = '" + 登录页面.strname + "'", con);
        //    SqlDataReader dt = sqlCommand.ExecuteReader();
        //    if (dt.Read())
        //    {
        //        MessageBox.Show(dt["学员姓名"].ToString());
        //    }
        //}
    }
}
