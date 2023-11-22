using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal static class ChayChuongTrinh
    {
        public static void ChuongTrinh()
        {
            List<ChuXe> danhSachChuXe = ChuXe.DocDuLieu();
            List<TaiXe> danhSachTaiXe = TaiXe.DocDuLieu();
            List<KhachThueXe> danhSachKhachThueXe = KhachThueXe.DocDuLieu();
            XeMay.DocDuLieu(danhSachChuXe);
            XeBonCho.DocDuLieu(danhSachChuXe);
            XeBayCho.DocDuLieu(danhSachChuXe);

            int luaChon;

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
                        ChuongTrinhChonKhachThueXe();
                        break;
                }
                void ChuongTrinhChonKhachThueXe()
                {
                    if (danhSachKhachThueXe.Count == 0)
                    {
                        Console.WriteLine("Khong ton tai khach thue xe.\n");
                        ChuongTrinhChinh();
                    }

                    KhachThueXe.XuatDanhSachKhachThueXe(danhSachKhachThueXe);
                    luaChon = DauVaoBanPhim.Int(0, danhSachKhachThueXe.Count + 1, "Chon 1 trong " + (danhSachKhachThueXe.Count).ToString() + " khach thue xe: ");
                    KhachThueXe khachThueXe = danhSachKhachThueXe[luaChon - 1];
                    Console.WriteLine("Ten cua ban la: " + khachThueXe.HoTen);

                    ChuChoThue.XuatDanhSachChuChoThue(danhSachChuChoThue);
                    luaChon = DauVaoBanPhim.Int(0, danhSachChuChoThue.Count + 1, "Chon 1 trong " + (danhSachChuChoThue.Count).ToString() + " chu cho thue: ");
                    if (luaChon == danhSachChuChoThue.Count + 1)
                    {
                        ChuongTrinhChinh();
                    }
                    else
                    {
                        ChuChoThue chuChoThue = danhSachChuChoThue[luaChon - 1];
                        Console.WriteLine("Ten chu cho thue duoc chon: " + chuChoThue.HoTen);
                        ChuongTrinhKhachThueXe();
                        void ChuongTrinhKhachThueXe()
                        {
                            Console.WriteLine("Ban muon: ");
                            Console.WriteLine("1. Tim xe va chon xe.");
                            Console.WriteLine("2. Xem cac danh gia cua khach hang truoc");
                            Console.WriteLine("3. Quay lai.");
                            switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
                            {
                                case 1:
                                    ChuongTrinhTimVaChonXe();
                                    break;
                                case 2:
                                    //ChuongTrinhDanhGiaKhachHang();
                                    break;
                                case 3:
                                    ChuongTrinhChinh();
                                    break;
                            }

                        }
                        void ChuongTrinhTimVaChonXe()
                        {
                            Console.WriteLine("Ban muon tim loai xe:");
                            Console.WriteLine("1. Xe may.");
                            Console.WriteLine("2. Xe bon cho.");
                            Console.WriteLine("3. Xe bay cho.");
                            Console.WriteLine("4. Quay lai.");
                            luaChon = DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: ");
                            if (luaChon == 4) { }
                            else if (chuChoThue.DanhSachXe[luaChon - 1].Count == 0)
                            {
                                Console.WriteLine("Khong ton tai xe.\n");
                            }
                            else
                            {
                                Console.WriteLine("Nhap khoang muc gia can tim: ");
                                decimal giaTu = decimal.Parse(Console.ReadLine());
                                decimal giaDen = decimal.Parse(Console.ReadLine());
                                Xe.EPhanLoai loaiXe;
                                if (luaChon == 1)
                                    loaiXe = Xe.EPhanLoai.XeMay;
                                else if (luaChon == 2)
                                    loaiXe = Xe.EPhanLoai.XeBonCho;
                                else
                                    loaiXe = Xe.EPhanLoai.XeBayCho;
                                List<Xe> danhSachXeTimDuoc = khachThueXe.KhachYeuCauTimVaChonXe(chuChoThue, loaiXe, giaTu, giaDen);
                                int soThuTu = 1;
                                foreach (Xe xeTimDuoc in danhSachXeTimDuoc)
                                {
                                    Console.WriteLine("So thu tu: " + soThuTu++.ToString());
                                    xeTimDuoc.XuatThongTinXe();
                                }
                                if (danhSachXeTimDuoc.Count > 0)
                                {
                                    luaChon = DauVaoBanPhim.Int(1, danhSachXeTimDuoc.Count + 1, "Chon 1 trong " + (danhSachXeTimDuoc.Count).ToString() + " xe tim duoc: ");
                                    Xe xeDuocKhachChon = danhSachXeTimDuoc[luaChon - 1];
                                    Console.WriteLine("Xe khach da chon: ");
                                    xeDuocKhachChon.XuatThongTinXe();
                                    Console.WriteLine("Ban co muon tao hop dong khong? (Co: 1, Khong: 0)");
                                    int chon = int.Parse(Console.ReadLine());
                                    if (chon == 0)
                                    {
                                        ChuongTrinhKhachThueXe();
                                    }
                                    else if (chon == 1)
                                    {
                                        ChuongTrinhHopDong();
                                    }
                                    void ChuongTrinhHopDong()
                                    {
                                        HopDongThueXe hopDong = ChuongTrinhKhoiTaoHopDong();
                                        hopDong.XemHopDong();
                                        Console.WriteLine("1. Xem hop dong.");
                                        Console.WriteLine("2. Thanh toan xe hop dong.");
                                        Console.WriteLine("3. Quay lai.");
                                        switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
                                        {
                                            case 1:
                                                hopDong.XemHopDong();
                                                break;
                                            case 2:
                                                hopDong.ThanhToan();

                                                break;
                                            case 3:
                                                ChuongTrinhTimVaChonXe();
                                                break;
                                        }
                                    }
                                    
                                    
                                        ///*void ChuongTrinhKetThucHopDong()
                                        //{
                                        //    Console.WriteLine("1. Ket thuc thue xe.");
                                        //    Console.WriteLine("2. Danh gia.");
                                        //    Console.WriteLine("3. Quay lai.");
                                        //    switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
                                        //    {
                                        //        case 1:
                                        //            break;
                                        //        case 2:
                                        //            ChuongTrinhTimVaChonXe();
                                        //            break;
                                        //    }
                                        //}*/
                                }
                                else
                                {
                                    ChuongTrinhTimVaChonXe();
                                }
                            }
                        }
                        //void ChuongTrinhDanhGia(Xe xeDuocChon)
                        //{
                        //    Console.WriteLine("Vui long chon doi tuong can danh gia: ");
                        //    Console.WriteLine("1. Chu cho thue.");
                        //    Console.WriteLine("2. Tai xe.");
                        //    Console.WriteLine("3. Xe.");
                        //    Console.WriteLine("4. Quay lai.");
                        //    switch (DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: "))
                        //    {
                        //        case 1:
                        //            Console.WriteLine("Danh  gia cua khach hang danh cho chu xe");
                        //            chuChoThue.DanhGia.ThemDanhGia(DanhGia.KhoiTaoDanhGia(khachThueXe));
                        //            break;
                        //        case 2:
                        //            Console.WriteLine("Danh gia cua khach hang danh cho tai xe");
                        //            break;
                        //        case 3:
                        //            Console.WriteLine("Danh gia cua khach hang danh cho xe da thue");
                        //            xeDuocChon.DanhGia.ThemDanhGia(DanhGia.KhoiTaoDanhGia(khachThueXe));
                        //            break;
                        //        case 4:
                        //            ChuongTrinhKhachThueXe();
                        //            break;
                        //    }
                        //    ChuongTrinhDanhGia(xeDuocChon);
                        //}
                    }
                }
                void ChuongTrinhChonChuXe()
                {
                    if (danhSachChuXe.Count == 0)
                    {
                        Console.WriteLine("Khong ton tai chu xe.\n");
                        ChuongTrinhChinh();
                    }
                    ChuXe.XuatDanhSachChuXe(danhSachChuXe);
                    Console.WriteLine((danhSachChuXe.Count + 1).ToString() + ". Quay lai.");
                    luaChon = DauVaoBanPhim.Int(0, danhSachChuXe.Count + 1, "Chon 1 trong " + (danhSachChuXe.Count).ToString() + " chu cho thue: ");
                    if (luaChon == danhSachChuXe.Count + 1)
                    {
                        ChuongTrinhChinh();
                    }
                    else
                    {
                        ChuXe chuChoThue = danhSachChuXe[luaChon - 1];
                        Console.WriteLine("Ban co ten la: " + chuChoThue.HoTen);
                        ChuongTrinhChuChoThue();

                        void ChuongTrinhChuChoThue()
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
                                luaChon = DauVaoBanPhim.Int(1, 4, "Chon 1 trong 4: ");

                                if (luaChon == 4) { }
                                else if (chuChoThue.DanhSachXe[luaChon - 1].Count == 0)
                                {
                                    Console.WriteLine("Khong ton tai xe.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Ban muon xem xe da co nguoi thue hay chua co:");
                                    Console.WriteLine("1. Da co nguoi thue");
                                    Console.WriteLine("2. Chua co nguoi thue");
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
                                            int soThuTu = DauVaoBanPhim.Int(1, chuChoThue.DanhSachXe[luaChon - 1].Count, "Chon 1 trong " + chuChoThue.DanhSachXe[luaChon - 1].Count + " can xoa: ");

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
                                ChuongTrinhChuChoThue();
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
                                ChuongTrinhChuChoThue();
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
                                ChuongTrinhChuChoThue();
                            }
                        }
                    }
                }
            }
        }
    }
}

