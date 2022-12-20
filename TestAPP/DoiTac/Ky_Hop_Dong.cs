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
    public partial class Ky_Hop_Dong : Form
    {
        private string TaiKhoan;
        public Ky_Hop_Dong()
        {
            InitializeComponent();
        }
        public Ky_Hop_Dong(string ma)
        {
            InitializeComponent();
            this.TaiKhoan = ma;
        }



        private void Ky_Hop_Dong_Load(object sender, EventArgs e)
        {

        }
    }
}
