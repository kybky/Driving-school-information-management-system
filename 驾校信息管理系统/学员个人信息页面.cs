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
    public partial class 学员个人信息页面 : Form
    {
        public 学员个人信息页面()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("update 学员表  set  学员姓名 = '" + textBox1.Text + "',性别='"+textBox2.Text+"',年龄='"+textBox3.Text+"',身份证='"+textBox4.Text+"',联系电话='"+textBox13.Text+"' where 学员用户名='"+登录页面.strname+"'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Text = "1";
            //string sqlc = "Server=DESKTOP-4C0LIDG\\SQLEXPRESS;User Id=KIANA;Pwd=123456;DataBase=驾校管理系统";
            //SqlConnection con = new SqlConnection(sqlc);
            //con.Open();
            //SqlCommand sqlCommand = new SqlCommand("select 姓名  from 学员表  where  学员用户名 = '" + 登录页面.strname + "'", con);

            ////SqlCommand sqlCommand = new SqlCommand("select 学员姓名 from 学员表 where 学员用户名='" + 登录页面.strname + "'");
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //if(sqlDataReader.Read())
            //{
            //    textBox1.Text = sqlDataReader["学员姓名"].ToString();
            //}
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select *  from 学员表  where  学员用户名 = '" + 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            if (dt.Read())
            {
                textBox1.Text = dt["学员姓名"].ToString();
                textBox2.Text = dt["性别"].ToString();
                textBox3.Text = dt["年龄"].ToString();
                textBox4.Text = dt["身份证"].ToString();
                textBox5.Text = dt["报考类型"].ToString();
                textBox6.Text = dt["报名时间"].ToString();
                textBox7.Text = dt["到期时间"].ToString();
                textBox8.Text = dt["学车时长"].ToString();
                textBox9.Text = dt["已考科目"].ToString();
                textBox10.Text = dt["未考科目"].ToString();
                textBox13.Text = dt["联系电话"].ToString();
            }
            dt.Close();
            sqlCommand = new SqlCommand("select *  from 教练表  where  教练用户名 in (select 教练用户名 from 学员表 where 学员用户名= '" + 登录页面.strname + "')", con);
            SqlDataReader dt1 = sqlCommand.ExecuteReader();
            if (dt1.Read())
            {
                textBox11.Text = dt1["教练姓名"].ToString();
                textBox12.Text = dt1["联系电话"].ToString();
                dt1.Close();
                con.Close();
            }
        }
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    string sqlc = "Server=DESKTOP-4C0LIDG\\SQLEXPRESS;User Id=KIANA;Pwd=123456;DataBase=驾校管理系统";
        //    SqlConnection con = new SqlConnection(sqlc);
        //    con.Open();
        //    SqlCommand sqlCommand = new SqlCommand("select *  from 学员表  where  学员用户名 = '" + 登录页面.strname + "'", con);
        //    SqlDataReader dt = sqlCommand.ExecuteReader();
        //    if (dt.Read())
        //    {
        //        textBox1.Text = dt["学员姓名"].ToString();
        //        textBox2.Text = dt["性别"].ToString();
        //        textBox3.Text = dt["年龄"].ToString();
        //        textBox4.Text = dt["身份证号"].ToString();
        //        textBox5.Text = dt["报考类型"].ToString();
        //        textBox6.Text = dt["报名时间"].ToString();
        //        textBox7.Text = dt["到期时间"].ToString();
        //        textBox8.Text = dt["学车时长"].ToString();
        //        textBox9.Text = dt["已考科目"].ToString();
        //        textBox10.Text = dt["未考科目"].ToString();

        //    }
        //    dt.Close();
        //    sqlCommand = new SqlCommand("select *  from 教练表  where  教练用户名 in (select 教练用户名 from 学员表 where 学员用户名= '" + 登录页面.strname + "')", con);
        //    SqlDataReader dt1 = sqlCommand.ExecuteReader();
        //    if (dt1.Read())
        //    {
        //        textBox11.Text = dt1["教练姓名"].ToString();
        //        textBox12.Text = dt1["联系方式"].ToString();
        //        dt1.Close();
        //        con.Close();
        //    }
        //}
    }
}