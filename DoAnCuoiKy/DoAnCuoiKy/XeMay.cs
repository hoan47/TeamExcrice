﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal class XeMay : Xe
    {
        public XeMay(ChuXe chuXe, string hangXe, DateTime namMua, double kilometDaDi, bool baoHiem, EMucDich mucDich, decimal giaThueMotNgay, 
            decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia) 
            : base(chuXe, hangXe, namMua, kilometDaDi, baoHiem, mucDich, giaThueMotNgay, tienCoc, giaDenXuotXe, giaDenBeBanh, giaDenHuDen, uuDai, tangGia) { }
        public void ThemXeVaoDuLieu(ChuXe chuXe)
        {
            ThemXeVaoDuLieu(chuXe, Excel.ELoaiDuLieu.XeMay);
        }
        public void XoaXeTrongDuLieu(ChuXe chuXe)
        {
            XoaXeTrongDuLieu(chuXe, Excel.ELoaiDuLieu.XeMay);
        }
        public static Xe KhoiTao(ChuXe chuChoThue)
        {
            return new XeMay(chuChoThue, DauVaoBanPhim.String("Ten xe: "), DauVaoBanPhim.DateTime_("Nam thang ngay mua: "), DauVaoBanPhim.Double("Kilomet da di: "), DauVaoBanPhim.Bool("Xe co bao hiem khong (true hoac false): "), DauVaoBanPhim.MucDich(), DauVaoBanPhim.Decimal("Gia thue 1 ngay: "), DauVaoBanPhim.Decimal("Tien coc: "), DauVaoBanPhim.Decimal("Den suc xe: "), DauVaoBanPhim.Decimal("Den be banh xe: "), DauVaoBanPhim.Decimal("Den hu den xe: "), DauVaoBanPhim.Decimal("Uun dai: "), DauVaoBanPhim.Decimal("Tang gia: "));
        }
        static public List<XeMay> DocDuLieu(List<ChuXe> danhSachChuXe)
        {
            List<XeMay> danhSachXeMay = new List<XeMay>();
            DocDuLieu(danhSachXeMay, null, null, danhSachChuXe, Excel.ELoaiDuLieu.XeMay);
            return danhSachXeMay;
        }
    }
}
