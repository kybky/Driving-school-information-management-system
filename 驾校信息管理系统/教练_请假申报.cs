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
    public partial class 教练_请假申报 : Form
    {
        public 教练_请假申报()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //将选择的日期显示在文本框中
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            //SqlConnection con = new SqlConnection(sqlc);
            //con.Open();
            //string str1;
            //SqlCommand sqlCommand = new SqlCommand("select 教练姓名  from  教练表  where  教练用户名 = '" + 登录页面.strname + "'", con);
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            //if(sqlDataReader.Read())
            //{
            //    str1 = sqlDataReader["教练姓名"].ToString();
            //    sqlDataReader.Close();
            //    string strsql = "insert into 教练请假表(教练用户名, 教练姓名, 请假日期) values( '" + 登录页面.strname + "','" + str1 + "','" + monthCalendar1.SelectionStart.ToString() + "')";
            //    SqlCommand comm = new SqlCommand(strsql, con);
            //    if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
            //    {
            //        MessageBox.Show("请假成功！");
            //    }
            //}
            //con.Close();

            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select count(教练用户名) as A from 教练请假表 where 请假日期='" + monthCalendar1.SelectionStart.ToString() + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            if (dt.Read())
            {
                string x = dt["A"].ToString();
                dt.Close();
                if (x == "1")
                {
                    MessageBox.Show("当天已申请休假，勿重复申请。");
                }
                else
                {
                    sqlCommand = new SqlCommand("select 教练姓名  from  教练表  where  教练用户名 = '" + 登录页面.strname + "'", con);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if(sqlDataReader.Read())
                    {
                        string str = sqlDataReader["教练姓名"].ToString();
                        sqlDataReader.Close();
                        sqlCommand = new SqlCommand("insert into 教练请假表 values ('" + 登录页面.strname + "','"+str +"','"+ monthCalendar1.SelectionStart.ToString() + "')", con);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("申请成功！");
                        con.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            教练页面 frm1 = new 教练页面();
            frm1.Show();
            this.Hide();
        }
    }
}
