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
    public partial class 教练_信息通信 : Form
    {
        public 教练_信息通信()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void 教练_学员通信_Load(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "BULK INSERT 教练消息表 FROM 'd:\\information_bulletin.txt' WITH (ROWTERMINATOR = '\n') select * from 教练消息表;";
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
                        textBox5.Text = str;
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


            SqlConnection con1 = new SqlConnection(sqlc);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select *  from  教练_学员消息表", con1);
            DataSet mytb1 = new DataSet();
            sqlDataAdapter1.Fill(mytb1, " 教练_学员消息表");
            dataGridView2.DataSource = mytb1.Tables[" 教练_学员消息表"];


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=DESKTOP-4C0LIDG\\SQLEXPRESS;User Id=KIANA;Pwd=123456;DataBase=驾校管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("update 管理员消息表 set 教练消息='" + textBox1.Text + "' where 用户名='" + 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            MessageBox.Show("发送成功！");
            dt.Close();
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //给学员回复
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统; MultipleActiveResultSets=true;";
            SqlConnection con = new SqlConnection(sqlc);
            if (con.State == ConnectionState.Closed)//连接数据库
            {
                con.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("select *  from  教练_学员消息表  where  用户名 = '" + textBox7.Text + "'", con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断用户是否存在
                {
                    string strsql = "update  教练_学员消息表  set  回复='" + textBox6.Text + "' where  用户名 = '" + textBox7.Text + "'";
                    SqlCommand comm = new SqlCommand(strsql, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                    {
                        MessageBox.Show("回复成功！");
                    }
                    else
                    {
                        MessageBox.Show("回复失败！");
                    }
                    //回复完后清空textBox
                    textBox7.Text = "";
                    textBox6.Text = "";
                    con.Close();
                }
                else
                {
                    MessageBox.Show("该用户名不存在，请更换用户名！");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            教练_信息通信 cs = new 教练_信息通信();
            cs.Show();
        }
    }
}
