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

namespace TestAPP.DoiTac
{
    public partial class Menu : Form
    {
        private string TaiKhoan;

        string MADT;
        private void label3_Click(object sender, EventArgs e)
        {

        }
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }


        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmDT_XemTT = new DoiTac.Thong_Tin_Doi_Tac(TaiKhoan);
            
            frmDT_XemTT.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmDT_XemTT = new DoiTac.Ky_Hop_Dong(MADT);
            
            frmDT_XemTT.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmDT_XemTT = new DoiTac.Update_Cua_Hang(MADT);
            frmDT_XemTT.ShowDialog();
            this.Show();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(str);
                connection.Open();
                string sql = "select * from DOITAC WHERE TEN_TK = '" + TaiKhoan + "'";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                while (dta.Read())
                {
                    MADT = dta.GetString(0);
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

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmDT_XemTT = new DoiTac.Quan_Ly_Don_Dat_Hang(MADT);
            frmDT_XemTT.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmDT_XemTT = new DoiTac.Quan_Ly_So_Lieu(MADT);
            frmDT_XemTT.ShowDialog();
            this.Show();
        }
    }
}
