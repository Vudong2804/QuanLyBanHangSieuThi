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
    class ChiTietHoaDonMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select ct.MaHD,mh.TenMH,ct.DonGia,ct.SoLuong from ChiTietHoaDon ct,MatHang mh where ct.MaMH = mh.MaMH and MaHD='"+ma+"'";
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

        public bool AddChiTietHoaDon(DataTable dt)
        {
           
            try
            {
                for (int i=0; i < dt.Rows.Count; i++)
                {
                    cmd.CommandText = "Insert into ChiTietHoaDon values('" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString() + "','" + dt.Rows[i][2].ToString() + "','" + dt.Rows[i][3].ToString() + "','" + dt.Rows[i][4].ToString() + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.strConn;
                    con.OpenConnect();
                    cmd.ExecuteNonQuery();
                    con.CloseConnection();
                }
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

        public bool DeleteChiTietHoaDon(string ma)
        {
            cmd.CommandText = "Delete ChiTietHoaDon where MaHD='" + ma + "'";
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
