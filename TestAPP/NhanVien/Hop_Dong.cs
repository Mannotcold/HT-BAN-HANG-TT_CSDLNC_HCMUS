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
    public partial class Hop_Dong : Form
    {
        public Hop_Dong()
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
            command.CommandText = "select * from HOPDONG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void Hop_Dong_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string MAHD = textBox1.Text;
            string sql = "select * from HOPDONG WHERE MAHD = '" + MAHD + "'";
            command = connection.CreateCommand();
            command.CommandText = "select * from HOPDONG WHERE MAHD = '" + MAHD + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string MAHD = textBox1.Text;
            
            string sql = "select * from HOPDONG WHERE THOIGIANHIEULUC BETWEEN '"+ dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'";
            command = connection.CreateCommand();
            command.CommandText = "select * from HOPDONG WHERE THOIGIANHIEULUC BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
