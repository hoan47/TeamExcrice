using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    class XeMay : Xe
    {
        public XeMay(string hangXe, DateTime namMua, double soKilomet, bool baoHiem, MucDich mucDich, decimal giaThueMotNgay, decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia) : base(hangXe, namMua, soKilomet, baoHiem, mucDich, giaThueMotNgay, tienCoc, giaDenXuotXe, giaDenBeBanh, giaDenHuDen, uuDai, tangGia)
        {
            loaiXe = Xe.PhanLoai.may;
        }

    }
}
