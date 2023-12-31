﻿using System;

namespace DoAnCuoiKy
{
    static class DauVaoBanPhim
    {
        public static int Int(int batDau, int ketThuc, string noiDung)
        {
            int giaTri;
            while (true)
            {
                try
                {
                    Console.Write(noiDung);
                    string duLieu = Console.ReadLine();
                    if(duLieu.Length >= 8)
                    {
                        continue;
                    }
                    giaTri = int.Parse(duLieu);
                    if ((batDau <= giaTri && giaTri <= ketThuc) == false)
                    {
                        continue;
                    }
                    Console.WriteLine();
                    return giaTri;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        public static string String(string noiDung)
        {
            Console.Write(noiDung);
            return Console.ReadLine();
        }
        static public DateTime DateTime_(string noiDung)
        {
            DateTime ngayThang;
            while (true)
            {
                Console.Write(noiDung);
                if (DateTime.TryParse(Console.ReadLine(), out ngayThang))
                {
                    return ngayThang;
                }
            }
        }
        static public double Double(string noiDung)
        {
            double giaTri;
            while (true)
            {
                try
                {
                    Console.Write(noiDung);
                    string duLieu = Console.ReadLine();
                    if(duLieu.Length >= 8)
                    {
                        continue;
                    }
                    giaTri = double.Parse(duLieu);
                    return giaTri;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        static public decimal Decimal(string noiDung)
        {
            decimal giaTri;
            while (true)
            {
                try
                {
                    Console.Write(noiDung);
                    string duLieu = Console.ReadLine();
                    if(duLieu.Length > 20)
                    {
                        continue;
                    }
                    giaTri = decimal.Parse(duLieu);
                    return giaTri;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        static public bool Bool(string noiDung)
        {
            bool giaTri;
            while (true)
            {
                try
                {
                    Console.Write(noiDung);
                    giaTri = bool.Parse(Console.ReadLine());
                    return giaTri;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        static public Xe.EMucDich MucDich()
        {
            Console.WriteLine("Muc dich mua xe:\n1. Du lich.\n2. Dam cuoi.\n3. Tap lai.\n4. Khac");
            while (true)
            {
                switch (Int(1, 4, "Chon 1 trong 4: "))
                {
                    case 1:
                        return Xe.EMucDich.DuLich;
                    case 2:
                        return Xe.EMucDich.DamCuoi;
                    case 3:
                        return Xe.EMucDich.TapLai;
                    case 4:
                        return Xe.EMucDich.Khac;
                }
            }
        }
        public static DanhGia.EDanhGia DanhGia_()
        {
            Console.WriteLine("Ban danh gia may sao: ");
            while (true)
            {
                switch (Int(1, 5, "Chon 1 trong 5 sao: "))
                {
                    case 1:
                        return DanhGia.EDanhGia.Sao1;
                    case 2:
                        return DanhGia.EDanhGia.Sao2;
                    case 3:
                        return DanhGia.EDanhGia.Sao3;
                    case 4:
                        return DanhGia.EDanhGia.Sao4;
                    case 5:
                        return DanhGia.EDanhGia.Sao5;
                }
            }
        }

        public static Xe.EPhanLoai LoaiXe()
        {
            Console.WriteLine("Loai xe:\n1. Xe may.\n2. Xe bon cho.\n3. Xe bay cho");
            while (true)
            {
                switch (Int(1, 3, "Chon 1 trong 3: "))
                {
                    case 1:
                        return Xe.EPhanLoai.XeMay;
                    case 2:
                        return Xe.EPhanLoai.XeBonCho;
                    case 3:
                        return Xe.EPhanLoai.XeBayCho;
                }
            }
        }
    }
}
