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
    public partial class DS_Doi_Tac : Form
    {
        public DS_Doi_Tac()
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
            command.CommandText = "select * from DOITAC";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void DS_Doi_Tac_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string MADT = textBox1.Text;
            command = connection.CreateCommand();
            command.CommandText = "select * from DOITAC WHERE MADT = '" + MADT + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        string MADT;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            MADT = textBox1.Text;
        }

        string MACH;
        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select * from CUAHANG WHERE MADT = '" + MADT + "'";
            adapter2.SelectCommand = command;
            table2.Clear();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            MACH = textBox2.Text;
            command = connection.CreateCommand();
            command.CommandText = "select * from CUAHANG WHERE MACH = '" + MACH + "'";
            adapter2.SelectCommand = command;
            table2.Clear();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form formMonAn = new Danh_Sach_Mon_An(MACH);
            this.Hide();
            formMonAn.ShowDialog();
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView2.CurrentRow.Index;
            textBox2.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            MACH = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
