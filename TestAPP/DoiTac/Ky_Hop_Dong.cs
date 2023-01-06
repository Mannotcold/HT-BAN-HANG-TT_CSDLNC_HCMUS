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
    public partial class Ky_Hop_Dong : Form
    {
        private string MAHD;
        private string MADT;
        public Ky_Hop_Dong()
        {
            InitializeComponent();
        }
        public Ky_Hop_Dong(string ma)
        {
            InitializeComponent();
            this.MADT = ma;
        }
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void Ky_Hop_Dong_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();


            //Tạo mã họp đồng mới
            string sql = "select COUNT(*) from HOPDONG";

            SqlCommand com = new SqlCommand(sql, connection);
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            SqlDataReader dta = com.ExecuteReader();
            while (dta.Read())
            {
                int mahd = dta.GetInt32(0) + 1535;
                MAHD = "MAHD" + mahd.ToString();
                textBox1.Text = MAHD;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            DateTime date;
            date = dateTimePicker1.Value.AddYears(+1);
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into HOPDONG(MAHD, MADT, MANV, NGAYLAP, THOIGIANHIEULUC, TAIKHOANNGANHANG) VALUES ('" + MAHD + "','" + MADT + "','MANV1','" + dateTimePicker1.Text + "','" + date + "','" + textBox3.Text + "')";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Ký hợp đồng thành công! Vui lòng chờ xét duyệt. ");
            }
            else
            {
                MessageBox.Show("Ký hợp đồng thất bại! .");
            }
        }
    }
}
