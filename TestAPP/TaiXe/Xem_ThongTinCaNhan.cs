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
namespace Login.KhachHang
{
    public partial class Xem_ThongTinCaNhan : Form
    {
        private string MaKH;
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");
        public Xem_ThongTinCaNhan()
        {
            InitializeComponent();
        }

        public Xem_ThongTinCaNhan(string ma)
        {
            InitializeComponent();
            this.MaKH = ma;
        }

        private void Xem_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = $"Select HO_TEN_KH, DIA_CHI_KH, SO_DT_KH, EMAIL_KH, SO_LAN_MH FROM KHACH_HANG Where MA_KH = '{MaKH}'";
                cnn.Open();
                SqlCommand com = new SqlCommand(sql, cnn);
                SqlDataReader da = com.ExecuteReader();
                while (da.Read())
                {
                    textBox1.Text = MaKH;
                    textBox2.Text = da.GetString(3);
                    textBox4.Text = da.GetString(0);
                    textBox5.Text = da.GetString(2);
                    textBox6.Text = da.GetInt32(4).ToString();
                    textBox7.Text = da.GetString(1);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
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

        private void button2_Click(object sender, EventArgs e)
        {
            var fullname = textBox4.Text;
            var email = textBox2.Text;
            string sdt = textBox5.Text.ToString();
            var diachi = textBox7.Text;

            try
            {
                string sql = $"UPDATE KHACH_HANG " +
                    $"SET HO_TEN_KH = N'{fullname}', " +
                    $"DIA_CHI_KH = '{diachi}', " +
                    $"SO_DT_KH = '{sdt}', " +
                    $"EMAIL_KH = '{email}' Where MA_KH = '{MaKH}'";
                cnn.Open();
                SqlCommand com = new SqlCommand(sql, cnn);
                SqlDataReader da = com.ExecuteReader();
                while (da.Read())
                {
                    textBox1.Text = MaKH;
                    textBox2.Text = da.GetString(3);
                    textBox4.Text = da.GetString(0);
                    textBox5.Text = da.GetString(2);
                    textBox6.Text = da.GetInt32(4).ToString();
                    textBox7.Text = da.GetString(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            finally
            {
                cnn.Close();
                string result = $"Bạn đã chỉnh sửa thành công";
                MessageBox.Show(result, "Thành công");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
