using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt4
{
    public class NhanVien
    {
        public NhanVien(string mSNV, string tenNV, decimal luongCB)
        {
            MSNV = mSNV;
            TenNV = tenNV;
            LuongCB = luongCB;
        }

        public string MSNV { get; set; }
        public string TenNV { get; set; }
        public decimal LuongCB { get; set; }
    
     public NhanVien() { }
    } }
