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
namespace Login.NhanSu
{
    public partial class Xem_DonHang : Form
    {
        private string MaNV;
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");

        public Xem_DonHang()
        {
            InitializeComponent();
        }
        public Xem_DonHang(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }
        private void Xem_DonHang_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string sql = $"select * from DON_HANG WHERE NV_TT = '{MaNV}'";
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
            this.Close();
        }
    }
}
