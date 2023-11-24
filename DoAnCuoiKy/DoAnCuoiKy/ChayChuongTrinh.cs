using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal static class ChayChuongTrinh
    {
        static List<NganHang> danhSachNganHang;
        static List<ChuXe> danhSachChuXe;
        static List<TaiXe> danhSachTaiXe;
        static List<KhachThueXe> danhSachKhachThueXe;

        static ChayChuongTrinh()
        {
            danhSachNganHang = NganHang.DocDuLieu();
            danhSachChuXe = ChuXe.DocDuLieu(danhSachNganHang);
            danhSachTaiXe = TaiXe.DocDuLieu(danhSachNganHang);
            danhSachKhachThueXe = KhachThueXe.DocDuLieu(danhSachNganHang);
            XeMay.DocDuLieu(danhSachChuXe);
            XeBonCho.DocDuLieu(danhSachChuXe);
            XeBayCho.DocDuLieu(danhSachChuXe);
        }
        public static void ChuongTrinh()
        {
            int luaChon;

            Console.WriteLine("Chuong trinh quan li thue xe vui long chon doi tuong.");
            Console.WriteLine("1. Chu cho thue");
            Console.WriteLine("2. Khach thue xe");
            switch (DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: "))
            {
                case 1:
                    ChuongTrinhChuXe.ChuongTrinhChonChuXe(danhSachChuXe);
                    break;
                case 2:
                    //ChuongTrinhChonKhachThueXe();
                    break;
            }
            void ChuongTrinhChonKhachThueXe()
            {
                if (danhSachKhachThueXe.Count == 0)
                {
                    Console.WriteLine("Khong ton tai khach thue xe.\n");
                    ChuongTrinh();
                }
                KhachThueXe.XuatDanhSachKhachThueXe(danhSachKhachThueXe);
                luaChon = DauVaoBanPhim.Int(1, danhSachKhachThueXe.Count, "Chon 1 trong " + danhSachKhachThueXe.Count.ToString() + " khach thue xe: ");
                KhachThueXe khachThueXe = danhSachKhachThueXe[luaChon - 1];
                Console.WriteLine("Ten cua ban la: " + khachThueXe.HoTen);

                ChuXe.XuatDanhSachChuXe(danhSachChuXe);
                luaChon = DauVaoBanPhim.Int(1, danhSachChuXe.Count, "Chon 1 trong " + (danhSachChuXe.Count).ToString() + " chu cho thue: ");
                if (luaChon == danhSachChuXe.Count + 1)
                {
                    ChuongTrinh();
                }
                else
                {
                    ChuXe chuChoThue = danhSachChuXe[luaChon - 1];
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
                                ///ChuongTrinhDanhGiaKhachHang();
                                break;
                            case 3:
                                ChuongTrinh();
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
                        if (luaChon == 4)
                        {
                            ChuongTrinh();
                        }
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
                                switch (DauVaoBanPhim.Int(0, 1, "Ban co muon tao hop dong khong? (Co: 1, Khong: 0)"))
                                {
                                    case 0:
                                        ChuongTrinhKhachThueXe();
                                        break;
                                    case 1:
                                        ChuongTrinhHopDong();
                                        break;
                                }
                                void ChuongTrinhHopDong()
                                {
                                    HopDongThueXe hopDong = HopDongThueXe.KhoiTaoHopDong(khachThueXe, chuChoThue, xeDuocKhachChon, danhSachTaiXe);
                                    Console.WriteLine("1. Thao tac tren hop dong.");
                                    Console.WriteLine("2. Quay lai");
                                    switch (DauVaoBanPhim.Int(1, 2, "Chon 1 trong 2: "))
                                    {
                                        case 1:
                                            ThaoTacTrenHopDong();
                                            break;
                                        case 2:
                                            ChuongTrinhTimVaChonXe();
                                            break;
                                    }
                                    void ThaoTacTrenHopDong()
                                    {
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
                                                ChuongTrinhKetThucHopDong();
                                                break;
                                            case 3:
                                                ChuongTrinhTimVaChonXe();
                                                break;
                                        }
                                        ThaoTacTrenHopDong();
                                    }
                                    void ChuongTrinhKetThucHopDong()
                                    {
                                        Console.WriteLine("1. Ket thuc thue xe.");
                                        Console.WriteLine("2. Quay lai.");
                                        switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
                                        {
                                            case 1:
                                                hopDong.KetThucThueXe(chuChoThue.KiemTraXeSauKhiTra("Xuot xe: "), chuChoThue.KiemTraXeSauKhiTra("Hu den: "), chuChoThue.KiemTraXeSauKhiTra("Be banh: "), DauVaoBanPhim.Int(1, 7, "Chon so ngay tre han tra xe (tu 1 toi 7 ngay): "));
                                                ChuongTrinhDanhGia(xeDuocKhachChon);
                                                break;
                                            case 2:
                                                ChuongTrinhTimVaChonXe();
                                                break;
                                        }
                                        void ChuongTrinhDanhGia(Xe xeDuocChon)
                                        {
                                            Console.WriteLine("Vui long chon doi tuong can danh gia: ");
                                            Console.WriteLine("1. Chu cho thue.");
                                            Console.WriteLine("2. Xe.");
                                            Console.WriteLine("3. Quay lai.");
                                            switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
                                            {
                                                case 1:
                                                    Console.WriteLine("Danh  gia cua khach hang danh cho chu xe");
                                                    chuChoThue.DanhGia.ThemDanhGia(DanhGia.KhoiTaoDanhGia(khachThueXe));
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Danh gia cua khach hang danh cho xe da thue");
                                                    xeDuocChon.DanhGia.ThemDanhGia(DanhGia.KhoiTaoDanhGia(khachThueXe));
                                                    break;
                                                case 3:
                                                    ChuongTrinhKhachThueXe();
                                                    break;
                                            }
                                            ChuongTrinhDanhGia(xeDuocChon);
                                        }
                                    }

                                }

                            }
                        }
                    }
                }
            }
        }
    }
}

