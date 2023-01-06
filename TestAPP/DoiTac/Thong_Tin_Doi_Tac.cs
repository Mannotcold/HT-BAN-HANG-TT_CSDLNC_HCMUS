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

namespace TestAPP.DoiTac
{
    public partial class Thong_Tin_Doi_Tac : Form
    {
        private string TaiKhoan;
        public Thong_Tin_Doi_Tac()
        {
            InitializeComponent();
        }
        public Thong_Tin_Doi_Tac(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }


        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void Thong_Tin_Doi_Tac_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(str);
                //string sqll = $"Select HO_TEN_KH, DIA_CHI_KH, SO_DT_KH, EMAIL_KH, SO_LAN_MH FROM KHACH_HANG Where MA_KH = '{MaKH}'";
                connection.Open();
                string sql = "select * from DOITAC WHERE TEN_TK = '" + TaiKhoan + "'";

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
                    textBox6.Text = dta.GetString(6);
                    textBox7.Text = dta.GetString(7);
                    textBox8.Text = dta.GetString(8);
                    textBox9.Text = dta.GetString(9);
                    textBox10.Text = dta.GetString(10);
                    textBox11.Text = dta.GetString(11);
                    textBox12.Text = dta.GetString(12);
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
        // Cập nhập thông tin 
        private void button1_Click(object sender, EventArgs e)
        {
            string MASOTHUE = textBox2.Text;
            string EMAIL = textBox3.Text;
            string TENQUAN = textBox4.Text;
            string NGUOIDAIDIEN = textBox5.Text;
            string THANHPHO = textBox6.Text;
            string QUAN = textBox7.Text;
            string LOAIAMTHUC = textBox8.Text;
            string DIACHIKINHDOANH = textBox9.Text;
            string SODIENTHOAI = textBox10.Text;
            string SOLUONGCUAHANG = textBox11.Text;
            string SOLUONGDHDUKIEN = textBox12.Text;

            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "update DOITAC set MASOTHUE = '" + MASOTHUE + "', EMAIL = '" + EMAIL + "',TENQUAN = '" + TENQUAN + "',NGUOIDAIDIEN = '" + NGUOIDAIDIEN + "',THANHPHO = '" + THANHPHO + "',QUAN = '" + QUAN + "',LOAIAMTHUC = '" + LOAIAMTHUC + "',DIACHIKINHDOANH = '" + DIACHIKINHDOANH + "',SODIENTHOAI = '" + SODIENTHOAI + "',SOLUONGCUAHANG = '" + SOLUONGCUAHANG + "',SOLUONGDHDUKIEN = '" + SOLUONGDHDUKIEN + "' where TEN_TK = '" + TaiKhoan + "' ";
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
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
