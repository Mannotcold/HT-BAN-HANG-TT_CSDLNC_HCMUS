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
    public partial class Xem_LichSuLuong : Form
    {
        private string MaNV;
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");

        public Xem_LichSuLuong()
        {
            InitializeComponent();
        }

        public Xem_LichSuLuong(string ma)
        {
            InitializeComponent();
            this.MaNV = ma;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Xem_LichSuLuong_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string sql = $"select * from LICH_SU_LUONG WHERE Ma_NV = '{MaNV}'";
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
    }
}
