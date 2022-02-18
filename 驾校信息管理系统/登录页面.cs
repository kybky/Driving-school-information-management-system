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
    public partial class 登录页面 : Form
    {
        public static string strname;
        public 登录页面()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            注册页面 注册 = new 注册页面();
            注册.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&textBox2.Text!="")
            {
                if(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                {
                    //提交对比登录信息是否正确
                    string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
                    SqlConnection con = new SqlConnection(sqlc);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string 类别;
                    if (radioButton1.Checked)
                    {
                        类别 = "管理员";
                    }
                    else if (radioButton2.Checked)
                    {
                        类别 = "教练";
                    }
                    else
                    {
                        类别 = "学员";
                    }
                    SqlCommand sqlCommand = new SqlCommand("select *  from  " + 类别 + "_用户名_密码表  where  用户名 = '" + textBox1.Text + "'", con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
                    try
                    {
                        if (sqlDataReader.HasRows)//判断是否有数据
                        {
                            while (sqlDataReader.Read())//循环读取sqlDataReader对象中的数据
                            {
                                string user = (string)sqlDataReader["用户名"];//强制转换不可忘
                                string psw = (string)sqlDataReader["密码"];//强制转换不可忘
                                if (user == textBox1.Text && psw == textBox2.Text)//判断密码是否正确
                                {
                                    strname = textBox1.Text;
                                    switch (类别)//用户名，密码正确的情况下跳转至相应页面
                                    {
                                        case "管理员":
                                            管理员页面 管理员 = new 管理员页面();
                                            管理员.Show();
                                            this.Hide();
                                            break;
                                        case "教练":
                                            教练页面 教练 = new 教练页面();
                                            教练.Show();
                                            this.Hide();
                                            break;
                                        case "学员":
                                            学员页面 学员 = new 学员页面();
                                            学员.Show();
                                            this.Hide();
                                            break;
                                        default: break;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("用户名/密码错误！");
                                }
                            }


                        }
                        else
                        {
                            MessageBox.Show("用户不存在！");
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
                    MessageBox.Show("请选择身份类型！");
                }
            }
            else
            {
                MessageBox.Show("用户名/密码不能为空！");
            }

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
//备份2021/7/7
/*using System;
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
    public partial class 登录页面 : Form
    {
        public 登录页面()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            注册页面 注册 = new 注册页面();
            注册.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //提交对比登录信息是否正确
            string sqlc = "Server=LAPTOP-L73NVBKU;User Id=sa;Pwd=070809@Yang;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string 类别;
            if (radioButton1.Checked)
            {
                类别 = "管理员";
            }
            else if (radioButton2.Checked)
            {
                类别 = "教练";
            }
            else
            {
                类别 = "学员";
            }
            SqlCommand sqlCommand = new SqlCommand("select *  from  " + 类别 + "_用户名_密码表", con);
            //string psw = sqlCommand.ExecuteReader();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断是否有数据
                {
                    while(sqlDataReader.Read())//循环读取sqlDataReader对象中的数据
                    {
                        string user = (string)sqlDataReader["用户名"];//强制转换不可忘
                        string psw = (string)sqlDataReader["密码"];//强制转换不可忘
                        if (user == textBox1.Text && psw == textBox2.Text)//判断密码是否正确
                        {
                            switch (类别)//用户名，密码正确的情况下跳转至相应页面
                            {
                                case "管理员":
                                    管理员页面 管理员 = new 管理员页面();
                                    管理员.Show();
                                    this.Hide();
                                    break;
                                case "教练":
                                    教练页面 教练 = new 教练页面();
                                    教练.Show();
                                    this.Hide();
                                    break;
                                case "学员":
                                    学员页面 学员 = new 学员页面();
                                    学员.Show();
                                    this.Hide();
                                    break;
                                default: break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户名/密码错误！");
                        }
                    }


                }
                else
                {
                    MessageBox.Show("用户不存在！");
                }
            }
            catch(SqlException ex)//捕捉异常数据
            {
                MessageBox.Show(ex.ToString());//输出错误信息
            }
            finally
            {
                sqlDataReader.Close();
                con.Close();
            }

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
*/