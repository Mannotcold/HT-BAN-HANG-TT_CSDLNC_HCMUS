using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.KhachHang
{
    public partial class Menu : Form
    {
        private string MaKH;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string ma)
        {
            InitializeComponent();
            this.MaKH = ma;
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
            Form frmKH_XemTT = new KhachHang.Xem_ThongTinCaNhan(MaKH);
            frmKH_XemTT.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemLSMH = new KhachHang.Xem_LichSuMuaHang(MaKH);
            frmKH_XemLSMH.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmKH_XemTT = new KhachHang.Xem_SP();
            frmKH_XemTT.ShowDialog();
            this.Show();
        }
    }
}
