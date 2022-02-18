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
    public partial class 驾考成绩页面 : Form
    {
        public 驾考成绩页面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select *  from 成绩表  where  用户名 = '" + 登录页面.strname + "'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            if (dt.Read())
            {
                textBox1.Text = dt["科目一"].ToString();
                textBox2.Text = dt["科目二"].ToString();
                textBox3.Text = dt["科目三"].ToString();
                textBox4.Text = dt["科目四"].ToString();
            }
            dt.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
