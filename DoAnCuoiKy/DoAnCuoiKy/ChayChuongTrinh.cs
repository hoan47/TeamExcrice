﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    static class ChayChuongTrinh
    {
        public static void ChuongTrinh()
        {
            List<ChuChoThue> danhSachChuChoThue = new List<ChuChoThue>();
            List<TaiXe> danhSachTaiXe = new List<TaiXe>();
            List<KhachThueXe> danhSachKhachThueXe = new List<KhachThueXe>();

            if (FileXe.Doc(danhSachChuChoThue, danhSachTaiXe, danhSachKhachThueXe) == true)
            {
                Console.WriteLine("Nhan du lieu tu file thanh cong.");
            }
            else
            {
                throw new Exception("Doc file that bai");
            }
            ChuongTrinhChinh();

            void ChuongTrinhChinh()
            {
                Console.WriteLine("Chuong trinh quan li thue xe vui long chon doi tuong.");
                Console.WriteLine("1. Chu cho thue");
                Console.WriteLine("2. Khach thue xe");
                switch (DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: "))
                {
                    case 1:
                        ChuongTrinhChonChuXe();
                        break;
                    case 2:
                        break;
                }

                void ChuongTrinhChonChuXe()
                {
                    if (danhSachChuChoThue.Count == 0)
                    {
                        Console.WriteLine("Khong ton tai chu xe.");
                        ChuongTrinhChinh();
                    }
                    ChuChoThue.XuatDanhSachChuChoThue(danhSachChuChoThue);
                    Console.WriteLine((danhSachChuChoThue.Count + 1).ToString() + ". Quay lai.");
                    int luaChon = DauVaoBanPhim.Int(0, danhSachChuChoThue.Count + 1, "Chon 1 trong " + (danhSachChuChoThue.Count + 1).ToString() + " chu cho thue: ");
                    if (luaChon == danhSachChuChoThue.Count + 1)
                    {
                        ChuongTrinhChinh();
                    }
                    else
                    {
                        ChuChoThue chuChoThue = danhSachChuChoThue[luaChon - 1];
                        Console.WriteLine("Ban co ten la: " + chuChoThue.HoTen);
                        ChuongTrinhChuChoThue(chuChoThue);
                    }
                }
            }

            void ChuongTrinhChuChoThue(ChuChoThue chuChoThue)
            {
                Console.WriteLine("Ban muon: ");
                Console.WriteLine("1. Xem xe cho thue.");
                Console.WriteLine("2. Them xe cho thue.");
                Console.WriteLine("3. Xem danh gia.");
                Console.WriteLine("4. Quay lai.");
                switch (DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: "))
                {
                    case 1:
                        ChuongTrinhXe();
                        break;
                    case 2:
                        ChuongTrinhKhoiTaoXe();
                        break;
                    case 3:
                        ChuongTrinhDanhGiaKhachHang();
                        break;
                    case 4:
                        ChuongTrinhChinh();
                        break;
                }

                void ChuongTrinhXe()
                {
                    Console.WriteLine(chuChoThue.HoTen + " muon xem loai xe:");
                    Console.WriteLine("1. Xe may.");
                    Console.WriteLine("2. Xe bon cho.");
                    Console.WriteLine("3. Xe bay cho.");
                    Console.WriteLine("4. Quay lai.");
                    int luaChon = DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: ");
                    if(luaChon == 4)
                    {
                        ChuongTrinhChuChoThue(chuChoThue);
                    }
                    else if (chuChoThue.DanhSachXe[luaChon].Count == 0)
                    {
                        Console.WriteLine("Khong ton tai xe.");
                        ChuongTrinhChuChoThue(chuChoThue);
                    }
                    else
                    {
                        Console.WriteLine("\nBan muon xem xe da co nguoi thue hay chua co:");
                        Console.WriteLine("1. Da co nguoi thue");
                        Console.WriteLine("2. Chua co nguoi thue");
                        bool daThue = DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: ") == 1 ? true : false;

                        Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[luaChon], daThue);
                        Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[luaChon], daThue);
                        Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[luaChon], daThue);
                        if (daThue == false)
                        {
                            Console.WriteLine("Chon:\n1.De xoa xe.\n2. Quay lai.");
                            if (DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: ") == 1)
                            {
                                int soThuTu = DauVaoBanPhim.Int(1, chuChoThue.DanhSachXe[luaChon].Count, "Chon 1 trong " + chuChoThue.DanhSachXe[luaChon].Count + " can xoa: ");
                                chuChoThue.DanhSachXe[luaChon - 1][soThuTu - 1] = null;
                                chuChoThue.DanhSachXe[luaChon - 1].RemoveAt(soThuTu - 1);
                                Console.WriteLine("Da xoa");
                            }
                        }
                    }
                    ChuongTrinhChuChoThue(chuChoThue);
                }

                void ChuongTrinhKhoiTaoXe()
                {
                    Console.WriteLine("Chon loai xe: ");
                    Console.WriteLine("1. Xe may");
                    Console.WriteLine("2. Xe bon cho");
                    Console.WriteLine("3. Xe bay cho");
                    switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3 loai xe: "))
                    {
                        case 1:
                            XeMay.KhoiTaoXe(chuChoThue);
                            break;
                        case 2:
                            XeBonCho.KhoiTaoXe(chuChoThue);
                            break;
                        case 3:
                            XeBayCho.KhoiTaoXe(chuChoThue);
                            break;
                    }
                    Console.WriteLine("Khoi tao thanh cong");
                    ChuongTrinhChuChoThue(chuChoThue);
                }

                void ChuongTrinhDanhGiaKhachHang()
                {
                    Console.WriteLine("Ban muon:");
                    Console.WriteLine("1. Xem khach hang danh gia chu.");
                    Console.WriteLine("2. Xem khach hang danh gia xe.");
                    Console.WriteLine("3. Danh gia khach hang.");
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
                            if (chuChoThue.DanhSachXe.Sum(ds => ds.Count) == 0)
                            {
                                Console.WriteLine("khong co danh gia danh cho ban");
                            }
                            else
                            {
                                ChuChoThue.XuatToanBoDanhGiaXe(chuChoThue.DanhSachXe);
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
    }
}
