using RegistrationUser.Models;
using System.Linq;
using System.Web.Mvc;

namespace RegistrationUser.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext _context;
        private ApplicationUserManager _userManager;
        public LoginController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewModel.RegisterViewModel model)
        {
            string userName = model.UserName;
            string passWord = model.PassWord;

            var user = _context.Registrations
                      .Where(u => u.UserName == userName 
                      && u.PassWord == passWord).ToList();

            if(user.Count > 0)
            {
                int firstEnterUser = user.First().Flag;

                if (firstEnterUser == 0)
                {
                    
                    return RedirectToAction("ChangePassWord", "Login");

                }
                else
                {
                    return RedirectToAction("welcome", "Login");

                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassWord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassWord(ViewModel.RegisterViewModel model)
        {
            string userName = model.UserName;
            string passWord = model.PassWord;
            string newPassWord = model.newPassWord;

            var user = _context.Registrations
                      .Single(u => u.UserName == userName
                      && u.PassWord == passWord);

            user.PassWord = newPassWord;
            user.Flag = 1;
            _context.SaveChanges();


            return RedirectToAction("welcome", "Login");

        }

        public ActionResult welcome()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            return RedirectToAction("Create", "Registration");
        }

    }
}