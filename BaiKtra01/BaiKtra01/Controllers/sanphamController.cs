using BaiKtra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKtra01.Controllers
{
    public class sanphamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SanPham(Sanphamviewmodel sanpham)
        {
            @sanpham.TenSanPham = "Dien Thoai";
            @sanpham.GiaBan = 2000000;
            @sanpham.AnhMoTa = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpw6olfOnGSEib4dW76xvfYCxewzNXTr4BBQ&s";

            return View(sanpham);

        }
    }
}
