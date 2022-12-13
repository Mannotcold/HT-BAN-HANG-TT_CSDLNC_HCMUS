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
namespace Login.QuanTri
{
    public partial class Xem_Kho : Form
    {
        public Xem_Kho()
        {
            InitializeComponent();
        }

        private void Xem_Kho_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = CUA_HANG_HOA;Integrated Security = True");
            string makho = textBox1.Text.Trim();
            if(makho == "")
            {
                MessageBox.Show("Mã kho không được trống!", "Chú ý");
            }
            else
            {
                try
                {
                    cnn.Open();
                    string sql = $"select * from CHI_TIET_KHO WHERE Ma_KHO = '{makho}'";
                    SqlCommand com = new SqlCommand(sql, cnn);
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caution");
                }
                finally
                {
                    cnn.Close();
                }
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
