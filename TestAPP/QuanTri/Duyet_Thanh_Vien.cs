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


namespace TestAPP.QuanTri
{
    public partial class Duyet_Thanh_Vien : Form
    {
        public Duyet_Thanh_Vien()
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
            command.CommandText = "select * from TAIKHOAN";
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

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string TaiKhoan = textBox1.Text;
            string sql = "select * from TAIKHOAN WHERE TEN_TK = '" + TaiKhoan + "'";
            command = connection.CreateCommand();
            command.CommandText = "select * from TAIKHOAN WHERE TEN_TK = '" + TaiKhoan + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string type = "True";
            command = connection.CreateCommand();
            command.CommandText = "UPDATE TAIKHOAN set TRANGTHAI = '" + type + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Xét duyệt thành công!");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string type = "False";
            command = connection.CreateCommand();
            command.CommandText = "UPDATE TAIKHOAN set TRANGTHAI = '" + type + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Khóa thành công!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
