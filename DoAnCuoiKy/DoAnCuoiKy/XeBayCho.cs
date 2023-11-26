﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class XeBayCho : Xe
    {
        public XeBayCho(ChuXe chuXe, string hangXe, DateTime namMua, double kilometDaDi, bool baoHiem, EMucDich mucDich, decimal giaThueMotNgay,
            decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia, string bienSoXe, bool daThue)
            : base(chuXe, hangXe, namMua, kilometDaDi, baoHiem, mucDich, giaThueMotNgay, tienCoc, giaDenXuotXe, giaDenBeBanh, giaDenHuDen, uuDai, tangGia, bienSoXe, daThue){ }
        public void XoaXeTrongDuLieu()
        {
            XoaXeTrongDuLieu(Excel.ELoaiDuLieu.XeBayCho);
        }
        public void ThemXeVaoDuLieu()
        {
            ThemXeVaoDuLieu(Excel.ELoaiDuLieu.XeBayCho);
        }
        public void DuLieuTrangThai(bool daThue)
        {
            DuLieuTrangThai(Excel.ELoaiDuLieu.XeBayCho, daThue);
        }
        public static XeBayCho KhoiTao(ChuXe chuChoThue)
        {
            return new XeBayCho(chuChoThue, DauVaoBanPhim.String("Ten xe: "), DauVaoBanPhim.DateTime_("Nam thang ngay mua: "), DauVaoBanPhim.Double("Kilomet da di: "), DauVaoBanPhim.Bool("Xe co bao hiem khong (true hoac false): "), DauVaoBanPhim.MucDich(), DauVaoBanPhim.Decimal("Gia thue 1 ngay: "), DauVaoBanPhim.Decimal("Tien coc: "), DauVaoBanPhim.Decimal("Den suc xe: "), DauVaoBanPhim.Decimal("Den be banh xe: "), DauVaoBanPhim.Decimal("Den hu den xe: "), DauVaoBanPhim.Decimal("Uun dai: "), DauVaoBanPhim.Decimal("Tang gia: "), DauVaoBanPhim.String("Bien so xe: "), false);
        }
        static public List<XeBayCho> DocDuLieu(List<ChuXe> danhSachChuXe)
        {
            List<XeBayCho> danhSachXeMay = new List<XeBayCho>();
            DocDuLieu(null, null, danhSachXeMay, danhSachChuXe, Excel.ELoaiDuLieu.XeBayCho);
            return danhSachXeMay;
        }
    }
}
