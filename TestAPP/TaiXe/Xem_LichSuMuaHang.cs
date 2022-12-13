using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.KhachHang
{
    public partial class Xem_LichSuMuaHang : Form
    {
        private string MaKH;
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");
        public Xem_LichSuMuaHang()
        {
            InitializeComponent();
        }

        public Xem_LichSuMuaHang(string MaKH)
        {
            this.MaKH = MaKH;
            InitializeComponent();
        }

        private void Xem_PhieuNhap_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string sql = $"EXEC khach_hang_xem_lich_su_mua_hang @Ma_KH = '{MaKH}'";
                SqlCommand com = new SqlCommand(sql, cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
