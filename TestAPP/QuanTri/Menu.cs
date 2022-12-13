using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.QuanTri
{
    public partial class Menu : Form
    {
        private string MaQT;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string ma)
        {
            this.MaQT = ma;
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmQT_QLSP = new QuanTri.QuanLy_SanPham(MaQT);
            frmQT_QLSP.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmQT_XemTK = new QuanTri.Xem_Kho();
            frmQT_XemTK.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmQT_XemPN = new QuanTri.Xem_PhieuNhap(MaQT);
            frmQT_XemPN.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmQT_XemPX = new QuanTri.Xem_PhieuXuat(MaQT);
            frmQT_XemPX.ShowDialog();
            this.Show();
        }
    }
}
