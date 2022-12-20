using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAPP.TaiXe
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
            Form frmKH_XemTT = new TaiXe.Thong_Tin_Ca_Nhan(TaiKhoan);
            MessageBox.Show(TaiKhoan);
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
