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
    public partial class 添加学员页面 : Form
    {
        public 添加学员页面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //添加学员
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);

            string strCollected = string.Empty;
            string unstrCollected = string.Empty;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (strCollected == string.Empty)
                    {
                        strCollected = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                    else
                    {
                        strCollected = strCollected+","+ checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                }
                else
                {
                    if (unstrCollected == string.Empty)
                    {
                        unstrCollected = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                    else
                    {
                        unstrCollected = unstrCollected + "," + checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                }
            }

            string strsql = "insert into 学员表(学员用户名, 学员姓名, 性别, 年龄, 身份证,报考类型,报名时间,到期时间,学车时长,已考科目,未考科目,教练用户名,管理员用户名,联系电话) values( '" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "'," + Convert.ToInt32(textBox4.Text) + ",'" + textBox5.Text + "','" + comboBox2.Text +"','"+ dateTimePicker2.Text + "','"+ dateTimePicker1.Text+"',"+ Convert.ToInt32(textBox7.Text) + ",'" + strCollected + "','" + unstrCollected + "','" + textBox10.Text + "','"+登录页面.strname +"','"+textBox3.Text +"');";
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
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false); //设置第i项是否选中
            }
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void 添加学员页面_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //更新
            string 学员姓名=string.Empty, 性别 = string.Empty, 身份证 = string.Empty, 报考类型 = string.Empty, 报名时间, 到期时间 = string.Empty,  已考科目 = string.Empty, 未考科目 = string.Empty, 教练用户名 = string.Empty, 管理员用户名, 联系电话 = string.Empty;
            int 年龄 = 18, 学车时长 = 0;
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            

            string strCollected = string.Empty;
            string unstrCollected = string.Empty;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (strCollected == string.Empty)
                    {
                        strCollected = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                    else
                    {
                        strCollected = strCollected + "," + checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                }
                else
                {
                    if (unstrCollected == string.Empty)
                    {
                        unstrCollected = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                    else
                    {
                        unstrCollected = unstrCollected + "," + checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                }
            }

            SqlCommand sqlCommand = new SqlCommand("select *  from  学员表  where  学员用户名 = '" + textBox1.Text + "'", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断是否有数据
                {
                    while (sqlDataReader.Read())//循环读取sqlDataReader对象中的数据
                    {
                        学员姓名= (string)sqlDataReader["学员姓名"];//强制转换不可忘
                        性别 = (string)sqlDataReader["性别"]; 
                        年龄 = Convert.ToInt32(sqlDataReader["年龄"]); 
                        身份证 = (string)sqlDataReader["身份证"]; 
                        报考类型 = (string)sqlDataReader["报考类型"]; 
                        报名时间 = (string)sqlDataReader["报名时间"]; 
                        到期时间 = (string)sqlDataReader["到期时间"]; 
                        if(sqlDataReader["学车时长"]!=null)
                        {
                            学车时长 = Convert.ToInt32(sqlDataReader["学车时长"]);
                        }
                        if(sqlDataReader["已考科目"]!=null)
                        {
                            已考科目 = (string)sqlDataReader["已考科目"];
                        }
                        if(sqlDataReader["未考科目"]!=null)
                        {
                            未考科目 = (string)sqlDataReader["未考科目"];
                        }
                        if(sqlDataReader["教练用户名"]!=null)
                        {
                            教练用户名 = (string)sqlDataReader["教练用户名"];
                        }

                        管理员用户名 = (string)sqlDataReader["管理员用户名"]; 
                        联系电话 = (string)sqlDataReader["联系电话"];
                    }
                    if (textBox2.Text!="")
                    {
                        学员姓名 = textBox2.Text;
                    }
                    if(comboBox1.Text!="")
                    {
                        性别 = comboBox1.Text;
                    }
                    if(textBox4.Text!="")
                    {
                        年龄 = Convert.ToInt32(textBox4.Text);
                    }
                    if(textBox5.Text!="")
                    {
                        身份证 = textBox5.Text;
                    }
                    if (textBox3.Text != "")
                    {
                        联系电话 = textBox3.Text;
                    }
                    if (comboBox2.Text != "")
                    {
                        报考类型 = comboBox2.Text;
                    }
                    if (dateTimePicker1.Text!= 到期时间)
                    {
                        到期时间 = dateTimePicker1.Text;
                    }
                    if (textBox7.Text != "")
                    {
                        学车时长 = Convert.ToInt32(textBox7.Text);
                    }
                    if (textBox10.Text != "")
                    {
                        教练用户名 = textBox10.Text;
                    }
                    if(strCollected!="")
                    {
                        已考科目 = strCollected;
                        未考科目 = unstrCollected;
                    }
                    string strsql = "update  学员表  set  学员姓名='" + 学员姓名 + "'," + " 性别='" + 性别 + "'," +"年龄=" + 年龄 + "," + "身份证='" + 身份证 + "'," + "报考类型='" + 报考类型  + "'," + "到期时间='" + 到期时间 + "'," + "学车时长=" + 学车时长 + ","+ "已考科目='" + 已考科目 + "'," + "未考科目='" + 未考科目 + "'," + "教练用户名='" + 教练用户名 + "',"+ "管理员用户名='" + 登录页面.strname + "'," + "联系电话='" + 联系电话 + "'  where 学员用户名 = '" + textBox1.Text + "'";
                    SqlCommand comm = new SqlCommand(strsql, con);
                    sqlDataReader.Close();
                    if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                    //更新后清空textBox
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox10.Text = "";
                    comboBox2.Text = "";
                    comboBox1.Text = "";
                    dateTimePicker1.Text = "";
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, false); //设置第i项是否选中
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

        private void button3_Click(object sender, EventArgs e)
        {
            //查询某一个学员信息
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("select *  from  学员表  where  学员用户名 = '" + textBox1.Text + "'", con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断是否有数据
                {
                    while (sqlDataReader.Read())//循环读取sqlDataReader对象中的数据
                    {
                        textBox1.Text = (string)sqlDataReader["学员用户名"];//强制转换不可忘
                        textBox2.Text = (string)sqlDataReader["学员姓名"];
                        comboBox1.Text = (string)sqlDataReader["性别"];
                        textBox4.Text = Convert.ToString(sqlDataReader["年龄"]);
                        textBox5.Text = (string)sqlDataReader["身份证"];
                        comboBox2.Text = (string)sqlDataReader["报考类型"];
                        dateTimePicker1.Text = (string)sqlDataReader["到期时间"];
                        textBox7.Text = Convert.ToString(sqlDataReader["学车时长"]);
                        if ((string)sqlDataReader["已考科目"] == "科目1")
                        {
                            checkedListBox1.SetItemChecked(0, true);
                        }
                        else if((string)sqlDataReader["已考科目"] == "科目1,科目2")
                            {
                            checkedListBox1.SetItemChecked(0, true);
                            checkedListBox1.SetItemChecked(1, true);
                        }
                        else if((string)sqlDataReader["已考科目"] == "科目1,科目2,科目3")
                        {
                            checkedListBox1.SetItemChecked(0, true);
                            checkedListBox1.SetItemChecked(1, true);
                            checkedListBox1.SetItemChecked(2, true);
                        }
                        else if ((string)sqlDataReader["已考科目"] == "科目1,科目2,科目3,科目4")
                        {
                            checkedListBox1.SetItemChecked(0, true);
                            checkedListBox1.SetItemChecked(1, true);
                            checkedListBox1.SetItemChecked(2, true);
                            checkedListBox1.SetItemChecked(3, true);
                        }
                        else
                        {
                            checkedListBox1.SetItemChecked(0, false);
                            checkedListBox1.SetItemChecked(1, false);
                            checkedListBox1.SetItemChecked(2, false);
                            checkedListBox1.SetItemChecked(3, false);
                        }

                        textBox10.Text = (string)sqlDataReader["教练用户名"];
                        textBox3.Text = (string)sqlDataReader["联系电话"];

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
                    comboBox2.Text = "";
                    dateTimePicker1.Text = "";
                    textBox7.Text = "";
                    checkedListBox1.SetItemChecked(0, false);
                    checkedListBox1.SetItemChecked(1, false);
                    checkedListBox1.SetItemChecked(2, false);
                    checkedListBox1.SetItemChecked(3, false);
                    textBox10.Text = "";
                    textBox3.Text = "";
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
            //删除学员
            string sqlc = "Server=LAPTOP-GJ0RJN64;User Id=sa;Pwd=123456;DataBase=驾校信息管理系统";
            SqlConnection con = new SqlConnection(sqlc);
            SqlCommand sqlCommand = new SqlCommand("select *  from  学员表  where  学员用户名 = '" + textBox1.Text + "'", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//返回读到的数据
            try
            {
                if (sqlDataReader.HasRows)//判断是否有数据
                {
                    string strsql = "DELETE FROM 学员表 WHERE 学员用户名 = '" + textBox1.Text + "';" + "DELETE FROM 学员_用户名_密码表 WHERE 用户名 = '" + textBox1.Text + "'";
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
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox10.Text = "";
                    comboBox2.Text = "";
                    comboBox1.Text = "";
                    dateTimePicker1.Text = "";
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
