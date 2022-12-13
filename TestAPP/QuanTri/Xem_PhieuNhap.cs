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

namespace Login.QuanTri
{
    public partial class Xem_PhieuNhap : Form
    {
        private string MaQT;
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");
        public Xem_PhieuNhap()
        {
            InitializeComponent();
        }

        public Xem_PhieuNhap(string MaQT)
        {
            this.MaQT = MaQT;
            InitializeComponent();
        }

        private void Xem_PhieuNhap_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string sql = $"select * from PHIEU_NHAP WHERE QT_PHUTRACH = '{MaQT}'";
                SqlCommand com = new SqlCommand(sql, cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution");
            }
            finally
            {
                cnn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mapn = textBox1.Text.Trim();
            if(mapn == "")
            {
                MessageBox.Show("Không được để khoảng trống", "Warning");
            }
            else
            {
                try
                {
                    cnn.Open();
                    string sql = $"select * from CT_PHIEU_NHAP WHERE Ma_PN = '{mapn}'";
                    SqlCommand com = new SqlCommand(sql, cnn);
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning");
                }
                finally
                {
                    cnn.Close();
                }
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
