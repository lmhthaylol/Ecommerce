    using ecomerce.Data;
    using ecomerce.Models;
    using ecomerce.ViewModel;
    using ecomerce.Helper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
namespace ecomerce.ViewComponents
    {
        public class GioHangViewComponent : ViewComponent
        {
            private readonly Hshop2023Context db;

            public GioHangViewComponent(Hshop2023Context context) {
                db=context;
            }
            public List<ItemCart> Cart => HttpContext.Session.Get<List<ItemCart>>(SessionCartShop.Cart_Key) ?? new List<ItemCart>();
            public async Task<IViewComponentResult> InvokeAsync()
           {
            int total = Cart.Sum(item => item.SoLuong);
            return View(total);
           }
        }
    }
