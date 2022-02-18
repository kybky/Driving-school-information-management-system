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
    public partial class 注册页面 : Form
    {
        public 注册页面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //提交注册信息
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    if(radioButton1.Checked||radioButton2.Checked)
                    {
                        string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
                        SqlConnection con = new SqlConnection(sqlc);
                        if (con.State == ConnectionState.Closed)//连接数据库
                        {
                            con.Open();
                        }
                        string str1;
                        if (radioButton1.Checked)//只能注册教练和学员，管理员需已有账号分配
                        {
                            str1 = "教练";
                        }
                        else
                        {
                            str1 = "学员";
                        }
                        SqlCommand sqlCommand = new SqlCommand("select *  from  " + str1 + "_用户名_密码表  where  用户名 = '" + textBox1.Text + "'", con);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
                        try
                        {
                            if (!sqlDataReader.HasRows)//判断用户是否已存在
                            {
                                string strsql = "insert into " + str1 + "_用户名_密码表(用户名, 密码, 邮箱) values( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + comboBox1.Text + "');";
                                SqlCommand comm = new SqlCommand(strsql, con);
                                if (con.State == ConnectionState.Closed)
                                {
                                    con.Open();
                                }
                                if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                                {
                                    MessageBox.Show("注册成功,请返回登录！");
                                }
                                else
                                {
                                    MessageBox.Show("注册失败，请重新注册！");
                                }
                                //添加完后清空textBox
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                comboBox1.Text = "";
                                con.Close();
                            }
                            else
                            {
                                MessageBox.Show("该用户名已存在，请更换其他用户名注册！");
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
                    else
                    {
                        MessageBox.Show("请选择注册类型！");
                    }
                }
                else
                {
                    MessageBox.Show("两次填写的密码不一致，请重新填写！");
                }
            }
            else
            {
                MessageBox.Show("信息填写不完整，请补全信息！");
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //返回登录页面
            登录页面 登录 = new 登录页面();
            登录.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
