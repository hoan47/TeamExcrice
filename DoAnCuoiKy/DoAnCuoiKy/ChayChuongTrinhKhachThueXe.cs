using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnCuoiKy
{
    static internal class ChayChuongTrinhKhachThueXe
    {
        static public void ChuongTrinhKhachThueXe()
        {
            switch (DauVaoBanPhim.Int(1, 3, "Ban muon:\n1. Chon khach thue xe.\n2. Them khach xe.\n3. Quay lai.\nChon 1 trong 3: "))
            {
                case 1:
                    XuLyChonKhachThueXe();
                    break;
                case 2:
                    XyLyKhoiTaoKhachThueXe();
                    break;
                case 3:
                    ChayChuongTrinh.ChuongTrinh();
                    break;
            }
        }
        private static void XuLyChonKhachThueXe()
        {
            if (DuLieu.danhSachKhachThueXe.Count == 0)
            {
                Console.WriteLine("Khong ton tai khach thue xe.\n");
                ChayChuongTrinh.ChuongTrinh();
                return;
            }
            KhachThueXe.XuatDanhSachKhachThueXe(DuLieu.danhSachKhachThueXe);
            int luaChon = DauVaoBanPhim.Int(1, DuLieu.danhSachKhachThueXe.Count + 1, (DuLieu.danhSachKhachThueXe.Count + 1).ToString() + ". Quay lai.\nChon 1 trong " + DuLieu.danhSachKhachThueXe.Count.ToString() + " khach thue xe: ");

            if (luaChon == DuLieu.danhSachKhachThueXe.Count + 1)
            {
                ChayChuongTrinh.ChuongTrinh();
            }
            else
            {
                KhachThueXe khachThueXe = DuLieu.danhSachKhachThueXe[luaChon - 1];
                Console.WriteLine("Ban co ten la: " + khachThueXe.HoTen);
                XuLyhachThueXe(khachThueXe);
            }
        }
        private static void XuLyhachThueXe(KhachThueXe khachThueXe)
        {
            switch (DauVaoBanPhim.Int(1, 3, "Ban muon:\n1. Tim xe.\n2. Xem xe dang thue.\n3. Quay lai.\nChon 1 trong 3: "))
            {
                case 1:
                    XuLyTimXe(khachThueXe);
                    break;
                case 2:
                    XuLyXemXeDaThue(khachThueXe);
                    break;
                case 3:
                    XuLyChonKhachThueXe();
                    break;
            }
        }
        private static void XuLyTimXe(KhachThueXe khachThueXe)
        {
            Xe.EPhanLoai loaiXe = DauVaoBanPhim.LoaiXe();
            decimal giaTu = DauVaoBanPhim.Decimal("Gia tu: ");
            decimal giaDen = DauVaoBanPhim.Decimal("Gia den: ");
            List<Xe> danhSachXeTimDuoc = DuLieu.danhSachChuXe.SelectMany(chuXe => chuXe.TimXe(loaiXe, giaTu, giaDen)).ToList();

            if (danhSachXeTimDuoc.Count > 0)
            {
                XuLyChonXe(khachThueXe, danhSachXeTimDuoc);
            }
            else
            {
                XuLyTimXe(khachThueXe);
            }
        }
        private static void XuLyChonXe(KhachThueXe khachThueXe , List<Xe> danhSachXe)
        {
            Xe.XuatDanhSachXe(danhSachXe);
            Xe.XuatDanhSachXe(danhSachXe);
            Xe xe = danhSachXe[DauVaoBanPhim.Int(1, danhSachXe.Count, "Chon 1 trong " + danhSachXe.Count.ToString() + " xe: ") - 1];

            xe.XuatThongTinXe();
            switch(DauVaoBanPhim.Int(1, 3, "Ban muon:\n1. Xem hop dong.\n2. Xem danh gia.\n3. Quay lai.\nChon 1 trong 3: "))
            {
                case 1:
                    XuLyKhoiTaoHopDong(khachThueXe, xe);
                    break;
                case 2:
                    XuLyXemDanhGia(xe);
                    break;
                case 3:
                    XuLyhachThueXe(khachThueXe);
                    break;
            }
        }
        private static void XuLyXemDanhGia(Xe xe)
        {
            Console.WriteLine("Danh gia cua khach hang truoc danh cho chu xe:");
            xe.ChuXe.DanhGia.XuatToanBoDanhGia();
            Console.WriteLine("Danh gia cua khach hang truoc danh cho xe:");
            xe.DanhGia.XuatToanBoDanhGia();
        }
        private static void XuLyKhoiTaoHopDong(KhachThueXe khachThueXe, Xe xe)
        {
            TaiXe.XuatDanhSachTaiXe(DuLieu.danhSachTaiXe);
            HopDongThueXe hopDong = HopDongThueXe.KhoiTao(xe, DuLieu.danhSachTaiXe, khachThueXe);
            hopDong.XemHopDong();
            switch(DauVaoBanPhim.Int(1, 2, "Ban muon:\n1. Thue xe.\n2. Quay lai.\nChon 1 trong 2: "))
            {
                case 1:
                    hopDong.ThanhToan();
                    DuLieu.danhSachHopDongThueXe.Add(hopDong);
                    XuLyhachThueXe(khachThueXe);
                    break;
                case 2:
                    XuLyhachThueXe(khachThueXe);
                    break;
            }
        }
        private static void XuLyXemXeDaThue(KhachThueXe khachThueXe)
        {
            khachThueXe.XuatDanhSachXeDaThue();
            if (khachThueXe.DanhSachXeDaThue.Count == 0)
            {
                Console.WriteLine("Khong ton tai xe da thue.\n");
                XuLyhachThueXe(khachThueXe);
            }
            else
            {
                int luaChon = DauVaoBanPhim.Int(1, DuLieu.danhSachKhachThueXe.Count + 1, "Ban muon:\n" + (khachThueXe.DanhSachXeDaThue.Count + 1).ToString() + ". Quay lai.\nChon 1 trong " + khachThueXe.DanhSachXeDaThue.Count.ToString() + " xe: ");
                
                if (luaChon == khachThueXe.DanhSachXeDaThue.Count + 1)
                {
                    XuLyhachThueXe(khachThueXe);
                    return;
                }
                XuLyXemHopDong(khachThueXe, khachThueXe.DanhSachXeDaThue[luaChon - 1]);
            }
        }
        private static void XuLyXemHopDong(KhachThueXe khachThueXe, Xe xe)
        {
            HopDongThueXe hopDong = HopDongThueXe.DanhSachHopDong[new Tuple<ChuXe, KhachThueXe, Xe>(xe.ChuXe, khachThueXe, xe)];

            switch (DauVaoBanPhim.Int(1, 4, "Ban muon:\n1. Xem cac chi phi phat sinh.\n2. Ket thuc hop dong.\n3. Ban muon danh gia.\n4. Quay lai.\nChon 1 trong 4: "))
            {
                case 1:
                    hopDong.CacChiPhiPhatSinh(DauVaoBanPhim.Bool("Lam xuoc xe (true hoac false): "), DauVaoBanPhim.Bool("Ban lam be banh (true hoac false): "), DauVaoBanPhim.Bool("Lam hu den (true hoac false): "), DauVaoBanPhim.Int(0, 365, "So ngay tra tre: "));
                    break;
                case 2:
                    DuLieu.danhSachHopDongThueXe.Remove(hopDong);
                    hopDong.KetThucThueXe(DauVaoBanPhim.Bool("Lam xuoc xe (true hoac false): "), DauVaoBanPhim.Bool("Ban lam be banh (true hoac false): "), DauVaoBanPhim.Bool("Lam hu den (true hoac false): "), DauVaoBanPhim.Int(0, 365, "So ngay tra tre: "));
                    break;
                case 3:
                    ChuongTrinhDanhGia(khachThueXe, xe);
                    break;
                case 4:
                    break;
            }
            XuLyXemXeDaThue(khachThueXe);
        }
        private static void ChuongTrinhDanhGia(KhachThueXe khachThueXe, Xe xe)
        {
            switch(DauVaoBanPhim.Int(1, 5, "Ban muon:\n1. Danh gia chu xe.\n2. Ban muon danh gia xe.\n3. Ban muon xem danh gia.\n4. Danh gia tai xe.\n5. Quay lai.\nChon 1 trong 5: "))
            {
                case 1:
                    xe.ChuXe.DanhGia.ThemDanhGia(DanhGia.KhoiTao(khachThueXe));
                    DanhGiaThanhCong();
                    break;
                case 2:
                    xe.DanhGia.ThemDanhGia(DanhGia.KhoiTao(khachThueXe));
                    DanhGiaThanhCong();
                    break;
                case 3:
                    XuLyXemDanhGia(xe);
                    break;
                case 4:
                    TaiXe taiXe = HopDongThueXe.DanhSachHopDong[new Tuple<ChuXe, KhachThueXe, Xe>(xe.ChuXe, khachThueXe, xe)].TaiXe;

                    if (taiXe == null)
                    {
                        Console.WriteLine("Khong ton tai tai xe.\n");
                    }
                    else
                    {
                        taiXe.DanhGia.ThemDanhGia(DanhGia.KhoiTao(khachThueXe));
                        DanhGiaThanhCong();
                    }
                    break;
                case 5:
                    XuLyXemHopDong(khachThueXe, xe);
                    break;
            }

            void DanhGiaThanhCong()
            {
                Console.WriteLine("Danh gia thanh cong.\n");
                ChuongTrinhDanhGia(khachThueXe, xe);
            }
        }
        private static void XyLyKhoiTaoKhachThueXe()
        {
            NganHang nganHang = NganHang.KhoiTao();

            DuLieu.danhSachNganHang.Add(nganHang);
            DuLieu.danhSachKhachThueXe.Add(KhachThueXe.KhoiTao(nganHang));
            Console.WriteLine("Khoi tao thanh cong.\n");
            ChuongTrinhKhachThueXe();
        }
    }
}
