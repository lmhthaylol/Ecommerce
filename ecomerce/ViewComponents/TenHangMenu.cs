using ecomerce.Data;
using Microsoft.AspNetCore.Mvc;
namespace ecomerce.ViewComponents { 
public class TenHangMenu : ViewComponent
{
    private readonly Hshop2023Context db;

    public TenHangMenu(Hshop2023Context context) => db = context;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var items = db.Loais.Select(lo => new TenHang
        {
            MaLoai=lo.MaLoai,
            Name=lo.TenLoai,
            SoLuong=lo.HangHoas.Count
        });
        return View(items);
    }
}
}