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
    public partial class 消息页面 : Form
    {
        public 消息页面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "BULK INSERT 学员消息表 FROM 'd:\\information_bulletin.txt' WITH (ROWTERMINATOR = '\n') select * from 学员消息表;";
            SqlCommand comm = new SqlCommand(strsql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader sqlDataReader = comm.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断是否有数据
                {
                    while (sqlDataReader.Read())//循环读取sqlDataReader对象中的数据
                    {
                        string str = (string)sqlDataReader["data"];//强制转换不可忘
                        textBox1.Text = str;
                    }

                }
                else
                {
                    MessageBox.Show("无信息可读！");
                }
            }
            catch (SqlException ex)//捕捉异常数据
            {
                MessageBox.Show(ex.ToString());//输出错误信息
            }
            finally
            {
                sqlDataReader.Close();
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select 回复 from 管理员消息表 where 用户名='" + 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            if (dt.Read())
            {
                textBox3.Text = dt["回复"].ToString();
            }
            dt.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("update 管理员消息表 set 消息='" +textBox2.Text+"' where 用户名='"+ 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            MessageBox.Show("发送成功！");
            dt.Close();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select 回复 from 教练_学员消息表 where 用户名='" + 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            if (dt.Read())
            {
                textBox4.Text = dt["回复"].ToString();
            }
            dt.Close();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("update 教练_学员消息表 set 消息='" + textBox5.Text + "' where 用户名='" + 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            MessageBox.Show("发送成功！");
            dt.Close();
            con.Close();
        }
    }
}
