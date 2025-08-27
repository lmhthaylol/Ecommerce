using ecomerce.Data;
using ecomerce.Helper;
using ecomerce.Models;
using ecomerce.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecomerce.Controllers
{
    public class CartController : Controller
    {
        private readonly Hshop2023Context db;

        public CartController (Hshop2023Context context) {
            db=context;
        }
        public List<ItemCart> Cart => HttpContext.Session.Get<List<ItemCart>>(SessionCartShop.Cart_Key) ?? new List<ItemCart>();
        public IActionResult Index()
        {
            return View(Cart);
        }
        //public IActionResult AddToCart(int id, int quantity=1) 
        //{
        //    var gioHang = Cart;
        //    var item =gioHang.SingleOrDefault(x => x.Id == id);
        //    if (item == null)
        //    {
        //        var hangHoa = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
        //        if (hangHoa == null)
        //        {
        //            TempData["Message"] = $"Khong tim thay hang hoa";
        //            return Redirect("/404notfound");

        //        }
        //        item = new ItemCart
        //        {
        //            Id = hangHoa.MaHh,
        //            TenHH = hangHoa.TenHh,
        //            DonGia = hangHoa.DonGia ?? 0,
        //            Hinh = hangHoa.Hinh ?? string.Empty,
        //            SoLuong = quantity
        //        };
        //        gioHang.Add(item);
        //    }
        //    else
        //    {
        //        item.SoLuong += quantity;
        //    }
        //    HttpContext.Session.Set(SessionCartShop.Cart_Key, gioHang);
        //    return RedirectToAction("Index");

        //}
        public IActionResult GetCartSummary()
        {
            return ViewComponent("GioHang"); 
        }
        [HttpPost] // Ensure this action only responds to POST requests
        public IActionResult AddToCartAjax(int id, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                var hangHoa = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
                if (hangHoa == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy hàng hóa." });
                }
                item = new ItemCart
                {
                    Id = hangHoa.MaHh,
                    TenHH = hangHoa.TenHh,
                    DonGia = hangHoa.DonGia ?? 0,
                    Hinh = hangHoa.Hinh ?? string.Empty,
                    SoLuong = quantity
                };
                gioHang.Add(item);
            }
            else
            {
                item.SoLuong += quantity;
            }
            HttpContext.Session.Set(SessionCartShop.Cart_Key, gioHang);

            // Return a JSON response indicating success and the current cart item count
            return Json(new { success = true, message = "Sản phẩm đã được thêm vào giỏ hàng!", totalItems = gioHang.Sum(x => x.SoLuong) });
        }
        public IActionResult Delete(int id)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(x => x.Id == id);
            gioHang.Remove(item);
            HttpContext.Session.Set(SessionCartShop.Cart_Key, gioHang);
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public IActionResult UpdateCart(int id, int quantity)
        //{
        //    var gioHang = Cart;
        //    var itemToUpdate = gioHang.FirstOrDefault(item => item.Id == id);
        //    if (itemToUpdate != null)
        //    {
        //        itemToUpdate.SoLuong = quantity;
        //    }
        //    else
        //    {
        //        return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng." });
        //    }
        //    return Json(new { success = true /*, newSubtotal = newSubtotal*/ });
        //}
    }
}
