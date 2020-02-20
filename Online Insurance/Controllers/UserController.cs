using System;
using System.Collections.Generic;
using Online_Insurance.Entity;
using Online_Insurance.DAL;
using System.Web.Mvc;

namespace Online_Insurance.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository;
        public UserController()
        {
            userRepository = new UserRepository();
        }
        public ActionResult Index()
        {
            IEnumerable<UserEntity> user = userRepository.GetAlluser();
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
          [HttpPost]
        public ActionResult Create(UserEntity user)
        {
            if (string.IsNullOrEmpty(user.customerName))
            {
                ModelState.AddModelError("userName", "Required");
            }
            if (string.IsNullOrEmpty((user.policyName).ToString()))
            {
                ModelState.AddModelError("policyName", "Required");
            }
            if (string.IsNullOrEmpty((user.phoneNumber).ToString()))
            {
                ModelState.AddModelError("phoneNumber", "Required");
            }
            if (string.IsNullOrEmpty((user.dateOfBirth).ToString()))
            {
                ModelState.AddModelError("dateOfBirth", "Required");
            }
            if (string.IsNullOrEmpty(user.mailId))
            {
                ModelState.AddModelError("mailId", "Required");
            }
            if (string.IsNullOrEmpty(user.password))
            {
                ModelState.AddModelError("password", "Required");
            }
            if (string.IsNullOrEmpty(user.role))
            {
                ModelState.AddModelError("role", "Required");
            }
            if (ModelState.IsValid)
            {
                TryUpdateModel(user);
                userRepository.Add(user);
                TempData["Message"] = "Welcome";
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }

    }
}