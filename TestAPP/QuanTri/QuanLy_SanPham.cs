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
    public partial class QuanLy_SanPham : Form
    {
        private string MaQT;
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");
        public QuanLy_SanPham()
        {
            InitializeComponent();
        }
        public QuanLy_SanPham(string MaQT)
        {
            InitializeComponent();
            this.MaQT = MaQT;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLy_SanPham_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string sql = $"select * from SAN_PHAM";
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
                cnn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var MaSP = textBox1.Text;
            if(MaSP == "")
            {
                MessageBox.Show("Mã sản phẩm không được để trống!", "Warning");
            }
            else
            {
                string TenSP = textBox2.Text.Trim();
                string MoTa = textBox3.Text.Trim();
                int Gia = int.Parse(textBox4.Text);
                string LoaiHang = textBox5.Text.Trim();
                int SLT = int.Parse(textBox6.Text);
                float GiamGia = float.Parse(textBox7.Text);
                try
                {
                    cnn.Open();
                    string sql = $"Select * From SAN_PHAM where Ma_SP = '{MaSP}'";
                    SqlCommand com = new SqlCommand(sql, cnn);
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Có dữ liệu => Update
                    if(dt.Rows.Count == 1)
                    {
                        try
                        {
                            string sql_2 =
                                $"EXEC cap_nhat_san_pham " +
                                $"@Ma_SP = '{MaSP}', " +
                                $"@ten_sp = '{TenSP}', " +
                                $"@mo_ta = '{MoTa}', " +
                                $"@gia = {Gia}, " +
                                $"@loai = '{LoaiHang}', " +
                                $"@so_luong_ton = {SLT}, " +
                                $"@giam_gia = {GiamGia}";
                            com = new SqlCommand(sql_2, cnn);
                            SqlDataReader dr = com.ExecuteReader();
                            cnn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Caution");
                            cnn.Close();
                        }
                    }
                    //Không có dữ liệu => Thêm
                    else if(dt.Rows.Count == 0)
                    {
                        try
                        {
                            string sql_2 =
                                $"EXEC them_san_pham " +
                                $"@Ma_SP = '{MaSP}', " +
                                $"@ten_sp = '{TenSP}', " +
                                $"@mo_ta = '{MoTa}', " +
                                $"@gia = {Gia}, " +
                                $"@loai = '{LoaiHang}', " +
                                $"@so_luong_ton = {SLT}, " +
                                $"@giam_gia = {GiamGia}";
                            com = new SqlCommand(sql_2, cnn);
                            SqlDataReader dr = com.ExecuteReader();
                            cnn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Caution");
                            cnn.Close();
                        }
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caution");
                    cnn.Close();
                }
                finally
                {
                    cnn.Open();
                    string sql = $"select * from SAN_PHAM WHERE Ma_SP = '{MaSP}'";
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

        private void button3_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = $"select * from SAN_PHAM";
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
