using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAPP.NhanVien
{
    public partial class Menu : Form
    {

        private string TaiKhoan;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new NhanVien.Thong_Tin_Nhan_Vien(TaiKhoan);
            
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form frmKH_XemTT = new NhanVien.Hop_Dong();
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new NhanVien.Thong_Ke_Don_Hang();
            frmKH_XemTT.ShowDialog();
            this.Show();
        }
    }
}
