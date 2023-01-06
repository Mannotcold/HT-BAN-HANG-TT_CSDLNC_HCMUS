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

namespace TestAPP.TaiXe
{
    public partial class Menu : Form
    {
        private string TaiKhoan;
        public Menu()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";

        public Menu(string taiKhoan)
        {
            InitializeComponent();
            this.TaiKhoan = taiKhoan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new TaiXe.Thong_Tin_Ca_Nhan(TaiKhoan);
            
            frmKH_XemTT.ShowDialog();
            this.Show();
        }
        string MATX;
        private void Menu_Load(object sender, EventArgs e)
        {
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
                   MATX = dta.GetString(0);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new TaiXe.Tiep_Nhan_Don_Hang(MATX);
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new TaiXe.Xem_Don_Hang_Nhan(MATX);
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
