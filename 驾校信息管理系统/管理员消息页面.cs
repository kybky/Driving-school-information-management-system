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
    public partial class 管理员消息页面 : Form
    {
        public 管理员消息页面()
        {
            InitializeComponent();
        }

        private void 管理员消息页面_Load(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select *  from  管理员消息表 where 管理员消息表.用户名 in (select 教练用户名 from  教练表)", con);
            DataSet mytb = new DataSet();
            sqlDataAdapter.Fill(mytb, "教练信息表");
            dataGridView1.DataSource = mytb.Tables["教练信息表"];
            

            SqlConnection con1 = new SqlConnection(sqlc);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select *  from  管理员消息表 where 管理员消息表.用户名 in (select 学员用户名 from  学员表)", con1);
            DataSet mytb1 = new DataSet();
            sqlDataAdapter1.Fill(mytb1, "学员信息表");
            dataGridView2.DataSource = mytb1.Tables["学员信息表"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //给教练回复
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统; MultipleActiveResultSets =true;";
            SqlConnection con = new SqlConnection(sqlc);
            if (con.State == ConnectionState.Closed)//连接数据库
            {
                con.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("select *  from  管理员消息表  where  用户名 = '" + textBox1.Text + "'", con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断用户是否存在
                {
                    string strsql = "update  管理员消息表  set  回复='" + textBox2.Text + "' where  用户名 = '" + textBox1.Text + "'";
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
                    textBox1.Text = "";
                    textBox2.Text = "";
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
            //给学员回复
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统; MultipleActiveResultSets=true;";
            SqlConnection con = new SqlConnection(sqlc);
            if (con.State == ConnectionState.Closed)//连接数据库
            {
                con.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("select *  from  管理员消息表  where  用户名 = '" + textBox3.Text + "'", con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断用户是否存在
                {
                    string strsql = "update  管理员消息表  set  回复='" + textBox4.Text + "' where  用户名 = '" + textBox3.Text + "'";
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
                    textBox3.Text = "";
                    textBox4.Text = "";
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
    }
}
