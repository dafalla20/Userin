using RegistrationUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationUser.ViewModel;

namespace UserRegstertion.Controllers
{
    public class RegistrationController : Controller
    {
        ApplicationDbContext _context;
        public RegistrationController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Registration
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegistrationUser.ViewModel.RegisterViewModel model)
        {
            RegistrationModel reg = new RegistrationModel();

            string Name = model.UserName;



            var c = _context.Registrations.Where(u => u.UserName == Name).ToList();
            if (c.Count() > 0)
            {
                TempData["message"] = "Not Null";
                return RedirectToAction("Create", "Registration"); 
            }

            reg.FirstName = model.FirstName;
            reg.LastName = model.LastName;
            reg.UserName = model.UserName;
            reg.PassWord = model.PassWord;
            reg.Flag = 0;

         

            _context.Registrations.Add(reg);
            _context.SaveChanges();


            return RedirectToAction("ChangePassWord", "Login");
        }
    }
    
}