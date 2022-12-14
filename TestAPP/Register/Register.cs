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
using TestAPP.Register;

namespace TestAPP.Register
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        string acount_type = "";
        string type = "False";
        //SqlConnection cnn;
        //SqlCommand command;
        //string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANG_TT;Integrated Security=True";
        //SqlDataAdapter adapter = new SqlDataAdapter();
        //DataTable table = new DataTable();
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANGTT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        //void loaddata()
        //{
        //    command = connection.CreateCommand();
        //    command.CommandText = "select * from TAIKHOAN";
        //    adapter.SelectCommand = command;
        //    table.Clear();
        //    adapter.Fill(table);
        //    dataGridView1.DataSource = table;
        //}
        private void button1_Click(object sender, EventArgs e)
        {


            connection = new SqlConnection(str);
            try
            {
                string username = textBox1.Text.Trim();
                string password = textBox3.Text.Trim();
                if (checkBox1.Checked == true)
                {
                    acount_type = "KH";
                        }
                if (checkBox2.Checked == true)
                    {
                        acount_type = "NV";
                    }
                if (checkBox3.Checked == true)
                    {
                        acount_type = "TX";
                    }
                    connection.Open();
                string sql = "insert into TAIKHOAN values ('" + username + "', '" + password + "','" + acount_type + "','" + type + "' ";

                SqlCommand com = new SqlCommand();
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                //com.ExecuteNonQuery();
                com.CommandType = CommandType.Text;
                com.CommandText = "insert into TAIKHOAN(TEN_TK,MATKHAU,LOAI_TK,TRANGTHAI) VALUES ('" + username + "','" + password + "','" + acount_type + "','" + type + "')";
                com.Connection = connection;
                //loaddata();
                int kq = com.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thàng công! Vui lòng đợi trong vài phút để quản tri viên xét duyệt.");
                }
                else
                {
                    MessageBox.Show("Đăng ký không thàng công! Vui lòng xem lại tài khoản/mật khẩu.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối");
            }






        }
    }
}
