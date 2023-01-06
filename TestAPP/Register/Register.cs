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
using Login;

namespace TestAPP.Register
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        string acount_type = "";
        string type = "False";
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                acount_type = "TX";
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                acount_type = "KH";
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                acount_type = "NV";
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                acount_type = "DT";
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

       
        //SqlConnection cnn;
        //SqlCommand command;
        //string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=HT_BANHANG_TT;Integrated Security=True";
        //SqlDataAdapter adapter = new SqlDataAdapter();
        //DataTable table = new DataTable();
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-O8J01RU8;Initial Catalog=BANHANG_TT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        
        private void button1_Click(object sender, EventArgs e)
        {


            connection = new SqlConnection(str);
            try
            {
                string username = textBox1.Text.Trim();
                string password = textBox3.Text.Trim();
                connection.Open();
                string sql = "insert into TAIKHOAN values ('" + username + "', '" + password + "','" + acount_type + "','" + type + "' )";

                SqlCommand com = new SqlCommand();
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                //com.ExecuteNonQuery();
                com.CommandType = CommandType.Text;
                com.CommandText = "insert into TAIKHOAN(TEN_TK,MATKHAU,LOAI_TK,TRANGTHAI) VALUES ('" + username + "','" + password + "','" + acount_type + "','" + type + "')";
                com.Connection = connection;
                //loaddata();
                int kq = com.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thàng công! Vui lòng đợi trong vài phút để quản tri viên xét duyệt.");
                    TaoMaKhoa();
                }
                else
                {
                    MessageBox.Show("Đăng ký không thàng công! Vui lòng xem lại tài khoản/mật khẩu.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form1();

            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        void TaoKhachHang()
        {

            string username = textBox1.Text.Trim();
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into KHACHHANG(MAKH,TEN_TK) VALUES ('" + MAKH + "','" + username + "')";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();

        }
        void TaoNhanVien()
        {

            string username = textBox1.Text.Trim();
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into NHANVIEN(MANV,TEN_TK) VALUES ('" + MANV + "','" + username + "')";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();

        }
        void TaoDoiTac()
        {

            string username = textBox1.Text.Trim();
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into DOITAC(MADT,TEN_TK,MASOTHUE) VALUES ('" + MADT + "','" + username + "','" + MaThueDT + "')";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();

        }
        void TaoTaiXe()
        {

            string username = textBox1.Text.Trim();
            connection = new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand();
            //Lấy dữ liệu về từ kết quả câu lệnh trên
            //ExecuteReader() dùng với select
            //ExecuteNonquery(); với inserrt update delete
            //com.ExecuteNonQuery();
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into TAIXE(MATX,TEN_TK) VALUES ('" + MATX + "','" + username + "')";
            com.Connection = connection;
            //loaddata();
            int kq = com.ExecuteNonQuery();

        }
        string MATX;
        string MADT;
        string MAKH;
        string MANV;
        string MaThueDT;
        void TaoMaKhoa()
        {
            connection = new SqlConnection(str);
            connection.Open();
            if(acount_type=="TX")
            {
                //Tạo mã đơn hàng mới
                string sql = "select COUNT(*) from TAIXE";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                while (dta.Read())
                {
                    int matx = dta.GetInt32(0) + 1000;
                    MATX = "MATX" + matx.ToString();
                }
                TaoTaiXe();
            }
            if (acount_type == "DT")
            {
                //Tạo mã đơn hàng mới
                string sql = "select COUNT(*) from DOITAC";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                while (dta.Read())
                {
                    int madt = dta.GetInt32(0) + 1000;
                    int mathue = dta.GetInt32(0) + 15720;
                    MADT = "MADT" + madt.ToString();
                    MaThueDT = mathue.ToString();
                }
                TaoDoiTac();
            }
            if (acount_type == "KH")
            {
                //Tạo mã đơn hàng mới
                string sql = "select COUNT(*) from KHACHHANG";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                while (dta.Read())
                {
                    int makh = dta.GetInt32(0) + 1000;
                    MAKH = "MAKH" + makh.ToString();
                }
                TaoKhachHang();
            }
            if (acount_type == "NV")
            {
                //Tạo mã đơn hàng mới
                string sql = "select COUNT(*) from NHANVIEN";

                SqlCommand com = new SqlCommand(sql, connection);
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                SqlDataReader dta = com.ExecuteReader();
                while (dta.Read())
                {
                    int manv = dta.GetInt32(0) + 1000;
                    MANV = "MANV" + manv.ToString();
                }
                TaoNhanVien();
            }

        }
    }
}
