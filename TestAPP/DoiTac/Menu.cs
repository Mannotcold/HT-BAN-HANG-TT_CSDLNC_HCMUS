using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAPP.DoiTac
{
    public partial class Menu : Form
    {
        private string TaiKhoan;
        private void label3_Click(object sender, EventArgs e)
        {

        }
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
            Form frmDT_XemTT = new DoiTac.Thong_Tin_Doi_Tac(TaiKhoan);
            MessageBox.Show(TaiKhoan);
            frmDT_XemTT.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmDT_XemTT = new DoiTac.Ky_Hop_Dong(TaiKhoan);
            MessageBox.Show(TaiKhoan);
            frmDT_XemTT.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
