using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QL_BanHang.Object;

namespace QL_BanHang.Model
{
    class HoaDonBanHangMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = @"select hd.MaHD,hd.NgayLamHD, nv.TenNV,kh.TenKH,hd.TongTien from NhanVien nv,KhachHang kh, HoaDonBanHang hd where hd.MaKH = kh.MaKH and hd.MaNV = nv.MaNV";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.strConn;
            try
            {
                con.OpenConnect();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return dt;
        }

        public bool AddHoaDonBanHang(HoaDonBanHangObj hdbhObj)
        {
            cmd.CommandText = "Insert into HoaDonBanHang values('" + hdbhObj.MaHD1 + "',CONVERT(date,'" + hdbhObj.NgayLamHD1.ToShortDateString() + "',103)  ,'" + hdbhObj.MaNV1 + "','" + hdbhObj.MaKH1 + "','" + hdbhObj.TongTien1 + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.strConn;
            try
            {
                con.OpenConnect();
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return false;
        }

        public bool DeleteHoaDonBanHang(string ma)
        {
            cmd.CommandText = "Delete HoaDonBanHang where MaHD='" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.strConn;
            try
            {
                con.OpenConnect();
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return false;
        }
    }
}
