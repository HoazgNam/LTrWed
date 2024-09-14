using BaiKtra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKtra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel taikhoan)
        {
            if (taikhoan.Username != null)
            {
                return Content($"Tên tài khoản: {taikhoan.Username}, Mật Khẩu: {taikhoan.Password},Họ tên: {taikhoan.HoTen}, Tuổi: {taikhoan.Tuoi}");
            }
            return View(taikhoan);
           
        }
    }
}
