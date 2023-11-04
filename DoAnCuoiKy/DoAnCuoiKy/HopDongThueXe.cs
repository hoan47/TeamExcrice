using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class HopDongThueXe
    {
        private KhachThueXe khachThue;
        private ChuChoThue chuThue;
        private Xe xeChoThue;
        private DateTime ngayThue;
        private int soNgay;
        private decimal giaThueChinhThuc;
        private decimal tienCoc;
        private decimal tienGiaHan;
        private decimal uuDai;
        private decimal tangGia;
        private decimal tienXuotXe;
        private decimal tienBeBanh;
        private decimal tienHuDen;
        private string danhGia;
        private decimal chiPhiDen = 0;

        public HopDongThueXe(KhachThueXe khachThue, ChuChoThue chuThue, Xe xeChoThue, int soNgay, DateTime ngayThue)
        {
            this.khachThue = khachThue;
            this.chuThue = chuThue;
            this.xeChoThue = xeChoThue;
            this.soNgay = soNgay;
            this.ngayThue = ngayThue;
        }

        public enum EUuDaiChoKhach
        {
            Co,
            Khong
        }
        public enum ETangGiaTheoDip
        {
            Co,
            Khong
        }
    }
}
