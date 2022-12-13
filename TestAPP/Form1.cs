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

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Hiển thị data
        private void Form1_Load(object sender, EventArgs e)
        {
            //connection = new SqlConnection(str);
            //connection.Open();
            //loaddata();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        //Hiển thị data
        //void loaddata()
        //{
        //    command = connection.CreateCommand();
        //    command.CommandText = "select * from TAIKHOAN";
        //    adapter.SelectCommand = command;
        //    table.Clear();
        //    adapter.Fill(table);
        //    dataGridView1.DataSource = table;
        //}

        //đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                //string account_type = "";
                connection.Open();
                string sql = "select * from TAIKHOAN WHERE TEN_TK = '" + username + "' AND MATKHAU = '" + password + "'";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                
                if (dta.Read() == true)
                {
                    string result = $"Bạn đã đăng nhập thành công";
                    MessageBox.Show("Thành công");
                    string account_type = dta.GetString(2);
                    MessageBox.Show(account_type);
                    if (account_type == "KH")
                    {
                        //Form formKhachHang = new KhachHang.Menu(ma);
                        //this.Hide();
                        //formKhachHang.ShowDialog();
                        //this.Close();
                    }
                    else if (account_type == "NV")
                    {
                        Form formKhachHang = new NhanSu.Menu();
                        this.Hide();
                        formKhachHang.ShowDialog();
                        this.Close();
                    }
                    else if (account_type == "TX")
                    {
                        Form formKhachHang = new TaiXe.Menu();
                        this.Hide();
                        formKhachHang.ShowDialog();
                        this.Close();
                    }
                    else if (account_type == "QT")
                    {
                        Form formKhachHang = new QuanTri.Menu();
                        this.Hide();
                        formKhachHang.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("sai");
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi kết nối");
            }
            
        
}
        //register
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                Form formKhachHang = new Register();
    
                this.Hide();
                formKhachHang.ShowDialog();
                this.Close();
               
            }
            catch (Exception )
            {
                string mess = "Đăng nhập không thành công, vui lòng kiểm tra thông tin";
                MessageBox.Show(mess, "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

namespace TaiXe
{
    class Menu : Form
    {
    }
}