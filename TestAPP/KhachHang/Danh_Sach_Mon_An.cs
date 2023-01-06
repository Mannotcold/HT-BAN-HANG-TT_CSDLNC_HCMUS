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

namespace TestAPP.KhachHang
{
    public partial class Danh_Sach_Mon_An : Form
    {

        private string MACH;
        private string MADH;
        private string MAKH;
        private string MADT;
        private string HOTEN_KH;
        private string DIACHI_KH;
        private string MATT;
        public Danh_Sach_Mon_An()
        {
            InitializeComponent();
        }
        public Danh_Sach_Mon_An(string mach, string makh, string madt, string ht, string dc)
        {
            InitializeComponent();
            this.MACH = mach;
            this.MAKH = makh;
            this.MADT = madt;
            this.HOTEN_KH = ht;
            this.DIACHI_KH = dc;
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataAdapter adapter2 = new SqlDataAdapter();
        DataTable table2 = new DataTable();

        //Hiển thị data
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from MONAN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        

        //Tạo đơn đặt hàng
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        void TaodonDH()
        {
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            string now = DateTime.Now.ToString();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into DONHANG(MADH,MAKH,MADT,DIACHIGIAO,PHIVC,TINHTRANG,NGUOINHANHANG,NGAYLAP) VALUES ('" + MADH + "','" + MAKH + "','" + MADT + "','" + DIACHI_KH + "','20000','FALSE','" + HOTEN_KH + "','" + now + "')";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();
            
        }

        string MAMA;
        string THANHTIEN;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox5.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            THANHTIEN = dataGridView1.Rows[i].Cells[2].Value.ToString();
            MAMA = textBox5.Text;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(str);
            connection.Open();
            MAMA = textBox5.Text;
            string SoLuong = textBox1.Text;
            float SL = float.Parse(SoLuong);
            float thanhtien = float.Parse(THANHTIEN);
            float TT = thanhtien * SL;
            string ThanhTien = TT.ToString();
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into CT_DONHANG(MAMA,MADH,THANHTIEN,SOLUONG) VALUES ('" + MAMA + "','" + MADH + "','" + ThanhTien + "','" + SoLuong + "')";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Thêm thành công! ");
            }
            else
            {
                MessageBox.Show("Thêm không thành công! .");
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from CT_DONHANG WHERE MADH = '" + MADH + "'";
            adapter2.SelectCommand = command;
            table2.Clear();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;

            TONGTIEN();
          
        }

        string TONG;
        void TONGTIEN()
        {

            int sc = dataGridView2.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
            TONG = thanhtien.ToString();
            textBox2.Text = TONG;
        }

        void UpdateTong()
        {
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            string now = DateTime.Now.ToString();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "update DONHANG set TONGTIEN = '" + textBox2.Text + "' where MADH = '" + MADH + "'";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();
        }

        private void Danh_Sach_Mon_An_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();

            //Tạo mã đơn hàng mới
            string sql = "select COUNT(*) from DONHANG";

            SqlCommand com = new SqlCommand(sql, connection);
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            SqlDataReader dta = com.ExecuteReader();
            while (dta.Read())
            {
                int madh = dta.GetInt32(0) + 1535;
                MADH = "MADH" + madh.ToString();
                MATT = "MATT" + madh.ToString();
            }

            TaodonDH();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into THANHTOAN(MATT,PHUONGTHUCTHANHTOAN,TRANGTHAI,MADH) VALUES ('" + MATT + "','" + comboBox1.Text + "','TRUE','" + MADH + "')";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Thanh toán thành công! ");
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại! .");
            }
            UpdateTong();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
