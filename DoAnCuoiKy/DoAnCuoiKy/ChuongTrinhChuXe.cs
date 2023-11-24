using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    static internal class ChuongTrinhChuXe
    {
        static public void ChuongTrinhChonChuXe(List<ChuXe> danhSachChuXe)
        {
            if (danhSachChuXe.Count == 0)
            {
                Console.WriteLine("Khong ton tai chu xe.\n");
                ChayChuongTrinh.ChuongTrinh();
            }
            ChuXe.XuatDanhSachChuXe(danhSachChuXe);
            Console.WriteLine((danhSachChuXe.Count + 1).ToString() + ". Quay lai.");
            int luaChon = DauVaoBanPhim.Int(1, danhSachChuXe.Count + 1, "Chon 1 trong " + (danhSachChuXe.Count).ToString() + " chu cho thue: ");

            if (luaChon == danhSachChuXe.Count + 1)
            {
                ChayChuongTrinh.ChuongTrinh();
            }
            else
            {
                ChuXe chuChoThue = danhSachChuXe[luaChon - 1];
                Console.WriteLine("Ban co ten la: " + chuChoThue.HoTen);
                ChuongTrinhChuChoThue(chuChoThue);
            }
        }
        private static void ChuongTrinhChuChoThue(ChuXe chuChoThue)
        {
            Console.WriteLine("Ban muon: \n1. Xem xe cho thue.\n2. Them xe cho thue.\n3. Xem danh gia.\n4. Quay lai.\n");
            switch (DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: "))
            {
                case 1:
                    ChuongTrinhXe(chuChoThue);
                    break;
                case 2:
                    ChuongTrinhKhoiTaoXe(chuChoThue);
                    break;
                case 3:
                    ChuongTrinhDanhGiaKhachHang(chuChoThue);
                    break;
                case 4:
                    ChayChuongTrinh.ChuongTrinh();
                    break;
            }
        }
        private static void ChuongTrinhXe(ChuXe chuChoThue)
        {
            Console.WriteLine(chuChoThue.HoTen + " muon xem loai xe:\n1. Xe may.\n2. Xe bon cho.\n3. Xe bay cho.\n4. Quay lai.\n");
            int luaChon = DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: ");

            if (luaChon == 4) { }
            else if (chuChoThue.DanhSachXe[luaChon - 1].Count == 0)
            {
                Console.WriteLine("Khong ton tai xe.\n");
            }
            else
            {
                Console.WriteLine("Ban muon xem xe da co nguoi thue hay chua co:\n1. Da co nguoi thue.\n2. Chua co nguoi thue.\n");
                bool daThue = DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: ") == 1 ? true : false;

                if (chuChoThue.DanhSachXe[luaChon - 1].Any(xe => xe.DaThue == daThue) == true)
                {
                    Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[luaChon - 1], daThue);
                }
                else
                {
                    Console.WriteLine("Khong ton tai xe " + (daThue == true ? "da co nguoi thue." : "chua co nguoi thue.") + "\n");
                }
                if (daThue == false)
                {
                    Console.WriteLine("Chon:\n1. De xoa xe.\n2. Quay lai.");
                    if (DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: ") == 1)
                    {
                        int soThuTu = DauVaoBanPhim.Int(1, chuChoThue.DanhSachXe[luaChon - 1].Count, "Chon 1 trong " + chuChoThue.DanhSachXe[luaChon - 1].Count + " xe can xoa: ");

                        switch (luaChon)
                        {
                            case 1:
                                ((XeMay)chuChoThue.DanhSachXe[luaChon - 1][soThuTu - 1]).XoaXeTrongDuLieu(chuChoThue);
                                break;
                            case 2:
                                ((XeBonCho)chuChoThue.DanhSachXe[luaChon - 1][soThuTu - 1]).XoaXeTrongDuLieu(chuChoThue);
                                break;
                            case 3:
                                ((XeBayCho)chuChoThue.DanhSachXe[luaChon - 1][soThuTu - 1]).XoaXeTrongDuLieu(chuChoThue);
                                break;
                        }
                        chuChoThue.DanhSachXe[luaChon - 1][soThuTu - 1] = null;
                        chuChoThue.DanhSachXe[luaChon - 1].RemoveAt(soThuTu - 1);
                        Console.WriteLine("Da xoa.\n");
                    }
                }
            }
            ChuongTrinhChuChoThue(chuChoThue);
        }
        static private void ChuongTrinhKhoiTaoXe(ChuXe chuChoThue)
        {
            Console.WriteLine("Chon loai xe: \n1. Xe may\n2. Xe bon cho\n3. Xe bay cho");
            switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3 loai xe: "))
            {
                case 1:
                    ((XeMay)XeMay.KhoiTao(chuChoThue)).ThemXeVaoDuLieu(chuChoThue);
                    break;
                case 2:
                    ((XeBonCho)XeBonCho.KhoiTao(chuChoThue)).ThemXeVaoDuLieu(chuChoThue);
                    break;
                case 3:
                    ((XeBayCho)XeBayCho.KhoiTao(chuChoThue)).ThemXeVaoDuLieu(chuChoThue);
                    break;
            }
            Console.WriteLine("Khoi tao thanh cong\n");
            ChuongTrinhChuChoThue(chuChoThue);
        }
        static private void ChuongTrinhDanhGiaKhachHang(ChuXe chuChoThue)
        {
            Console.WriteLine("Ban muon:\n1. Xem khach hang danh gia chu.\n2. Xem khach hang danh gia xe.\n3. Danh gia khach hang.");
            switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
            {
                case 1:
                    if (chuChoThue.DanhGia.DanhSachDanhGia.Count == 0)
                    {
                        Console.WriteLine("khong co danh gia danh cho ban");
                    }
                    else
                    {
                        chuChoThue.DanhGia.XuatToanBoDanhGia();
                    }
                    break;
                case 2:
                    if (chuChoThue.DanhSachXe.Any(ds => ds.Any(xe => xe.DanhGia.DanhSachDanhGia.Count != 0)) == true)
                    {
                        ChuXe.XuatToanBoDanhGiaXe(chuChoThue.DanhSachXe);
                    }
                    else
                    {
                        Console.WriteLine("khong co danh gia danh cho ban");
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
                        khachThueXe?.DanhGia.ThemDanhGia(DanhGia.KhoiTaoDanhGia(khachThueXe));
                        Console.WriteLine("Danh gia thanh cong.");
                    }
                    break;
            }
            ChuongTrinhChuChoThue(chuChoThue);
        }
    }
}
