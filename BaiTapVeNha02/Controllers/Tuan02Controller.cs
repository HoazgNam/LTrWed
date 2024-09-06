using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha02.Controllers
{
    public class Tuan02Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HoTen = "Luu Hoang Nam";
            ViewBag.MSSV = "1822041669";
            ViewBag.Nam = 2024;

            return View();
        }
    }
}
