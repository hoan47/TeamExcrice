using System;
using System.Collections.Generic;

namespace DoAnCuoiKy
{
    static internal class ChayChuongTrinhKhachThueXe
    {
        public static void ChuongTrinhChonKhachThueXe()
        {
            if (DuLieu.danhSachKhachThueXe.Count == 0)
            {
                Console.WriteLine("Khong ton tai khach thue xe.\n");
                ChayChuongTrinh.ChuongTrinh();
            }
            KhachThueXe.XuatDanhSachKhachThueXe(DuLieu.danhSachKhachThueXe);
            Console.WriteLine((DuLieu.danhSachChuXe.Count + 1).ToString() + ". Quay lai.");
            int luaChon = DauVaoBanPhim.Int(1, DuLieu.danhSachKhachThueXe.Count + 1, "Chon 1 trong " + DuLieu.danhSachKhachThueXe.Count.ToString() + " khach thue xe: ");

            if (luaChon == DuLieu.danhSachChuXe.Count + 1)
            {
                ChayChuongTrinh.ChuongTrinh();
            }
            else
            {
                KhachThueXe khachThueXe = DuLieu.danhSachKhachThueXe[luaChon - 1];
                Console.WriteLine("Ban co ten la: " + khachThueXe.HoTen);
                ChuongTrinhKhachThueXe(khachThueXe);
            }
        }
        private static void ChuongTrinhKhachThueXe(KhachThueXe khachThueXe)
        {
            Console.WriteLine("Ban muon:\n1. Tim xe.\n2. Xem xe dang thue.\n3. Quay lai.");
            switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
            {
                case 1:
                    ChuongTrinhTimXe(khachThueXe);
                    break;
                case 2:
                    ChuongTrinhXemXeDaThue(khachThueXe);
                    break;
                case 3:
                    ChayChuongTrinh.ChuongTrinh();
                    break;
            }
        }
        private static void ChuongTrinhTimXe(KhachThueXe khachThueXe)
        {
            Console.WriteLine("Ban muon tim loai xe:\n1. Xe may.\n2. Xe bon cho.\n3. Xe bay cho.\n4. Quay lai.");
            List<Xe> danhSachXeTimDuoc = new List<Xe>();

            switch (DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: "))
            {
                case 1:
                    danhSachXeTimDuoc = TimXe(Xe.EPhanLoai.XeMay);
                    break;
                case 2:
                    danhSachXeTimDuoc = TimXe(Xe.EPhanLoai.XeBonCho);
                    break;
                case 3:
                    danhSachXeTimDuoc = TimXe(Xe.EPhanLoai.XeBayCho);
                    break;
            }
            if(danhSachXeTimDuoc.Count > 0)
            {
                ChuongTrinhChonXe(khachThueXe, danhSachXeTimDuoc);
            }
            else
            {
                ChuongTrinhTimXe(khachThueXe);
            }

            List<Xe> TimXe(Xe.EPhanLoai loaiXe)
            {
                List<Xe> danhSachTimDuoc = new List<Xe>();

                foreach (ChuXe chuXe in DuLieu.danhSachChuXe)
                {
                    Console.WriteLine("\nHo ten chu xe: " + chuXe.HoTen);
                    foreach (Xe xe in chuXe.TimXe(loaiXe, DauVaoBanPhim.Decimal("Gia tu: "), DauVaoBanPhim.Decimal("Gia den: ")))
                    {
                        danhSachTimDuoc.Add(xe);
                    }
                }
                return danhSachTimDuoc;
            }
        }
        private static void ChuongTrinhChonXe(KhachThueXe khachThueXe , List<Xe> danhSachXe)
        {
            Xe.XuatDanhSachXe(danhSachXe);
            Xe.XuatDanhSachXe(danhSachXe);
            Xe xe = danhSachXe[DauVaoBanPhim.Int(1, danhSachXe.Count, "Chon 1 trong " + danhSachXe.Count.ToString() + " xe: ") - 1];

            xe.XuatThongTinXe();
            Console.WriteLine("Ban muon:\n1. Xem hop dong.\n2. Xem danh gia.\n3. Quay lai");
            switch(DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
            {
                case 1:
                    ChuongTrinhKhoiTaoHopDong(khachThueXe, xe);
                    break;
                case 2:
                    XemDanhGia(xe);
                    break;
                case 3:
                    ChuongTrinhKhachThueXe(khachThueXe);
                    break;
            }
        }
        private static void XemDanhGia(Xe xe)
        {
            Console.WriteLine("Danh gia cua khach hang truoc danh cho chu xe:");
            xe.ChuXe.DanhGia.XuatToanBoDanhGia();
            Console.WriteLine("Danh gia cua khach hang truoc danh cho xe:");
            xe.DanhGia.XuatToanBoDanhGia();
        }
        private static void ChuongTrinhKhoiTaoHopDong(KhachThueXe khachThueXe, Xe xe)
        {
            TaiXe.XuatDanhSachTaiXe(DuLieu.danhSachTaiXe);
            HopDongThueXe hopDong = HopDongThueXe.KhoiTao(xe, DuLieu.danhSachTaiXe, khachThueXe);
            DuLieu.danhSachHopDongThueXe.Add(hopDong);
            hopDong.XemHopDong();
            Console.WriteLine("Ban muon:\n1. Thue xe.\n2. Quay lai.");
            switch(DauVaoBanPhim.Int(1, 2, "Chon 1 tron 2: "))
            {
                case 1:
                    hopDong.ThanhToan();
                    ChuongTrinhKhachThueXe(khachThueXe);
                    break;
                case 2:
                    ChuongTrinhKhachThueXe(khachThueXe);
                    return;
            }
        }
        private static void ChuongTrinhXemXeDaThue(KhachThueXe khachThueXe)
        {
            khachThueXe.XuatDanhSachXeDaThue();
            if (khachThueXe.DanhSachXeDaThue.Count == 0)
            {
                Console.WriteLine("Khong ton tai xe da thue.\n");
                ChuongTrinhKhachThueXe(khachThueXe);
            }
            else
            {
                Console.WriteLine("Ban muon:\n" + (khachThueXe.DanhSachXeDaThue.Count + 1).ToString() + ". Quay lai");
                int luaChon = DauVaoBanPhim.Int(1, DuLieu.danhSachKhachThueXe.Count + 1, "Chon 1 trong " + khachThueXe.DanhSachXeDaThue.Count.ToString() + " xe: ");
                if (luaChon == khachThueXe.DanhSachXeDaThue.Count + 1)
                {
                    ChuongTrinhKhachThueXe(khachThueXe);
                    return;
                }
                ChuongTrinhXemHopDong(khachThueXe, khachThueXe.DanhSachXeDaThue[luaChon - 1]);
            }
        }
        private static void ChuongTrinhXemHopDong(KhachThueXe khachThueXe, Xe xe)
        {
            HopDongThueXe hopDong = HopDongThueXe.DanhSachHopDong[new Tuple<ChuXe, KhachThueXe, Xe>(xe.ChuXe, khachThueXe, xe)];

            Console.WriteLine("Ban muon:\n1. Xem cac chi phi phat sinh.\n2. Ket thuc hop dong.\n3. Ban muon danh gia.\n4. Quay lai.");
            switch (DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: "))
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
            ChuongTrinhXemXeDaThue(khachThueXe);
        }
        private static void ChuongTrinhDanhGia(KhachThueXe khachThueXe, Xe xe)
        {
            Console.WriteLine("Ban muon:\n1. Danh gia chu xe.\n2. Ban muon danh gia xe.\n3. Ban muon xem danh gia.\n4. Danh gia tai xe.\n5. Quay lai.");
            switch(DauVaoBanPhim.Int(1, 5, "Chon 1 trong 5: "))
            {
                case 1:
                    xe.ChuXe.DanhGia.ThemDanhGia(DanhGia.KhoiTao(khachThueXe));
                    DanhGiaThanhCong();
                    return;
                case 2:
                    xe.DanhGia.ThemDanhGia(DanhGia.KhoiTao(khachThueXe));
                    DanhGiaThanhCong();
                    return;
                case 3:
                    XemDanhGia(xe);
                    break;
                case 4:
                    TaiXe taiXe = HopDongThueXe.DanhSachHopDong[new Tuple<ChuXe, KhachThueXe, Xe>(xe.ChuXe, khachThueXe, xe)].TaiXe;
                    if (taiXe == null)
                    {
                        Console.WriteLine("Khong ton tai tai xe");
                    }
                    else
                    {
                        taiXe.DanhGia.ThemDanhGia(DanhGia.KhoiTao(khachThueXe));
                        DanhGiaThanhCong();
                    }
                    break;
                case 5:
                    ChuongTrinhXemHopDong(khachThueXe, xe);
                    break;
            }

            void DanhGiaThanhCong()
            {
                Console.WriteLine("Danh gia thanh cong.");
                ChuongTrinhDanhGia(khachThueXe, xe);
            }
        }
    }
}
