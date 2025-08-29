using ecomerce.Data;
using ecomerce.Helper;
using ecomerce.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecomerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(KhachHang model)
        {
            if (_accountRepository.EmailExists(model.Email))
            {
                ModelState.AddModelError("Email", "Email đã tồn tại.");
                return View(model);
            }

            // ... (các logic khác)

            model.RandomKey = MyUtil.GenerateRamdomKey();
            model.MatKhau = model.MatKhau.ToMd5Hash(model.RandomKey);
            model.VaiTro = 0;
            model.HieuLuc = true;

            _accountRepository.Add(model);


            return Ok(new { message = "Đăng ký thành công!" });
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(string email, string password)
        //{
        //    var khachHang = _khachHangRepository.GetByEmail(email);

        //    if (khachHang != null && BCrypt.Net.BCrypt.Verify(password, khachHang.MatKhau))
        //    {
        //        // ... (các logic tạo claims và cookie)
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
        //    return View();
        //}
    }
}
