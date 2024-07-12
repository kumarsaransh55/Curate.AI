using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurateAI.Controllers
{
    public class UserController : Controller
    {
        private static InterfaceRepo _repo; 
        public UserController(InterfaceRepo repo) {
            _repo = repo;
        }
        
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(CurateAI.Models.UserDetails ud)
        {
            DataAccess.Model.UserDetails user=new DataAccess.Model.UserDetails();
            user.User_First_Name=ud.User_First_Name;
            user.User_EmailId=ud.User_EmailId;
            user.User_Last_Name=ud.User_Last_Name;
            user.User_Password=ud.User_Password;

            _repo.RegisterUser(user);
            return RedirectToAction("AuthenticateUser");
        }
        [HttpGet]
        public IActionResult AuthenticateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AuthenticateUser(CurateAI.Models.UserDetails ud)
        {
            string uEmail = ud.User_EmailId;
            string uPass= ud.User_Password;
            string admin= _repo.ValidateUser(uEmail, uPass);
            if(admin != null)
            {
                HttpContext.Session.SetString("emailid", uEmail);
                HttpContext.Session.SetString("password", uPass);
                return RedirectToAction("Index", "Site");
            }
            ViewBag.error = "Incorrect username or password";
            return View();
        }

        public IActionResult UpdateProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfile(CurateAI.Models.UserDetails userDetails)
        {
            DataAccess.Model.UserDetails userDetails1 = _repo.GetUser(userDetails.User_EmailId);
            if (userDetails1 == null)
            {
                return RedirectToAction("UpdateProfile");
            }
            userDetails1.User_EmailId = userDetails.User_EmailId;
            userDetails1.User_Last_Name = userDetails.User_Last_Name;
            userDetails1.User_First_Name = userDetails.User_First_Name;
            userDetails1.User_Password = userDetails.User_Password;
            _repo.UpdateUser(userDetails1);
            return View();
        }
    }
}
