using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; 

namespace HeThongThiTracNghiem
{
    public class cauhoi
    {
        public int MaCauHoi { get; set; }
        public string MaMon { get; set; }
        public string DoKho { get; set; }
        public string NoiDung { get; set; }
        public string DapAnA { get; set; }
        public string DapAnB { get; set; }
        public string DapAnC { get; set; }
        public string DapAnD { get; set; }
        public string DapAnDung { get; set; }
    }

    public class dethi
    {
        public int MaDeThi { get; set; }
        public string MaMon { get; set; }
        public string TenDe { get; set; }
        public int ThoiGianPhut { get; set; }
        public int SoLuongCau { get; set; }
        public int SoLanDuocThi { get; set; }
        public decimal DiemToiDa { get; set; }
    }

    public class ketqua
    {
        public int MaBaiThi { get; set; }
        public int TongSoCau { get; set; }
        public int SoCauDung { get; set; }
        public int SoCauSai { get; set; }
        public int SoCauChuaLam { get; set; }
        public double Diem { get; set; }
        public decimal DiemToiDa { get; set; }
    }

    // ==========================================
    // 2. CLASS XỬ LÝ CHÍNH
    // ==========================================
    public static class chamthi
    {
        private const string connectionString =
            @"Data Source=localhost;Initial Catalog=Hethongthitracnghiem;Integrated Security=True;TrustServerCertificate=True";

        public static dethi DeThiHienTai { get; private set; }
        public static List<cauhoi> Danhsach { get; } = new List<cauhoi>();
        public static Dictionary<int, string> DapAn { get; } = new Dictionary<int, string>();
        public static int MaBaiThi { get; private set; } = 0;
        public static int MaTaiKhoan { get; set; } = 0; 
        public static DateTime ThoiGianBatDau { get; private set; }
        public static DateTime ThoiGianKetThuc { get; private set; }
        public static bool DaNop { get; private set; } = false;
        public static string LoiCuoi { get; private set; } = null;

        public static bool HetGio =>
            ThoiGianKetThuc != default(DateTime) && DateTime.Now >= ThoiGianKetThuc;

        // ════════════════════════════════════════════════════════
        // LẤY DANH SÁCH ĐỀ THI THEO MÔN
        // ════════════════════════════════════════════════════════
        public static List<dethi> LayDanhSachDeThi(string maMon)
        {
            List<dethi> list = new List<dethi>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT maDeThi, maMon, tenDe, thoiGianPhut, soLuongCau,
                               soLanDuocThi, diemToiDa
                        FROM   DeThi
                        WHERE  maMon = @mon
                        ORDER  BY maDeThi";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@mon", maMon);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                dethi d = new dethi();
                                d.MaDeThi = Convert.ToInt32(rd["maDeThi"]);
                                d.MaMon = rd["maMon"].ToString();
                                d.TenDe = rd["tenDe"].ToString();
                                d.ThoiGianPhut = Convert.ToInt32(rd["thoiGianPhut"]);
                                d.SoLuongCau = Convert.ToInt32(rd["soLuongCau"]);
                                d.SoLanDuocThi = Convert.ToInt32(rd["soLanDuocThi"]);
                                d.DiemToiDa = Convert.ToDecimal(rd["diemToiDa"]);
                                list.Add(d);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { LoiCuoi = ex.Message; }
            return list;
        }

        // ════════════════════════════════════════════════════════
        // BẮT ĐẦU BÀI THI
        // ════════════════════════════════════════════════════════
        public static bool batdau(int maDeThi, int maTaiKhoan)
        {
            ResetPhien();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (!LoadDeThi(conn, maDeThi)) return false;
                    DonBaiThiDangLamCu(conn, maDeThi, maTaiKhoan);
                    if (!KiemTraSoLanThi(conn, maDeThi, maTaiKhoan)) return false;
                    if (!LoadCauHoi(conn, maDeThi)) return false;

                    MaBaiThi = TaoBaiThi(conn, maDeThi, maTaiKhoan);
                    if (MaBaiThi <= 0)
                    {
                        LoiCuoi = "Không tạo được bản ghi BaiThi.";
                        return false;
                    }
                }

                MaTaiKhoan = maTaiKhoan;
                ThoiGianBatDau = DateTime.Now;
                ThoiGianKetThuc = ThoiGianBatDau.AddMinutes(DeThiHienTai.ThoiGianPhut);
                DaNop = false;
                return true;
            }
            catch (Exception ex)
            {
                LoiCuoi = ex.Message;
                MessageBox.Show("Không bắt đầu được bài thi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ════════════════════════════════════════════════════════
        // LƯU ĐÁP ÁN
        // ════════════════════════════════════════════════════════
        public static void luuCauTraLoi(int index, string dapAn)
        {
            if (index < 0 || index >= Danhsach.Count) return;
            if (string.IsNullOrWhiteSpace(dapAn))
            {
                DapAn.Remove(index);
                return;
            }
            dapAn = dapAn.Trim().ToUpper();
            if (dapAn == "A" || dapAn == "B" || dapAn == "C" || dapAn == "D")
                DapAn[index] = dapAn;
        }

        // ════════════════════════════════════════════════════════
        // NỘP BÀI + CHẤM ĐIỂM
        // ════════════════════════════════════════════════════════
        public static ketqua nopbai(bool hienThiHopThoai = true)
        {
            if (DaNop) return null;
            if (MaBaiThi <= 0) { LoiCuoi = "Chưa bắt đầu bài thi."; return null; }

            ketqua kq = new ketqua();
            kq.MaBaiThi = MaBaiThi;
            kq.TongSoCau = Danhsach.Count;
            kq.DiemToiDa = DeThiHienTai.DiemToiDa;

            int dung = 0;
            int chuaLam = 0;

            for (int i = 0; i < Danhsach.Count; i++)
            {
                if (DapAn.ContainsKey(i) && !string.IsNullOrWhiteSpace(DapAn[i]))
                {
                    string da = DapAn[i].Trim();
                    string dapAnDung = Danhsach[i].DapAnDung == null ? "" : Danhsach[i].DapAnDung.Trim();
                    if (string.Equals(da, dapAnDung, StringComparison.OrdinalIgnoreCase))
                        dung++;
                }
                else chuaLam++;
            }

            kq.SoCauDung = dung;
            kq.SoCauChuaLam = chuaLam;
            kq.SoCauSai = kq.TongSoCau - dung - chuaLam;
            kq.Diem = kq.TongSoCau > 0
                ? Math.Round((double)dung / kq.TongSoCau * (double)DeThiHienTai.DiemToiDa, 2)
                : 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            GhiChiTietBaiThi(conn, trans);
                            CapNhatBaiThi(conn, trans, kq);
                            trans.Commit();
                        }
                        catch { trans.Rollback(); throw; }
                    }
                }
            }
            catch (Exception ex)
            {
                LoiCuoi = ex.Message;
                MessageBox.Show("Lỗi khi lưu bài thi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            DaNop = true;

            if (hienThiHopThoai)
            {
                MessageBox.Show(
                    $"Tổng số câu hỏi: {kq.TongSoCau}\n" +
                    $"Số câu đúng:     {kq.SoCauDung}\n" +
                    $"Số câu sai:      {kq.SoCauSai}\n" +
                    $"Số câu chưa làm: {kq.SoCauChuaLam}\n" +
                    $"Điểm:            {kq.Diem:F2} / {kq.DiemToiDa:F1}",
                    "Kết quả thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return kq;
        }

        // ════════════════════════════════════════════════════════
        // ĐẾM NGƯỢC
        // ════════════════════════════════════════════════════════
        public static TimeSpan ThoiGianConLai()
        {
            if (ThoiGianKetThuc == default(DateTime)) return TimeSpan.Zero;
            TimeSpan conlai = ThoiGianKetThuc - DateTime.Now;
            return conlai > TimeSpan.Zero ? conlai : TimeSpan.Zero;
        }

        // ════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════
        private static void ResetPhien()
        {
            Danhsach.Clear();
            DapAn.Clear();
            DeThiHienTai = null;
            MaBaiThi = 0;
            MaTaiKhoan = 0;
            ThoiGianBatDau = default(DateTime);
            ThoiGianKetThuc = default(DateTime);
            DaNop = false;
            LoiCuoi = null;
        }

        private static bool LoadDeThi(SqlConnection conn, int maDeThi)
        {
            string sql = @"
                SELECT maDeThi, maMon, tenDe, thoiGianPhut, soLuongCau,
                       soLanDuocThi, diemToiDa
                FROM   DeThi
                WHERE  maDeThi = @id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", maDeThi);
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                    {
                        LoiCuoi = "Không tìm thấy đề thi mã " + maDeThi + ".";
                        return false;
                    }
                    DeThiHienTai = new dethi();
                    DeThiHienTai.MaDeThi = Convert.ToInt32(rd["maDeThi"]);
                    DeThiHienTai.MaMon = rd["maMon"].ToString();
                    DeThiHienTai.TenDe = rd["tenDe"].ToString();
                    DeThiHienTai.ThoiGianPhut = Convert.ToInt32(rd["thoiGianPhut"]);
                    DeThiHienTai.SoLuongCau = Convert.ToInt32(rd["soLuongCau"]);
                    DeThiHienTai.SoLanDuocThi = Convert.ToInt32(rd["soLanDuocThi"]);
                    DeThiHienTai.DiemToiDa = Convert.ToDecimal(rd["diemToiDa"]);
                }
            }
            return true;
        }

        private static void DonBaiThiDangLamCu(SqlConnection conn, int maDeThi, int maTaiKhoan)
        {
            string sql = @"
                UPDATE BaiThi
                SET    trangThai = 'Huy'
                WHERE  maDeThi    = @de
                  AND  maTaiKhoan = @tk
                  AND  trangThai  = 'DangLam'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@de", maDeThi);
                cmd.Parameters.AddWithValue("@tk", maTaiKhoan);
                cmd.ExecuteNonQuery();
            }
        }

        private static bool KiemTraSoLanThi(SqlConnection conn, int maDeThi, int maTaiKhoan)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   BaiThi
                WHERE  maDeThi    = @de
                  AND  maTaiKhoan = @tk
                  AND  trangThai IN ('DaNop', 'DaCham')";
            int daThi;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@de", maDeThi);
                cmd.Parameters.AddWithValue("@tk", maTaiKhoan);
                object obj = cmd.ExecuteScalar();
                daThi = (obj == null || obj == DBNull.Value) ? 0 : Convert.ToInt32(obj);
            }
            if (daThi >= DeThiHienTai.SoLanDuocThi)
            {
                LoiCuoi = string.Format("Bạn đã thi {0}/{1} lần. Không thể thi thêm.",
                    daThi, DeThiHienTai.SoLanDuocThi);
                return false;
            }
            return true;
        }

        private static bool LoadCauHoi(SqlConnection conn, int maDeThi)
        {
            string sql = @"
                SELECT ch.maCauHoi, ch.maMon, ch.doKho, ch.noiDung,
                       ch.dapAnA, ch.dapAnB, ch.dapAnC, ch.dapAnD, ch.dapAnDung
                FROM   ChiTietDeThi ct
                JOIN   CauHoi ch ON ch.maCauHoi = ct.maCauHoi
                WHERE  ct.maDeThi = @id
                ORDER  BY ch.maCauHoi";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", maDeThi);
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cauhoi ch = new cauhoi();
                        ch.MaCauHoi = Convert.ToInt32(rd["maCauHoi"]);
                        ch.MaMon = rd["maMon"].ToString();
                        ch.DoKho = rd["doKho"] == DBNull.Value ? "" : rd["doKho"].ToString();
                        ch.NoiDung = rd["noiDung"] == DBNull.Value ? "" : rd["noiDung"].ToString();
                        ch.DapAnA = rd["dapAnA"] == DBNull.Value ? "" : rd["dapAnA"].ToString();
                        ch.DapAnB = rd["dapAnB"] == DBNull.Value ? "" : rd["dapAnB"].ToString();
                        ch.DapAnC = rd["dapAnC"] == DBNull.Value ? "" : rd["dapAnC"].ToString();
                        ch.DapAnD = rd["dapAnD"] == DBNull.Value ? "" : rd["dapAnD"].ToString();
                        ch.DapAnDung = rd["dapAnDung"] == DBNull.Value ? "" : rd["dapAnDung"].ToString();
                        Danhsach.Add(ch);
                    }
                }
            }
            if (Danhsach.Count == 0)
            {
                LoiCuoi = "Đề thi chưa có câu hỏi nào.";
                return false;
            }
            return true;
        }

        private static int TaoBaiThi(SqlConnection conn, int maDeThi, int maTaiKhoan)
        {
            string sql = @"
                INSERT INTO BaiThi (maTaiKhoan, maDeThi, thoiGianBatDau, trangThai)
                OUTPUT INSERTED.maBaiThi
                VALUES (@tk, @de, @bd, 'DangLam')";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tk", maTaiKhoan);
                cmd.Parameters.AddWithValue("@de", maDeThi);
                cmd.Parameters.AddWithValue("@bd", DateTime.Now);
                object obj = cmd.ExecuteScalar();
                return (obj == null || obj == DBNull.Value) ? 0 : Convert.ToInt32(obj);
            }
        }

        private static void GhiChiTietBaiThi(SqlConnection conn, SqlTransaction trans)
        {
            string sql = @"
                INSERT INTO ChiTietBaiThi (maBaiThi, maCauHoi, dapAnChon, laDung)
                VALUES (@bai, @cau, @chon, @dung)";
            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                SqlParameter pBai = cmd.Parameters.Add("@bai", SqlDbType.Int);
                SqlParameter pCau = cmd.Parameters.Add("@cau", SqlDbType.Int);
                SqlParameter pChon = cmd.Parameters.Add("@chon", SqlDbType.VarChar, 1);
                SqlParameter pDung = cmd.Parameters.Add("@dung", SqlDbType.Bit);

                for (int i = 0; i < Danhsach.Count; i++)
                {
                    string chon = null;
                    if (DapAn.ContainsKey(i) && !string.IsNullOrWhiteSpace(DapAn[i]))
                        chon = DapAn[i];

                    object laDung;
                    if (chon == null) laDung = DBNull.Value;
                    else
                    {
                        string dapAnDung = Danhsach[i].DapAnDung == null ? "" : Danhsach[i].DapAnDung;
                        laDung = string.Equals(chon, dapAnDung, StringComparison.OrdinalIgnoreCase);
                    }

                    pBai.Value = MaBaiThi;
                    pCau.Value = Danhsach[i].MaCauHoi;
                    pChon.Value = (chon == null) ? (object)DBNull.Value : chon;
                    pDung.Value = laDung;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void CapNhatBaiThi(SqlConnection conn, SqlTransaction trans, ketqua kq)
        {
            string sql = @"
                UPDATE BaiThi
                SET    thoiGianNop = @nop,
                       diem        = @diem,
                       trangThai   = 'DaCham'
                WHERE  maBaiThi    = @bai";
            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                cmd.Parameters.AddWithValue("@nop", DateTime.Now);
                cmd.Parameters.AddWithValue("@diem", Convert.ToDecimal(kq.Diem));
                cmd.Parameters.AddWithValue("@bai", kq.MaBaiThi);
                cmd.ExecuteNonQuery();
            }
        }
    }
}