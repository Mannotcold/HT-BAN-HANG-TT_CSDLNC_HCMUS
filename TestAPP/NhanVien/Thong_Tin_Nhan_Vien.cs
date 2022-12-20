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
using TestAPP.QuanTri;

namespace TestAPP.NhanVien
{
    public partial class Thong_Tin_Nhan_Vien : Form
    {
        private string TaiKhoan;
        public Thong_Tin_Nhan_Vien()
        {
            InitializeComponent();
        }

        public Thong_Tin_Nhan_Vien(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANGTT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
       
        private void Thong_Tin_Nhan_Vien_Load(object sender, EventArgs e)
        {
            MessageBox.Show(TaiKhoan);
            try
            {
                connection = new SqlConnection(str);
                //string sqll = $"Select HO_TEN_KH, DIA_CHI_KH, SO_DT_KH, EMAIL_KH, SO_LAN_MH FROM KHACH_HANG Where MA_KH = '{MaKH}'";
                connection.Open();
                string sql = "select * from NHANVIEN WHERE TEN_TK = '" + TaiKhoan + "'";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                while (dta.Read())
                {
                    textBox1.Text = dta.GetString(0);
                    textBox2.Text = dta.GetString(2);
                    textBox3.Text = dta.GetString(3);
                    textBox4.Text = dta.GetString(4);
                    textBox5.Text = dta.GetString(5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "update NHANVIEN set MANV = '" + textBox1.Text + "', HOTEN_NV = '" + textBox2.Text + "', DIENTHOAI_NV = '" + textBox3.Text + "',DIACHI_NV = '" + textBox4.Text + "',EMAIL = '" + textBox5.Text + "' where TEN_TK = '" + TaiKhoan + "'";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();

            if (kq > 0)
            {
                MessageBox.Show("Update thành công! ");
            }
            else
            {
                MessageBox.Show("Update không thành công!");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
