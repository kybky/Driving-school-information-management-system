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
    public partial class 账户设置 : Form
    {
        public 账户设置()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //查询自己信息
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("select *  from  管理员表,管理员_用户名_密码表  where  管理员用户名 = '" + 登录页面.strname + "' and 管理员用户名=用户名", con);
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
                        if(sqlDataReader["联系电话"]!=null)
                        {
                            textBox6.Text = (string)sqlDataReader["联系电话"];
                        }
                        if(checkBox1.Checked)
                        {
                            textBox3.UseSystemPasswordChar = false;
                        }
                        else
                        {
                            textBox3.UseSystemPasswordChar = true;
                        }
                        textBox3.Text = (string)sqlDataReader["密码"];
                        textBox7.Text = (string)sqlDataReader["邮箱"];
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
                    textBox3.Text = "";
                    textBox7.Text = "";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void 账户设置_Load(object sender, EventArgs e)
        {
            //查询自己信息
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("select *  from  管理员表,管理员_用户名_密码表  where  管理员用户名 = '" + 登录页面.strname + "' and 管理员用户名=用户名", con);
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
                        if (sqlDataReader["联系电话"] != null)
                        {
                            textBox6.Text = (string)sqlDataReader["联系电话"];
                        }
                        textBox3.Text = (string)sqlDataReader["密码"];
                        textBox7.Text = (string)sqlDataReader["邮箱"];
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
                    textBox3.Text = "";
                    textBox7.Text = "";
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
            //管理员信息更新
            string 管理员姓名 = string.Empty, 性别 = string.Empty, 身份证 = string.Empty, 年龄 = string.Empty, 联系电话 = string.Empty, 密码 = string.Empty, 邮箱 = string.Empty;
            if (textBox2.Text != "")
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
            if (textBox3.Text != "")
            {
                密码 = textBox3.Text;
            }
            if (textBox7.Text != "")
            {
                邮箱 = textBox7.Text;
            }
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "update  管理员表  set  管理员姓名='" + 管理员姓名 + "'," + " 性别='" + 性别 + "'," + "年龄=" + 年龄 + "," + "身份证='" + 身份证 + "'," + "联系电话='" + 联系电话  + "'  where 管理员用户名 = '" + textBox1.Text+ "';update  管理员_用户名_密码表 set  密码='" + 密码 + "'," + "邮箱='" + 邮箱 + "' where 用户名='"+textBox1.Text+"'";
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
            textBox3.Text = "";
            textBox7.Text = "";
            con.Close();
        }
    }
}
