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
using System.Data;

namespace QL_BanHang.View
{
    public partial class frmHoaDon : Form
    {
        HoaDonBanHangMod hdbh = new HoaDonBanHangMod();
        HoaDonBanHangObj hdbhObj = new HoaDonBanHangObj();
        ChiTietHoaDonMod cthd = new ChiTietHoaDonMod();
        MatHangMod mh = new MatHangMod();
        DataTable dtDSCT = new System.Data.DataTable();
        int vitriClick = 0;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = hdbh.GetData();
            dgvHDBH.DataSource = dt;
            Binding();
            Dis_en(false);

        }
        private void Binding()
        {
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", dgvHDBH.DataSource, "MaHD");
            dtNgayLamHD.DataBindings.Clear();
            dtNgayLamHD.DataBindings.Add("Text", dgvHDBH.DataSource, "NgayLamHD");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dgvHDBH.DataSource, "TenNV");
            cmbKhachHang.DataBindings.Clear();
            cmbKhachHang.DataBindings.Add("Text", dgvHDBH.DataSource, "TenKH");
            //txtTongTien.DataBindings.Clear();
            //txtTongTien.DataBindings.Add("Text", dgvHDBH.DataSource, "TongTien");
        }
        private void Binding1()
        {
            cmbHangHoa.DataBindings.Clear();
            cmbHangHoa.DataBindings.Add("Text", dgvCTHD.DataSource, "TenMH");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dgvCTHD.DataSource, "DonGia");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dgvCTHD.DataSource, "SoLuong");
            //txt.DataBindings.Clear();
            //txtTongTien.DataBindings.Add("Text", dgvHDBH.DataSource, "TongTien");
        }
        private void Load_cmbKhachhang()
        {
            KhachHangMod kh = new KhachHangMod();
            cmbKhachHang.DataSource = kh.GetData();
            cmbKhachHang.DisplayMember = "TenKH";
            cmbKhachHang.ValueMember = "MaKH";
        }
        private void Load_cmbHangHoa()
        {
            MatHangMod hh = new MatHangMod();
            cmbHangHoa.DataSource = hh.GetData();
            cmbHangHoa.DisplayMember = "TenMH";
            cmbHangHoa.ValueMember = "MaMH";
        }
        private void Clear()
        {
            txtMaHD.Text = "";
            txtTenNV.Text = "";
            dtNgayLamHD.Text = "";
          //  txtTongTien.Text = "";
            Load_cmbKhachhang();
        }
        private void Dis_en(bool e)
        {
            txtMaHD.Enabled = e;
            txtTenNV.Enabled = e;
            cmbKhachHang.Enabled = e;
            dtNgayLamHD.Enabled = e;
           // txtTongTien.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThemMH.Enabled = e;
            btnBotMH.Enabled = e;
            cmbHangHoa.Enabled = e;
            txtSoLuong.Enabled = e;
        }
        private void GanDuLieu(HoaDonBanHangObj hdbhObj)
        {
            hdbhObj.MaHD1 = txtMaHD.Text.ToString().Trim();
            hdbhObj.MaNV1 = txtTenNV.Text.ToString().Trim();
            hdbhObj.MaKH1 = cmbKhachHang.SelectedValue.ToString();
            hdbhObj.NgayLamHD1 = dtNgayLamHD.Value;
           // hdbhObj.TongTien1 = txtTongTien.Text.ToString().Trim();
        }
        private bool checktrung(string mahh)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][1].ToString() == mahh)
                    return true;
            return false;
        }
        private void capnhatSL(string mahh, int SL)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][1].ToString() == mahh)
                {
                    int soluong = int.Parse(dtDSCT.Rows[i][3].ToString()) + SL;
                    dtDSCT.Rows[i][3] = soluong;
                    double dongia = double.Parse(dtDSCT.Rows[i][2].ToString());
                    dtDSCT.Rows[i][4] = (dongia * soluong).ToString();
                    break;
                }
        }
        private bool kiemtraSL(string mahh, int sl)
        {
            DataTable dt = new DataTable();
            dt = mh.GetData("Where MaMH = '" + cmbHangHoa.SelectedValue.ToString() + "' and SoLuong>= " + sl);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }


        private void txtMaHD_textChange(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new System.Data.DataTable();
                dt = cthd.GetData(txtMaHD.Text.Trim());
                dgvCTHD.DataSource = dt;


            }
            catch
            {
                dgvCTHD.DataSource = null;
            }
            Binding1();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Dis_en(true);
            Clear();
            Load_cmbHangHoa();
            Load_cmbKhachhang();

            dtDSCT.Rows.Clear();
            //dtDSCT.Columns.Add("MaHD");
            dtDSCT.Columns.Add("MaMH");
            dtDSCT.Columns.Add("DonGia");
            dtDSCT.Columns.Add("SoLuong");
            dtDSCT.Columns.Add("ThanhTien");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thật sự muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (dr == DialogResult.Yes)
                {
                    if (hdbh.DeleteHoaDonBanHang(txtMaHD.Text.ToString().Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //frmNhanVien_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóakhông thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
                frmHoaDon_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GanDuLieu(hdbhObj);
            if (hdbh.AddHoaDonBanHang(hdbhObj))
            {
                DataTable dt = new System.Data.DataTable();
                dt = (DataTable)dgvCTHD.DataSource;
                if(cthd.AddChiTietHoaDon(dt))
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               else
                    MessageBox.Show("Thêm chi tiết không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frmHoaDon_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            frmHoaDon_Load(sender, e);
            Dis_en(false);
        }

        private void btnThemMH_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaHD.Text))
            {
                if (kiemtraSL(cmbHangHoa.SelectedValue.ToString(), int.Parse(txtSoLuong.Text.Trim())))
                {
                    if (!checktrung(cmbHangHoa.SelectedValue.ToString()))
                    {
                        DataRow dr = dtDSCT.NewRow();
                        dr[0] = txtMaHD.Text.Trim();
                        dr[1] = cmbHangHoa.SelectedValue.ToString();
                        dr[2] = txtDonGia.Text;
                        dr[3] = txtSoLuong.Text;
                        dr[4] = (double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text)).ToString();
                        dtDSCT.Rows.Add(dr);
                    }
                    else
                    {
                        capnhatSL(cmbHangHoa.SelectedValue.ToString(), int.Parse(txtSoLuong.Text));
                    }
                    dgvCTHD.DataSource = dtDSCT;
                }
                else
                {
                    MessageBox.Show("Số lượng không dủ", "Lỗi");
                    txtSoLuong.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã hóa đơn không được trống", "Lỗi");
                txtMaHD.Focus();
            }
        }

        private void btnBotMH_Click(object sender, EventArgs e)
        {
            if (vitriClick < dtDSCT.Rows.Count)
            {
                dtDSCT.Rows.RemoveAt(vitriClick);
                dgvCTHD.DataSource = dtDSCT;
            }
        }

        private void cmbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = mh.GetData("Where MaMH = '" + cmbHangHoa.SelectedValue.ToString() + "'");
            if (dt.Rows.Count > 0)
            {
                double gia = double.Parse(dt.Rows[0][2].ToString());

                txtDonGia.Text = (gia * 1.1).ToString();

                lbThanhTien.Text = (double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text)).ToString();
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            lbThanhTien.Text = (double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text)).ToString();
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitriClick = e.RowIndex;
        }

        private void lbTongTien_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= dtDSCT.Rows.Count; i++)
            {
                lbTongTien.Text = lbThanhTien.Text;
            }

        }
    }
}
