using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NganHang nganHangA = new NganHang("22110328", 10000000);
            //NganHang nganHangB = new NganHang("22110329", 10000000);
            NganHang nganHangC = new NganHang("22110330", 100000000);
           // NganHang nganHangD = new NganHang("22110331", 10000000);
            Xe[] danhSachXe =
            {
                new XeMay("Honda", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.tapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),
                new XeMay("Yamaha", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.tapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),
                new XeMay("Honda", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.tapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),
                new XeMay("Suzuki", new DateTime(2020, 4, 5), 160, true, Xe.EMucDich.tapLai, 500000, 100000, 70000, 100000, 100000, 150000, 100000),

                new XeBonCho("Vinfast Fadil", new DateTime(2021, 1, 1), 240, true, Xe.EMucDich.duLich, 15000000, 5000000, 1000000, 5000000, 3000000, 2000000, 1000000),
                new XeBonCho("Vinfast Fadil", new DateTime(2021, 1, 1), 240, true, Xe.EMucDich.duLich, 15000000, 5000000, 1000000, 5000000, 3000000, 2000000, 1000000),
                new XeBonCho("Vinfast Fadil", new DateTime(2021, 1, 1), 240, true, Xe.EMucDich.duLich, 15000000, 5000000, 1000000, 5000000, 3000000, 2000000, 1000000),
                new XeBonCho("Vinfast Fadil", new DateTime(2021, 1, 1), 240, true, Xe.EMucDich.duLich, 15000000, 5000000, 1000000, 5000000, 3000000, 2000000, 1000000),

                new XeBayCho("Mitsubishi Xpander", new DateTime(2020, 2, 3), 240, true, Xe.EMucDich.cuoi, 25000000, 7000000, 8000000, 10000000, 5000000, 5000000, 3500000),
                new XeBayCho("Mitsubishi Xpander", new DateTime(2020, 2, 3), 240, true, Xe.EMucDich.cuoi, 25000000, 7000000, 8000000, 10000000, 5000000, 5000000, 3500000),
                new XeBayCho("Mitsubishi Xpander", new DateTime(2020, 2, 3), 240, true, Xe.EMucDich.cuoi, 25000000, 7000000, 8000000, 10000000, 5000000, 5000000, 3500000),
                new XeBayCho("Mitsubishi Xpander", new DateTime(2020, 2, 3), 240, true, Xe.EMucDich.cuoi, 25000000, 7000000, 8000000, 10000000, 5000000, 5000000, 3500000)
            };
            ChuChoThue chu = new ChuChoThue("Tran Van H", "Tp Ho Chi Minh", "0555441221", new DateTime(1990, 1, 1), nganHangA);
           // ChuChoThue chu1 = new ChuChoThue("Nguyen Son", "Tp Ho Chi Minh", "0555441221", new DateTime(1990, 1, 1), nganHangA);
            foreach (Xe xe in danhSachXe)
            {
                if(xe.loaiXe==Xe.PhanLoai.may)
                chu.ThemXeMay((XeMay)xe);
            }
            foreach (Xe xe in danhSachXe)
            {
                if (xe.loaiXe == Xe.PhanLoai.bonCho)
                chu.ThemXeBonCho((XeBonCho)xe);
            }
            foreach (Xe xe in danhSachXe)
            {
                if (xe.loaiXe == Xe.PhanLoai.bayCho)
                chu.ThemXeBayCho((XeBayCho)xe);
            }
            KhachThueXe khach = new KhachThueXe("Nguyen Van A", "Tp Ho Chi Minh", "0665445225", new DateTime(1998, 1, 2), nganHangC, "Giao vien");
            XeMay xm=khach.YeuCauTimXeMay(500000, chu);
            xm.XuatThongTinXe();
            HopDongThueXe hopDong = new HopDongThueXe(khach, chu, Xe.PhanLoai.may, 3, new DateTime(2023, 1, 2));
            hopDong.ThanhToan(500000,chu);
            hopDong.ThueXeThanhCong(500000,chu);
            hopDong.TraXe(true, false, false, 2);
           /* khach.DanhGiaNguoi("Chu nhiet tinh, de thuong");
            khach.DanhGiaXe("Xe oke");
            chu.DanhGiaNguoi("Cam on");*/
            Console.ReadKey();
        }
    }
}
