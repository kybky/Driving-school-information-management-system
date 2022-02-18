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
    public partial class 教练_学员信息 : Form
    {
        public 教练_学员信息()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            教练页面 frm1 = new 教练页面();
            frm1.Show();
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)  //对本教练学员进行信息查询
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select *  from 学员表  where 学员姓名 = @学员姓名 AND  教练用户名 = '" + 登录页面.strname + "'", con);
            sqlCommand.Parameters.AddWithValue("@学员姓名", this.textBox1.Text);
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

            }
            else { MessageBox.Show("输入的学员不存在/无权访问其他教练的学员"); }
            con.Close();
            dt.Close();
        }

       

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            //创建数据库连接类的对象
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            //执行con对象的函数，返回一个SqlCommand类型的对象
            SqlCommand cmd = con.CreateCommand();
            //把输入的数据拼接成sql语句，并交给cmd对象
            cmd.CommandText = "select 学员姓名,联系电话 from 学员表 where 教练用户名 = '" + 登录页面.strname + "'";

            //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
            SqlDataReader dr = cmd.ExecuteReader();
            //用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr
            while (dr.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                ListViewItem lt = new ListViewItem();
                //将数据库数据转变成ListView类型的一行数据
                lt.Text = dr["学员姓名"].ToString();
                lt.SubItems.Add(dr["联系电话"].ToString());
                //将lt数据添加到listView1控件中
                listView1.Items.Add(lt);
            }

            con.Close();
        }
    }
}