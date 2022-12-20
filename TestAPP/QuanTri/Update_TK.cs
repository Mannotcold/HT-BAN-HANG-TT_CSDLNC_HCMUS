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

namespace TestAPP.QuanTri
{
    public partial class Update_TK : Form
    {
        public Update_TK()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANGTT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        //Hiển thị data
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from TAIKHOAN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Quản trị không thể xóa tài khoản 
            textBox2.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox2.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

        }

        string username;
        string password;
        string acount_type;
        string type;


        private void button3_Click(object sender, EventArgs e)
        {
            username = textBox2.Text;
            password = textBox6.Text;
            acount_type = textBox5.Text;
            type = textBox4.Text;
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
                MessageBox.Show("Thêm thành công! ");
            }
            else
            {
                MessageBox.Show("Thêm không thành công! .");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            username = textBox2.Text;
            password = textBox6.Text;
            acount_type = textBox5.Text;
            type = textBox4.Text;
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "delete from TAIKHOAN where TEN_TK = '" + username + "'";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Xóa thành công! ");
            }
            else
            {
                MessageBox.Show("Xóa không thành công!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            username = textBox2.Text;
            password = textBox6.Text;
            acount_type = textBox5.Text;
            type = textBox4.Text;
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "update TAIKHOAN set MATKHAU = '" + password + "', LOAI_TK = '" + acount_type + "',TRANGTHAI = '" + type + "' where TEN_TK = '" + username + "' ";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Sửa thành công! ");
            }
            else
            {
                MessageBox.Show("Sửa không thành công!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string TaiKhoan = textBox1.Text;
            string sql = "select * from TAIKHOAN WHERE TEN_TK = '" + TaiKhoan + "'";
            command = connection.CreateCommand();
            command.CommandText = "select * from TAIKHOAN WHERE TEN_TK = '" + TaiKhoan + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
