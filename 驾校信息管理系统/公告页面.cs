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
using System.IO;

namespace 驾校信息管理系统
{
    public partial class 公告页面 : Form
    {
        public 公告页面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            //openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    textBox1.Text = "";
            //    StreamReader sr = new StreamReader(openFileDialog1.FileName);
            //    textBox1.Text= sr.ReadToEnd();
            //    sr.Close();
            //}
            //教练信息编辑/读取 
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

        private void 公告页面_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.ReadOnly = true;
            textBox1.Font = new Font("宋体", 12, FontStyle.Bold);

            textBox2.Multiline = true;
            textBox2.ReadOnly = true;
            textBox2.Font = new Font("宋体", 12, FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            //文件法
            //saveFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            //if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            //{
            //    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, true);
            //    sw.WriteLine(textBox1.Text);
            //    sw.Close();
            //}
            //教练信息发布go \n sp_configure 'show advanced options' ,1 \n reconfigure \n go \n sp_configure  'xp_cmdshell',1 \n reconfigure \n go \n 
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "exec xp_cmdshell 'echo " + textBox1.Text + "> d:\\information_bulletin.txt'";
            
            SqlCommand comm = new SqlCommand(strsql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
            {
                MessageBox.Show("发布成功！");
            }
            else
            {
                MessageBox.Show("发布失败！");
            }
            textBox1.ReadOnly = true;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            //学员信息编辑/读取 
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "BULK INSERT 学员消息表 FROM 'd:\\information_bulletin1.txt'  select * from 学员消息表;";
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
                        textBox2.Text = str;
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            //学员信息发布
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            string strsql = "exec xp_cmdshell 'echo " + textBox2.Text + "> d:\\information_bulletin1.txt'";
            
            SqlCommand comm = new SqlCommand(strsql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
            {
                MessageBox.Show("发布成功！");
            }
            else
            {
                MessageBox.Show("发布失败！");
            }
            textBox1.ReadOnly = true;
            con.Close();
        }
    }
}
