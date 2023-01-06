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
    public partial class Quan_Ly_So_Lieu : Form
    {
        private string MADT;
        string TRUE = "TRUE";
        string FALSE = "FALSE";
        public Quan_Ly_So_Lieu()
        {
            InitializeComponent();
        }

        public Quan_Ly_So_Lieu(string madt)
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
            command.CommandText = "select * from DONHANG where MADT = '" + MADT + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Quan_Ly_So_Lieu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + MADT + "' and TINHTRANG = '" + TRUE + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + MADT + "' and TINHTRANG = '" + FALSE + "' ";
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + MADT + "' and TINHTRANG = '" + TRUE + "' and NGAYLAP = '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENDT();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DateTime date;
            date = dateTimePicker1.Value.AddMonths(-1); ;
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + MADT + "' and TINHTRANG = '" + TRUE + "' and NGAYLAP BETWEEN '" + date + "' AND '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENDT();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            DateTime date;
            date = dateTimePicker1.Value.AddYears(-1); ;
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MADT ='" + MADT + "' and TINHTRANG = '" + TRUE + "' and NGAYLAP BETWEEN '" + date + "' AND '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENDT();
        }
    }
}
