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
    public partial class 教练页面 : Form
    {
        public 教练页面()
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

        private void 教练页面_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "登录用户：" + 登录页面.strname; //显示登录用户
            toolStripStatusLabel2.Text = "  ||   登录时间：" + DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)  //进入教练个人信息
        {
            教练_教练个人信息 个人信息 = new 教练_教练个人信息();
            个人信息.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)  //进入学员个人信息
        {
            教练_学员信息 学员信息 = new 教练_学员信息();
            学员信息.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)  //对学员进行信息通知及接收学员消息
        {
            教练_信息通信 学员通信 = new 教练_信息通信();
            学员通信.Show();
        }

        private void button5_Click(object sender, EventArgs e)  //进入请假页面
        {
            教练_请假申报 请假申报 = new 教练_请假申报();
            请假申报.Show();

        }

        private void button6_Click(object sender, EventArgs e)  //签到按钮
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }
    }
}
