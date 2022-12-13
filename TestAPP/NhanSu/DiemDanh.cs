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
    public partial class DiemDanh : Form
    {
        private string MaNV;
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");
        public DiemDanh()
        {
            InitializeComponent();
        }
        public DiemDanh(string ma)
        {
            InitializeComponent();
            this.MaNV = ma;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiemDanh_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string sql = $"select * from CHI_TIET_NGAY_LAM WHERE MA_NV = '{MaNV}'";
                SqlCommand com = new SqlCommand(sql, cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution");
            }
            finally
            {
                cnn.Close();
            }
            textBox1.Text =  DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = textBox1.Text;
            int time = int.Parse(textBox2.Text);
            try
            {
                cnn.Open();
                string sql = $"EXEC nv_diem_danh " +
                            $"@Ma_NV = '{MaNV}', " +
                            $"@ngaylv = '{date}', " +
                            $"@sogio = {time}";
                SqlCommand com = new SqlCommand(sql, cnn);
                SqlDataReader dr = com.ExecuteReader();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution");
            }
            finally
            {
                cnn.Open();
                string sql = $"select * from CHI_TIET_NGAY_LAM WHERE MA_NV = '{MaNV}'";
                SqlCommand com = new SqlCommand(sql, cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
        }
    }
}
