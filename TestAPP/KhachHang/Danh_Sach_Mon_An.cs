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
using TestAPP.Register;
using TestAPP.QuanTri;

namespace TestAPP.KhachHang
{
    public partial class Danh_Sach_Mon_An : Form
    {

        private string MACH;
        public Danh_Sach_Mon_An()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANGTT;Integrated Security=True";
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
        public Danh_Sach_Mon_An(string mach)
        {
            InitializeComponent();
            this.MACH = mach;
            MessageBox.Show(MACH);
        }

        string MADH;
        string MAKH;
        string MADT;
        private void button3_Click(object sender, EventArgs e)
        {
            MADH = textBox2.Text;
            MAKH = textBox3.Text;
            MADT = textBox4.Text;
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into DONHANG(MADH,MAKH,MADT) VALUES ('" + MADH + "','" + MAKH + "','" + MADT + "')";
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
        }

        string MAMA;
        string THANHTIEN;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox5.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            THANHTIEN = dataGridView1.Rows[i].Cells[2].Value.ToString();
            MessageBox.Show(THANHTIEN);
            MAMA = textBox5.Text;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(str);
            connection.Open();
            MAMA = textBox5.Text;
            string SoLuong = textBox1.Text;
            MADH = textBox2.Text;
            float SL = float.Parse(SoLuong);
            float thanhtien = float.Parse(THANHTIEN);
            float TT = thanhtien * SL;
            string ThanhTien = TT.ToString();
            MessageBox.Show(ThanhTien);
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

        }

        

        private void Danh_Sach_Mon_An_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
