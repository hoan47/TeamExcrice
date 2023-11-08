using DoAnCuoiKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnDamCuoiKy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NganHang nganHang1 = new NganHang("0", 10000000);
            NganHang nganHang2 = new NganHang("0", 20000000);
            NganHang nganHang3 = new NganHang("0", 30000000);
            ChuChoThue chuXe1 = new ChuChoThue("Tran Van H", "Tp Ho Chi Minh", "0555441221", new DateTime(1990, 1, 1), nganHang1);
            ChuChoThue chuXe2 = new ChuChoThue("Tran Van H", "Tp Ho Chi Minh", "0555441221", new DateTime(1990, 1, 1), nganHang2);
            ChuChoThue chuXe3 = new ChuChoThue("Tran Van H", "Tp Ho Chi Minh", "0555441221", new DateTime(1990, 1, 1), nganHang3);
            Xe[] danhSachXe =
            {
                new XeMay(chuXe1, "Honda", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.TapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),
                new XeMay(chuXe1, "Suzuki", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.TapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),
                new XeMay(chuXe1, "Aloma", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.TapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),
                new XeMay(chuXe2, "Yamaha", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.TapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),
                new XeMay(chuXe3, "Honda", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.TapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),

                new XeBonCho(chuXe2, "Vinfast Fadil", new DateTime(2021, 1, 1), 240, true, Xe.EMucDich.DuLich, 15000000, 5000000, 1000000, 5000000, 3000000, 2000000, 1000000),
                new XeBonCho(chuXe2, "Vinfast Fadil", new DateTime(2021, 1, 1), 240, true, Xe.EMucDich.DuLich, 15000000, 5000000, 1000000, 5000000, 3000000, 2000000, 1000000),
                new XeBonCho(chuXe2, "Vinfast Fadil", new DateTime(2021, 1, 1), 240, true, Xe.EMucDich.DuLich, 15000000, 5000000, 1000000, 5000000, 3000000, 2000000, 1000000),
                new XeBonCho(chuXe3, "Vinfast Fadil", new DateTime(2021, 1, 1), 240, true, Xe.EMucDich.DuLich, 15000000, 5000000, 1000000, 5000000, 3000000, 2000000, 1000000),

                new XeBayCho(chuXe1, "Mitsubishi Xpander", new DateTime(2020, 2, 3), 240, true, Xe.EMucDich.DamCuoi, 25000000, 7000000, 8000000, 10000000, 5000000, 5000000, 3500000),
                new XeBayCho(chuXe3, "Mitsubishi Xpander", new DateTime(2020, 2, 3), 240, true, Xe.EMucDich.DamCuoi, 25000000, 7000000, 8000000, 10000000, 5000000, 5000000, 3500000),
                new XeBayCho(chuXe3, "Mitsubishi Xpander", new DateTime(2020, 2, 3), 240, true, Xe.EMucDich.DamCuoi, 25000000, 7000000, 8000000, 10000000, 5000000, 5000000, 3500000),
                new XeBayCho(chuXe3, "Mitsubishi Xpander", new DateTime(2020, 2, 3), 240, true, Xe.EMucDich.DamCuoi, 25000000, 7000000, 8000000, 10000000, 5000000, 5000000, 3500000)
            };

            KhachThueXe khach1=new KhachThueXe("Dang Thi Thanh Hoa", "Ninh Thuan", "0654225413", new DateTime(2004,11,8),nganHang1,"Kinh doanh");
            Xe xeDuocChon=khach1.KhachYeuCauTimVaChonXe(chuXe1, Xe.EPhanLoai.XeMay, 100000, 500000);
            Console.WriteLine("Xe duoc thue");
            xeDuocChon.XuatThongTinXe();
            HopDongThueXe hopDong1 = new HopDongThueXe(khach1, chuXe1,xeDuocChon, 3, new DateTime(2023, 11, 8));
            hopDong1.ThanhToan();
            hopDong1.KetQuaTraXe(true,false,false,2);
            Console.ReadKey();
        }
    }
}
