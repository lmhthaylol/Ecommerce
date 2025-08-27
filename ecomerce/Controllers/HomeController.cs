using ecomerce.Data;
using ecomerce.Models;
using ecomerce.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace ecomerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly Hshop2023Context db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Hshop2023Context context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            var result = db.Loais.ToList();
            var hanghoas = db.HangHoas.AsQueryable();
            var result2 = hanghoas.Select(p => new SanPhamMenu
            {
                MaHangHoa = p.MaHh,
                Ten = p.TenHh,
                Hinh = p.Hinh ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai,
                DonGia = p.DonGia ?? 0,
                MoTa = p.MoTaDonVi ?? ""
            }).ToList();
            var data = new IndexViewModel
            {
                Loais = result,
                sanPhamMenus = result2,
            };
            return View(data);
        }
        [Route("/404notfound")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
