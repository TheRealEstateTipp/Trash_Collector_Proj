using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollectorProj.Data;
using TrashCollectorProj.Models;

namespace TrashCollectorProj.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: CustomersController
        public IActionResult Index()
        {
            return View();
        }

        // GET: CustomersController/Details/5
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Where(c => c.CustomerID == id).SingleOrDefault();
            return View(customer);
        }

        // GET: CustomersController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CustomersController/Edit/5
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Where(c => c.CustomerID == id).SingleOrDefault();
            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
    
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
