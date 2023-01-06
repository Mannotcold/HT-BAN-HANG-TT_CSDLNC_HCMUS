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

namespace TestAPP.NhanVien
{
    public partial class Thong_Ke_Don_Hang : Form
    {
        public Thong_Ke_Don_Hang()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        //Hiển thị data
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        string MADT;
        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            MADT = textBox1.Text;
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG WHERE MADT = '" + MADT + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Thong_Ke_Don_Hang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Quản trị không thể xóa tài khoản 
            textBox1.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            MADT = dataGridView1.Rows[i].Cells[9].Value.ToString();
            
            try
            {
                connection = new SqlConnection(str);
                connection.Open();
                string sql = "select COUNT(*) from DONHANG WHERE MADT = '" + MADT + "'";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                while (dta.Read())
                {
                   
                    MessageBox.Show("Số lượng đơn hàng của đối tác " +MADT+ "là:"+ dta.GetInt32(0).ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string TRUE = "TRUE";
        string FALSE = "FALSE";
        private void button4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + textBox1.Text + "' and TINHTRANG = '" + TRUE + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + textBox1.Text + "' and TINHTRANG = '" + FALSE + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        string TONG;
        void TONGTIENDT()
        {

            int sc = dataGridView1.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) - float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * 10 / 100;
            TONG = thanhtien.ToString();
            MessageBox.Show("Thu nhập của tài xế là: " + TONG);
        }

        void ThongKeDH()
        {
            int sc = dataGridView1.Rows.Count;
            textBox1.Text = sc.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + textBox1.Text + "' and TINHTRANG = '" + TRUE + "' and NGAYLAP = '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENDT();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = dateTimePicker1.Value.AddMonths(-1); ;
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + textBox1.Text + "' and TINHTRANG = '" + TRUE + "' and NGAYLAP BETWEEN '" + date + "' AND '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENDT();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = dateTimePicker1.Value.AddYears(-1); ;
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + textBox1.Text + "' and TINHTRANG = '" + TRUE + "' and NGAYLAP BETWEEN '" + date + "' AND '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENDT();
        }

        void TONGTHUNHAPAPP()
        {

            int sc = dataGridView1.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * 10 / 100;
            TONG = thanhtien.ToString();
            MessageBox.Show("Tổng thu nhập đối với đối tác " + MADT+ " là: " + TONG);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = dateTimePicker1.Value.AddYears(-1); ;
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + textBox1.Text + "' and TINHTRANG = '" + TRUE + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTHUNHAPAPP();
        }
    }
}
