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

namespace TestAPP.QuanTri
{
    public partial class Thong_Tin_Quan_Tri : Form
    {
        private string TaiKhoan;
        public Thong_Tin_Quan_Tri()
        {
            InitializeComponent();
        }

        public Thong_Tin_Quan_Tri(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANGTT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void Thong_Tin_Quan_Tri_Load(object sender, EventArgs e)
        {
            MessageBox.Show(TaiKhoan);
            try
            {
                connection = new SqlConnection(str);
                connection.Open();
                string sql = "select * from QUANTRI WHERE TEN_TK = '" + TaiKhoan + "'";

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
            com.CommandText = "update QUANTRI set MAQT = '" + textBox1.Text + "', HOTEN_QT = '" + textBox2.Text + "', DIENTHOAI_QT = '" + textBox3.Text + "',DIACHI_QT = '" + textBox4.Text + "' where TEN_TK = '" + TaiKhoan + "'";
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

        private void button5_Click(object sender, EventArgs e)
        {

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
