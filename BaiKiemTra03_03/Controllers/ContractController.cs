using BaiKiemTra03_03.Data;
using BaiKiemTra03_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BaiKiemTra03_03.Controllers
{
    public class ContractController : Controller
    {
        private readonly AppDbContext _context;

        public ContractController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var contracts = _context.Contracts.Include(c => c.Customer).ToList();
            return View(contracts);
        }


        public IActionResult Details(int id)
        {
            var contract = _context.Contracts.Include(c => c.Customer).FirstOrDefault(c => c.ContractId == id);
            if (contract == null) return NotFound();
            return View(contract);
        }


        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Contracts.Add(contract);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contract);
        }


        public IActionResult Edit(int id)
        {
            var contract = _context.Contracts.Find(id);
            if (contract == null) return NotFound();
            ViewBag.Customers = _context.Customers.ToList();
            return View(contract);
        }

        [HttpPost]
        public IActionResult Edit(Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Contracts.Update(contract);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contract);
        }


        public IActionResult Delete(int id)
        {
            var contract = _context.Contracts.Find(id);
            if (contract == null) return NotFound();
            return View(contract);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contract = _context.Contracts.Find(id);
            _context.Contracts.Remove(contract);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
