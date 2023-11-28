
using System;

namespace DoAnCuoiKy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Excel.MoUngDung();
            DuLieu.KhoiTaoDuLieu();
            ChayChuongTrinh.ChuongTrinh();
            DuLieu.LuuToanBoDuLieu();
            Excel.DongUngDung();
        }
    }
}
