using DataAccess;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork19._11._14.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(Models.User user)
        {
            return View(user);
        }

        public ActionResult SignIn(Models.User user)
        {
            return View(user);
        }
        [HttpPost]
        public ActionResult SignInPost(Models.User user)
        {
            if (user.Login == null || user.Password == null) return RedirectToAction("SignIn", user);

            using (var context = new UserContext())
            {
                var foundUser = context.Users.Where(u => u.Login == user.Login).FirstOrDefault();

                if (Hashing.ValidatePassword(user.Password, foundUser.Password))
                    return RedirectToAction("Index", user);
            }

            return RedirectToAction("SignIn", user);
        }

        public ActionResult SignUp(Models.User user)
        {
            return View(user);
        }
        [HttpPost]
        public ActionResult SignUpPost(Models.User user)
        {
            if (DataChecker.IsLoginCorrect(user.Login)
                && DataChecker.IsPasswordCorrect(user.Password)
                && DataChecker.IsEmailCorrect(user.Email)
                && DataChecker.IsPhoneNumberCorrect(user.Phone, '7'))
            {
                user.Password = Hashing.HashPassword(user.Password);

                using (var context = new UserContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();

                    return RedirectToAction("SignIn", user);
                }
            }

            return RedirectToAction("SignUp", user);
        }
    }
}