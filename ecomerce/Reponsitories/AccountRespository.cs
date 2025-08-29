using ecomerce.Data;
using ecomerce.Interfaces;

namespace ecomerce.Reponsitories
{
    public class AccountRespository: IAccountRepository
    {
        private readonly Hshop2023Context _context;

        public AccountRespository(Hshop2023Context context)
        {
            _context = context;
        }

        public KhachHang GetByEmail(string email)
        {
            return _context.KhachHangs.SingleOrDefault(kh => kh.Email == email);
        }

        public void Add(KhachHang khachHang)
        {
            _context.KhachHangs.Add(khachHang);
            _context.SaveChanges();
        }
        public bool EmailExists(string email)
        {
            return _context.KhachHangs.Any(kh => kh.Email == email);
        }
    }
}
