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

namespace TestAPP.KhachHang
{
    public partial class Menu : Form
    {

        string MAKH, HOTEN_KH, DIACHI_KH;
        public Menu()
        {
            InitializeComponent();
        }
        private string TaiKhoan;
        
        public Menu(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new KhachHang.Thong_Tin_Khach_Hang(TaiKhoan);
            
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_MuaHang = new KhachHang.DS_Doi_Tac(MAKH, HOTEN_KH, DIACHI_KH);
            frmKH_MuaHang.ShowDialog();
            this.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(str);
                connection.Open();
                string sql = "select * from KHACHHANG WHERE TEN_TK = '" + TaiKhoan + "'";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                while (dta.Read())
                {
                    MAKH = dta.GetString(0);
                    HOTEN_KH = dta.GetString(2);
                    DIACHI_KH = dta.GetString(4);
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
            this.Hide();
            Form frmKH_MuaHang = new KhachHang.Theo_Doi_Don_Hang(MAKH);
            frmKH_MuaHang.ShowDialog();
            this.Show();
        }
    }
}
