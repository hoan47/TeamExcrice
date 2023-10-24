using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class HopDongThueNha
    {
        private decimal tienDatCoc;
        private PhongTro phongTro;
        private NguoiChoThue nguoiChoThue;
        private NguoiThue nguoiThue;
        private DateTime thoiHan;
        private string thongTinBoiThuong;

        public HopDongThueNha(int tienDatCoc, PhongTro phongTro, NguoiChoThue nguoiChoThue, NguoiThue nguoiThue, DateTime thoiHan, string thongTinBoiThuong)
        {
            this.tienDatCoc = tienDatCoc;
            this.phongTro = phongTro;
            this.nguoiChoThue = nguoiChoThue;
            this.nguoiThue = nguoiThue;
            this.thoiHan = thoiHan;
            this.thongTinBoiThuong = thongTinBoiThuong;
        }
    }
}
