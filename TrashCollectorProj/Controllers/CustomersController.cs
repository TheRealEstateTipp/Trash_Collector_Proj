using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public IActionResult Details()
        {
            var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserID == userID).SingleOrDefault();
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
            customer.IdentityUserID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CustomersController/Edit/5
        public IActionResult Edit()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserID == userId).SingleOrDefault();
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

 
    }
}
