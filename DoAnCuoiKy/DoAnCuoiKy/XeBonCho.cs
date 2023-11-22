using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class XeBonCho : Xe
    {
        static string duongDanDuLieu = "DanhSachXeBonCho.xlsx";
        public XeBonCho(ChuXe chuXe, string hangXe, DateTime namMua, double kilometDaDi, bool baoHiem, EMucDich mucDich, decimal giaThueMotNgay, 
            decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia) 
            : base(chuXe, hangXe, namMua, kilometDaDi, baoHiem, mucDich, giaThueMotNgay, tienCoc, giaDenXuotXe, giaDenBeBanh, giaDenHuDen, uuDai, tangGia) { }
        public void XoaXeTrongDuLieu(ChuXe chuXe)
        {
            XoaXeTrongDuLieu(chuXe, duongDanDuLieu);
        }
        public static new Xe KhoiTao(ChuXe chuChoThue)
        {
            return new XeBonCho(chuChoThue, DauVaoBanPhim.String("Ten xe: "), DauVaoBanPhim.DateTime_("Nam thang ngay mua: "), DauVaoBanPhim.Double("Kilomet da di: "), DauVaoBanPhim.Bool("Xe co bao hiem khong (true hoac false): "), DauVaoBanPhim.MucDich(), DauVaoBanPhim.Decimal("Gia thue 1 ngay: "), DauVaoBanPhim.Decimal("Tien coc: "), DauVaoBanPhim.Decimal("Den suc xe: "), DauVaoBanPhim.Decimal("Den be banh xe: "), DauVaoBanPhim.Decimal("Den hu den xe: "), DauVaoBanPhim.Decimal("Uun dai: "), DauVaoBanPhim.Decimal("Tang gia: "));
        }
        public void ThemXeVaoDuLieu(ChuXe chuXe)
        {
            ThemXeVaoDuLieu(chuXe, duongDanDuLieu);
        }
        static public List<XeBonCho> DocDuLieu(List<ChuXe> danhSachChuXe)
        {
            List<XeBonCho> danhSachXeBonCho = new List<XeBonCho>();
            DocDuLieu(null, danhSachXeBonCho, null, danhSachChuXe, duongDanDuLieu);
            return danhSachXeBonCho;
        }
    }
}
