using ecomerce.Data;
using ecomerce.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ecomerce.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly Hshop2023Context db;

        public HangHoaController(Hshop2023Context context) {
            db = context;
        }
        public IActionResult Index(int? loai, double rangeInput= 0)
        {
            var hanghoas=db.HangHoas.AsQueryable();
            if(loai.HasValue)
            {
                hanghoas=hanghoas.Where(p=>p.MaLoai==loai.Value);
            }
            if(rangeInput> 0)
            {
				hanghoas = hanghoas.Where(p => p.DonGia == rangeInput);
			}
            var result = hanghoas.Select(p => new SanPhamMenu
            {
                MaHangHoa=p.MaHh,
                Ten=p.TenHh,
                Hinh=p.Hinh ?? "",
                TenLoai=p.MaLoaiNavigation.TenLoai,
                DonGia=p.DonGia ?? 0,
                MoTa=p.MoTaDonVi ?? ""
            });
            ViewBag.CurrentLoai = loai;
            return View(result);
        }
        public IActionResult Search(string query)
        {
            var hanghoas = db.HangHoas.AsQueryable();
            if (query != null)
            {
                hanghoas=hanghoas.Where(p=>p.TenHh.Contains(query));
            }
            var result = hanghoas.Select(p => new SanPhamMenu
            {
                MaHangHoa = p.MaHh,
                Ten = p.TenHh,
                Hinh = p.Hinh ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai,
                DonGia = p.DonGia ?? 0,
                MoTa = p.MoTaDonVi ?? ""
            });
            return View(result);
        }
        public IActionResult Detail(int id)
        {
            var hanghoas = db.HangHoas.Include(p => p.MaLoaiNavigation).SingleOrDefault(p => p.MaHh == id);
            if (hanghoas == null)
            {
                return Redirect("/404notfound");
            }
            var data = new SanPhamDetail
            {
                MaHH=hanghoas.MaHh,
                TenHangHoa = hanghoas.TenHh,
                TenLoai = hanghoas.MaLoaiNavigation.TenLoai,
                Hinh = hanghoas.Hinh ?? string.Empty,
                DonGia = hanghoas.DonGia ?? 0,
                MoTa = hanghoas.MoTa ?? string.Empty,
                MoTaDonVi = hanghoas.MoTaDonVi ?? string.Empty,
                diemDanhGia = 10,
                soLuongTon = 10,
            };
            return View(data);
        }
    }
}
