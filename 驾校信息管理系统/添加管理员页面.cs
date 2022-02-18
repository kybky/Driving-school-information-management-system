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
    public partial class 添加管理员页面 : Form
    {
        public 添加管理员页面()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //管理员信息更新
            string 管理员姓名 = string.Empty, 性别 = string.Empty, 身份证 = string.Empty, 年龄 = string.Empty, 联系电话 = string.Empty;
            if(textBox2.Text!="")
            {
                管理员姓名 = textBox2.Text;
            }
            if (comboBox1.Text != "")
            {
                性别 = comboBox1.Text;
            }
            if (textBox4.Text != "")
            {
                年龄 = textBox4.Text;
            }
            if (textBox5.Text != "")
            {
                身份证 = textBox5.Text;
            }
            if (textBox6.Text != "")
            {
                联系电话 = textBox6.Text;
            }
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "update  管理员表  set  管理员姓名='" + 管理员姓名 + "'," + " 性别='" + 性别 + "'," + "年龄=" + 年龄 + "," + "身份证='" + 身份证 + "',"  + "联系电话='" + 联系电话 + "'  where 管理员用户名 = '" + textBox1.Text + "'";
            SqlCommand comm = new SqlCommand(strsql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
            {
                MessageBox.Show("修改成功！");
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
            //添加完后清空textBox
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //管理员信息添加
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "insert into 管理员表(管理员用户名, 管理员姓名, 性别, 年龄, 身份证,联系电话) values( '" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "'," + Convert.ToInt32(textBox4.Text) + ",'" + textBox5.Text + "','" + textBox6.Text + "');";
            SqlCommand comm = new SqlCommand(strsql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
            {
                MessageBox.Show("添加成功！"); 
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
            //添加完后清空textBox
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //查询某一个管理员信息
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("select *  from  管理员表  where  管理员用户名 = '" + textBox1.Text + "'", con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断是否有数据
                {
                    while (sqlDataReader.Read())//循环读取sqlDataReader对象中的数据
                    {
                        textBox1.Text = (string)sqlDataReader["管理员用户名"];//强制转换不可忘
                        textBox2.Text = (string)sqlDataReader["管理员姓名"];
                        comboBox1.Text = (string)sqlDataReader["性别"];
                        textBox4.Text = Convert.ToString(sqlDataReader["年龄"]);
                        textBox5.Text = (string)sqlDataReader["身份证"];
                        textBox6.Text = (string)sqlDataReader["联系电话"];
                    }
                }
                else
                {
                    MessageBox.Show("用户不存在！");
                    textBox1.Text = "";//强制转换不可忘
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
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
