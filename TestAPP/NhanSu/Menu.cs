using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.NhanSu
{
    public partial class Menu : Form
    {
        private string MaNV;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmNV_DiemDanh = new NhanSu.DiemDanh(MaNV);
            frmNV_DiemDanh.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmNV_XemLSL = new NhanSu.Xem_LichSuLuong(MaNV);
            frmNV_XemLSL.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmNV_XemDH = new NhanSu.Xem_DonHang(MaNV);
            frmNV_XemDH.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmNV_XemDH = new NhanSu.ThongKe_SLDH(MaNV);
            frmNV_XemDH.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
