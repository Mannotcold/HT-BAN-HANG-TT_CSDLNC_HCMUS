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

namespace TestAPP.TaiXe
{
    public partial class Thong_Tin_Ca_Nhan : Form
    {
        private string TaiKhoan;
        public Thong_Tin_Ca_Nhan()
        {
            InitializeComponent();
        }

        public Thong_Tin_Ca_Nhan(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }


        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANGTT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void Thong_Tin_Ca_Nhan_Load(object sender, EventArgs e)
        {
            MessageBox.Show(TaiKhoan);
            try
            {
                connection = new SqlConnection(str);
                //string sqll = $"Select HO_TEN_KH, DIA_CHI_KH, SO_DT_KH, EMAIL_KH, SO_LAN_MH FROM KHACH_HANG Where MA_KH = '{MaKH}'";
                connection.Open();
                string sql = "select * from TAIXE WHERE TEN_TK = '" + TaiKhoan + "'";

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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hoten = textBox2.Text;
            string ho = textBox1.Text;
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "update TAIXE set HOTEN_TX = '" + textBox2.Text + "', DIENTHOAI_TX = '" + textBox3.Text + "',DIACHI_TX = '" + textBox4.Text + "',EMAIL = '" + textBox5.Text + "',BIENSOXE = '" + textBox6.Text + "',TAIKHOANNGANHANG = '" + textBox7.Text + "' where TEN_TK = '" + TaiKhoan + "'";
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
    }
}
