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
    public partial class 添加教练页面 : Form
    {
        public 添加教练页面()
        {
            InitializeComponent();
        }

        private void 添加教练页面_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //添加教练
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "insert into 教练表(教练用户名, 教练姓名, 性别, 年龄, 身份证,教龄,可用车辆,可用场地,管理员用户名,联系电话) values( '" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "'," + Convert.ToInt32(textBox4.Text) + ",'" + textBox5.Text + "'," + Convert.ToInt32(textBox6.Text) + ",'" + textBox7.Text + "','" + textBox8.Text + "','" + 登录页面.strname + "','" + textBox9.Text + "');";
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
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
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
            SqlCommand sqlCommand = new SqlCommand("select *  from  教练表  where  教练用户名 = '" + textBox1.Text + "'", con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断是否有数据
                {
                    while (sqlDataReader.Read())//循环读取sqlDataReader对象中的数据
                    {
                        textBox1.Text = (string)sqlDataReader["教练用户名"];//强制转换不可忘
                        textBox2.Text = (string)sqlDataReader["教练姓名"];
                        comboBox1.Text = (string)sqlDataReader["性别"];
                        textBox4.Text = Convert.ToString(sqlDataReader["年龄"]);
                        textBox5.Text = (string)sqlDataReader["身份证"];
                        textBox6.Text = Convert.ToString(sqlDataReader["教龄"]);
                        textBox7.Text = (string)sqlDataReader["可用车辆"];
                        textBox8.Text = (string)sqlDataReader["可用场地"];
                        textBox9.Text = (string)sqlDataReader["联系电话"];

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
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
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
            string 教练姓名 = string.Empty, 性别 = string.Empty, 身份证 = string.Empty, 年龄 = string.Empty, 教龄 = string.Empty, 可用车辆 = string.Empty, 可用场地 = string.Empty, 联系电话 = string.Empty;
            if (textBox2.Text != "")
            {
                教练姓名 = textBox2.Text;
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
                教龄 = textBox6.Text;
            }
            if (textBox7.Text != "")
            {
                可用车辆 = textBox7.Text;
            }

            if (textBox8.Text != "")
            {
                可用场地 = textBox8.Text;
            }
            if (textBox9.Text != "")
            {
                联系电话 = textBox9.Text;
            }
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "update  教练表  set  教练姓名='" + 教练姓名 + "'," + " 性别='" + 性别 + "'," + "年龄=" + 年龄 + "," + "身份证='" + 身份证 + "'," + "教龄='" + 教龄 + "'," + "可用场地='" + 可用场地 + "'," + "可用车辆='" + 可用车辆 + "'," + "联系电话='" + 联系电话 + "'  where 教练用户名 = '" + textBox1.Text + "'";
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
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //删除学员
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            SqlCommand sqlCommand = new SqlCommand("select *  from  教练表  where  教练用户名 = '" + textBox1.Text + "'", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断是否有数据
                {
                    string strsql = "DELETE FROM 教练表 WHERE 教练用户名 = '" + textBox1.Text + "';" + "DELETE FROM 教练_用户名_密码表 WHERE 用户名 = '" + textBox1.Text + "'";
                    SqlCommand comm = new SqlCommand(strsql, con);
                    sqlDataReader.Close();
                    if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    //更新后清空textBox
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    comboBox1.Text = "";
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
    }
}
