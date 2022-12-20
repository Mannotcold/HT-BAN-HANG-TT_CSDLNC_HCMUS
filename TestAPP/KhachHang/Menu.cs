using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAPP.KhachHang
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private string TaiKhoan;
        
        public Menu(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new KhachHang.Thong_Tin_Khach_Hang(TaiKhoan);
            MessageBox.Show(TaiKhoan);
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_MuaHang = new KhachHang.DS_Doi_Tac();
            frmKH_MuaHang.ShowDialog();
            this.Show();
        }
    }
}
