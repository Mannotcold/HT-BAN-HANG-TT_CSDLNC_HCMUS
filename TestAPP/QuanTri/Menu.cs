using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAPP.QuanTri
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new QuanTri.Duyet_Thanh_Vien();
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new QuanTri.Update_TK();
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmQT_XemTT = new QuanTri.Thong_Tin_Quan_Tri(TaiKhoan);
            MessageBox.Show(TaiKhoan);
            frmQT_XemTT.ShowDialog();
            this.Show();
        }
    }
}
