using System;
using System.Linq;

namespace DoAnCuoiKy
{
    static internal class ChayChuongTrinhChuXe
    {
        static public void ChuongTrinhChonChuXe()
        {
            if (DuLieu.danhSachChuXe.Count == 0)
            {
                Console.WriteLine("Khong ton tai chu xe.\n");
                ChayChuongTrinh.ChuongTrinh();
                return;
            }
            ChuXe.XuatDanhSachChuXe(DuLieu.danhSachChuXe);
            int luaChon = DauVaoBanPhim.Int(1, DuLieu.danhSachChuXe.Count + 1, (DuLieu.danhSachChuXe.Count + 1).ToString() + ". Quay lai.\nChon 1 trong " + (DuLieu.danhSachChuXe.Count).ToString() + " chu cho thue: ");

            if (luaChon == DuLieu.danhSachChuXe.Count + 1)
            {
                ChayChuongTrinh.ChuongTrinh();
            }
            else
            {
                ChuXe chuChoThue = DuLieu.danhSachChuXe[luaChon - 1];
                Console.WriteLine("Ban co ten la: " + chuChoThue.HoTen);
                XuLyChuXe(chuChoThue);
            }
        }
        private static void XuLyChuXe(ChuXe chuChoThue)
        {
            switch (DauVaoBanPhim.Int(1, 4, "Ban muon: \n1. Xem xe cho thue.\n2. Them xe cho thue.\n3. Xem danh gia.\n4. Quay lai.\n\nChon 1 trong 4: "))
            {
                case 1:
                    XuLyXe(chuChoThue);
                    break;
                case 2:
                    XuLyKhoiTaoXe(chuChoThue);
                    break;
                case 3:
                    XuLyDanhGiaKhachHang(chuChoThue);
                    break;
                case 4:
                    ChuongTrinhChonChuXe();
                    break;
            }
        }
        private static void XuLyXe(ChuXe chuChoThue)
        {
            int luaChon = DauVaoBanPhim.Int(1, 4, chuChoThue.HoTen + " muon xem loai xe:\n1. Xe may.\n2. Xe bon cho.\n3. Xe bay cho.\n4. Quay lai.\n\nChon 1 trong 4: ");

            if (luaChon == 4) { }
            else if (chuChoThue.DanhSachXeChuaThue[luaChon - 1].Count + chuChoThue.DanhSachXeDaThue[luaChon - 1].Count == 0)
            {
                Console.WriteLine("Khong ton tai xe.\n");
            }
            else
            {
                if (DauVaoBanPhim.Bool("Ban muon xem xe da co nguoi thue (true hoac false): ") == true)
                {
                    if (chuChoThue.DanhSachXeDaThue[luaChon - 1].Count != 0)
                    {
                        Xe.XuatDanhSachXe(chuChoThue.DanhSachXeDaThue[luaChon - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Khong ton tai xe da co nguoi thue\n");
                    }
                }
                else
                {
                    if(chuChoThue.DanhSachXeChuaThue[luaChon - 1].Count != 0)
                    {
                        Xe.XuatDanhSachXe(chuChoThue.DanhSachXeChuaThue[luaChon - 1]);
                        if (DauVaoBanPhim.Int(1, 2, "Chon:\n1. De xoa xe.\n2. Quay lai.\nChon 1 hoac 2: ") == 1)
                        {
                            int soThuTu = DauVaoBanPhim.Int(1, chuChoThue.DanhSachXeChuaThue[luaChon - 1].Count, "Chon 1 trong " + chuChoThue.DanhSachXeChuaThue[luaChon - 1].Count + " xe can xoa: ");

                            switch (luaChon)
                            {
                                case 1:
                                    DuLieu.danhSachXeMay.Remove((XeMay)chuChoThue.DanhSachXeChuaThue[luaChon - 1][soThuTu - 1]);
                                    break;
                                case 2:
                                    DuLieu.danhSachXeBonCho.Remove((XeBonCho)chuChoThue.DanhSachXeChuaThue[luaChon - 1][soThuTu - 1]);
                                    break;
                                case 3:
                                    DuLieu.danhSachXeBayCho.Remove((XeBayCho)chuChoThue.DanhSachXeChuaThue[luaChon - 1][soThuTu - 1]);
                                    break;
                            }
                            chuChoThue.DanhSachXeChuaThue[luaChon - 1].RemoveAt(soThuTu - 1);
                            Console.WriteLine("Da xoa.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Khong ton tai xe chua co nguoi thue.\n");
                    }
                }
            }
            XuLyChuXe(chuChoThue);
        }
        static private void XuLyKhoiTaoXe(ChuXe chuChoThue)
        {
            switch (DauVaoBanPhim.Int(1, 3, "Chon loai xe: \n1. Xe may\n2. Xe bon cho\n3. Xe bay cho\nChon 1 trong 3 loai xe: "))
            {
                case 1:
                    DuLieu.danhSachXeMay.Add(XeMay.KhoiTao(chuChoThue));
                    break;
                case 2:
                    DuLieu.danhSachXeBonCho.Add(XeBonCho.KhoiTao(chuChoThue));
                    break;
                case 3:
                    DuLieu.danhSachXeBayCho.Add(XeBayCho.KhoiTao(chuChoThue));
                    break;
            }
            Console.WriteLine("Khoi tao thanh cong\n");
            XuLyChuXe(chuChoThue);
        }
        static private void XuLyDanhGiaKhachHang(ChuXe chuChoThue)
        {
            switch (DauVaoBanPhim.Int(1, 4, "Ban muon:\n1. Xem khach hang danh gia chu.\n2. Xem khach hang danh gia xe.\n3. Danh gia khach hang.\n4. Quay lai.\nChon 1 trong 4: "))
            {
                case 1:
                    if (chuChoThue.DanhGia.DanhSachDanhGia.Count == 0)
                    {
                        Console.WriteLine("khong co danh gia danh cho ban.");
                    }
                    else
                    {
                        chuChoThue.DanhGia.XuatToanBoDanhGia();
                    }
                    break;
                case 2:
                    if (chuChoThue.DanhSachXeDaThue.Any(ds => ds.Any(xe => xe.DanhGia.DanhSachDanhGia.Count != 0)) == true)
                    {
                        chuChoThue.XuatToanBoDanhGiaXe();
                    }
                    else
                    {
                        Console.WriteLine("khong co danh gia danh cho ban.");
                    }
                    break;
                case 3:
                    if (chuChoThue.KhachHangQuen.DanhSachKhachDaThueXe().Count == 0)
                    {
                        Console.WriteLine("Khong ton tai khach hang.");
                    }
                    else
                    {
                        KhachThueXe.XuatDanhSachKhachThueXe(chuChoThue.KhachHangQuen.DanhSachKhachDaThueXe());
                        KhachThueXe khachThueXe = chuChoThue.KhachHangQuen.DanhSachKhachDaThueXe()[DauVaoBanPhim.Int(1, chuChoThue.KhachHangQuen.DanhSachKhachDaThueXe().Count, "Chon 1 trong " + chuChoThue.KhachHangQuen.DanhSachKhachDaThueXe().Count + " khach hang da thue xe cua ban de danh gia: ") - 1];
                        khachThueXe.DanhGia.ThemDanhGia(DanhGia.KhoiTao(chuChoThue));
                        Console.WriteLine("Danh gia thanh cong.");
                    }
                    break;
                case 4:
                    XuLyChuXe(chuChoThue);
                    return;
            }
            XuLyDanhGiaKhachHang(chuChoThue);
        }
    }
}
