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

namespace TestAPP.TaiXe
{
    public partial class Xem_Don_Hang_Nhan : Form
    {
        private string MATX;
        public Xem_Don_Hang_Nhan()
        {
            InitializeComponent();
        }

        public Xem_Don_Hang_Nhan(string matx)
        {
            InitializeComponent();
            this.MATX = matx;
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataAdapter adapter2 = new SqlDataAdapter();
        DataTable table2 = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MATX ='" + MATX + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Xem_Don_Hang_Nhan_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }
        string TRUE = "TRUE";
        string FALSE = "FALSE";
        private void button4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MATX ='" + MATX + "' and TINHTRANG = '" + TRUE + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MATX ='" + MATX + "' and TINHTRANG = '" + FALSE + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        string TONG;
        void TONGTIENVC()
        {

            int sc = dataGridView1.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) - float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * 10 / 100;
            TONG = thanhtien.ToString();
            MessageBox.Show("Thu nhập của tài xế là: "+TONG);
        }

        void ThongKeDH()
        {
            int sc = dataGridView1.Rows.Count;
            textBox1.Text = sc.ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MATX ='" + MATX + "' and TINHTRANG = '" + TRUE + "' and NGAYLAP = '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENVC();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = dateTimePicker1.Value.AddMonths(-1); ;
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MATX ='" + MATX + "' and TINHTRANG = '" + TRUE + "' and NGAYLAP BETWEEN '" + date + "' AND '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENVC();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = dateTimePicker1.Value.AddYears(-1); ;
            command = connection.CreateCommand();
            command.CommandText = "select * from DONHANG where MATX ='" + MATX + "'and TINHTRANG = '" + TRUE + "' and NGAYLAP BETWEEN '" + date + "' AND '" + dateTimePicker1.Text + "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            ThongKeDH();
            TONGTIENVC();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
