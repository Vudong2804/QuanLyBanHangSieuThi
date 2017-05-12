using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_BanHang.Model;
using QL_BanHang.Object;
using QL_BanHang.View;

namespace QL_BanHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNguoiQuanLy_Click(object sender, EventArgs e)
        {
            frmNguoiQuanLy ds = new frmNguoiQuanLy();
            this.Hide();            // đóng form cũ lại
            ds.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien ds = new frmNhanVien();
            this.Hide();            // đóng form cũ lại
            ds.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang ds = new frmKhachHang();
            ds.Show();
        }

        private void btnMatHang_Click(object sender, EventArgs e)
        {
            frmMatHang ds = new frmMatHang();
            this.Hide();            // đóng form cũ lại
            ds.Show();
        }

        private void btnHoaDonBanHang_Click(object sender, EventArgs e)
        {
            frmHoaDon ds = new frmHoaDon();
            this.Hide();            // đóng form cũ lại
            ds.Show();
        }

        private void btnPhanLoai_Click(object sender, EventArgs e)
        {
            frmPhanLoai ds = new frmPhanLoai();
            this.Hide();            // đóng form cũ lại
            ds.Show();
        }

        private void btnQuayHang_Click(object sender, EventArgs e)
        {
            frmQuayHang ds = new frmQuayHang();
            this.Hide();            // đóng form cũ lại
            ds.Show();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCC ds = new frmNhaCC();
            this.Hide();            // đóng form cũ lại
            ds.Show();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            frmKho ds = new frmKho();
            this.Hide();            // đóng form cũ lại
            ds.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
