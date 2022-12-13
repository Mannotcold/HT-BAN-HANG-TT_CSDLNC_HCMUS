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
    public partial class ThongKe_SLDH : Form
    {
        private string MaNV;
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");
        public ThongKe_SLDH()
        {
            InitializeComponent();
        }

        public ThongKe_SLDH(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }


        private void ThongKe_SLDH_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string sql = $"EXEC so_luong_don_hang @Ma_NV = '{MaNV}'";
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
