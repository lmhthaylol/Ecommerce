using ecomerce.Data;

namespace ecomerce.Interfaces
{
    public interface IAccountRepository
    {
        KhachHang GetByEmail(string email);
        void Add(KhachHang khachHang);
        bool EmailExists(string email);
    }
}
