using ecomerce.Data;
using Microsoft.Build.ObjectModelRemoting;

namespace ecomerce.ViewModel
{
    public class SanPhamMenu
    {
        public int MaHangHoa { get; set; }
        public string Ten {  get; set; }
        public string TenLoai { get; set; }
        public string Hinh { get; set; }
        public double DonGia {  get; set; }
        public string MoTa {  get; set; }
    }
    public class SanPhamDetail
    {
        public int MaHH { get; set; }
        public string TenHangHoa { get; set; }
        public string TenLoai { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public string MoTa { get; set; }
        public string MoTaDonVi { get; set; }
        public int diemDanhGia {  get; set; }
        public int soLuongTon { get;set; }
    }
    public class IndexViewModel
    {
        public List<SanPhamMenu> sanPhamMenus { get; set; }
        public List<Loai> Loais { get; set; }
    }
}
