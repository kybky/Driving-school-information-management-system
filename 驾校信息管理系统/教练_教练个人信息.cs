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
    public partial class 教练_教练个人信息 : Form
    {
        public 教练_教练个人信息()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("update 教练表  set  教练用户名 = '" + textBox1.Text + "',教练姓名='" + textBox2.Text + "',性别='" + textBox3.Text + "',年龄='" + textBox4.Text + "',联系电话='" + textBox5.Text + "',身份证='" + textBox6.Text + "' where 教练用户名='" + 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select *  from 教练表  where  教练用户名 = '" + 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            if (dt.Read())
            {
                textBox1.Text = dt["教练用户名"].ToString();
                textBox2.Text = dt["教练姓名"].ToString();
                textBox3.Text = dt["性别"].ToString();
                textBox4.Text = dt["年龄"].ToString();
                textBox5.Text = dt["联系电话"].ToString();
                textBox6.Text = dt["身份证"].ToString();
                textBox7.Text = dt["教龄"].ToString();
                textBox8.Text = dt["可用车辆"].ToString();
                textBox9.Text = dt["可用场地"].ToString();
            }
            dt.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            教练页面 frm1 = new 教练页面();
            frm1.Show();
            this.Hide();
        }
    }
}
