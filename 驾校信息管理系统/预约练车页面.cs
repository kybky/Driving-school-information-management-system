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
    public partial class 预约练车页面 : Form
    {
        public 预约练车页面()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("9：00-11：00");
            //comboBox1.Items.Add("13：00-15：00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select count(学员用户名) as A from 预约表 where 预约日期='"+ monthCalendar1.SelectionStart.ToString()+"' and 预约时间段='"+ comboBox1.Items[comboBox1.SelectedIndex].ToString()+"'", con);
            SqlDataReader dt = sqlCommand.ExecuteReader();
            if(dt.Read())
            {
                string x = dt["A"].ToString();
                dt.Close();
                if(x=="4")
                {
                    MessageBox.Show("该时段人数已满，请重新选择。");
                }
                else
                {
                    sqlCommand = new SqlCommand("insert into 预约表 values ('" + 登录页面.strname + "','" + monthCalendar1.SelectionStart.ToString() + "','" + comboBox1.Items[comboBox1.SelectedIndex].ToString() + "')", con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("预约成功！");
                    dt.Close();
                    con.Close();
                    this.Close();
                }
            }
        }
    }
}
