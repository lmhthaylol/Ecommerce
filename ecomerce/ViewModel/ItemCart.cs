namespace ecomerce.ViewModel
{
    public class ItemCart
    {
        public int Id { get; set; }
        public string Hinh { get; set; }
        public string TenHH { get; set; }
        public double DonGia { get; set;}
        public int SoLuong { get; set; }
        public double ThanhTien => DonGia*SoLuong;

    }
}
