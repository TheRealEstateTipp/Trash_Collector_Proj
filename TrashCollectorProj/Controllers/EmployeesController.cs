using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TrashCollectorProj.Data;
using TrashCollectorProj.Models;

namespace TrashCollectorProj.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeesController
        public IActionResult Index()
        {
            var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserID == userID).SingleOrDefault();
           
            if (employee == null)
            {
                return RedirectToAction("Create");
            }

            var dayofWeek = DateTime.Today.DayOfWeek;
            List<Customer> todaysPickUps = _context.Customers.Where(p => p.ZipCode == employee.ServicingZipCode && p.PickUpDay == dayofWeek).ToList();

            return View(todaysPickUps);
        }

        // GET: EmployeesController/Details/5
        public IActionResult Details(string searchString)
        {
            var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserID == userID).SingleOrDefault();
            var pickups = _context.Customers.Where(p => p.ZipCode == employee.ServicingZipCode).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                var allCustomers = _context.Customers.Where(c => c.ZipCode == employee.ServicingZipCode); ;
                List<Customer> rightDay = new List<Customer>();
                foreach(Customer cust in allCustomers)
                {
                    if(cust.PickUpDay.ToString() == searchString)
                    {
                        rightDay.Add(cust);
                    }
                }

                return View(rightDay);
            }
            
            return View(pickups);

        }

        // GET: EmployeesController/Creat
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.IdentityUserID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
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

        public IActionResult ConfirmPickUp(int id)
        {
          
            var customer = _context.Customers.Where(c => c.CustomerID == id).SingleOrDefault();
            customer.PickUpConfirmed = true;
            customer.BalanceOwed += 50;
            
            return RedirectToAction("Index");
        }
    }
}
