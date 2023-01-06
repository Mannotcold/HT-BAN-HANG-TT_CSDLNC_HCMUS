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
    public partial class Quan_Ly_Don_Dat_Hang : Form
    {
        private string MADT;
        public Quan_Ly_Don_Dat_Hang()
        {
            InitializeComponent();
        }

        public Quan_Ly_Don_Dat_Hang(string madt)
        {
            InitializeComponent();
            this.MADT = madt;
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select MADH, NGAYLAP, DIACHIGIAO, PHIVC, TONGTIEN, TINHTRANG, NGUOINHANHANG, MAKH, MATX from DONHANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "update DONHANG set  DIACHIGIAO = '" + textBox2.Text + "',NGUOINHANHANG = '" + textBox4.Text + "',TINHTRANG = '" + textBox3.Text + "' where MADH = '" + textBox1.Text + "'";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();

            if (kq > 0)
            {
                MessageBox.Show("Update thành công! ");
            }
            else
            {
                MessageBox.Show("Update không thành công!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Quản trị không thể xóa tài khoản 
            textBox1.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void Quan_Ly_Don_Dat_Hang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        void loaddata1()
        {
            command = connection.CreateCommand();
            command.CommandText = "select MADH, NGAYLAP, DIACHIGIAO, PHIVC, TONGTIEN, TINHTRANG, NGUOINHANHANG, MAKH, MATX from DONHANG where MADT = '" + MADT + "' AND TINHTRANG = 'TRUE' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        void loaddata2()
        {
            command = connection.CreateCommand();
            command.CommandText = "select MADH, NGAYLAP, DIACHIGIAO, PHIVC, TONGTIEN, TINHTRANG, NGUOINHANHANG, MAKH, MATX from DONHANG where MADT = '" + MADT + "' AND TINHTRANG = 'FALSE' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(str);
            connection.Open();
            loaddata1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select MADH, NGAYLAP, DIACHIGIAO, PHIVC, TONGTIEN, TINHTRANG, NGUOINHANHANG, MAKH, MATX from DONHANG where MADT = '" + MADT + "' AND NGAYLAP = '"+ dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
