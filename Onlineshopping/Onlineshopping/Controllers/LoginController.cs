using Onlineshopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Onlineshopping.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Onlineshopping.Models.UserTable usermodel)
        {
            using (MyonlineshopEntities1 db= new MyonlineshopEntities1())
            {
                var userDetails = db.UserTables.Where(x => x.Email == usermodel.Email && x.Password == usermodel.Password).FirstOrDefault();
                if(userDetails==null)
                {
                    usermodel.LoginErrorMessage = "Wrong username or password";
                    return View("Index", usermodel);
                }
                else
                {
                    Session["userID"] = userDetails.Id;
                    return RedirectToAction("Index", "Home");
                }
            }
           
        }

        [HttpGet]
        public ActionResult AddEdit(int id = 0)
        {
            UserTable usermodel = new UserTable();
            return View(usermodel);

        }

        [HttpPost]
        public ActionResult AddEdit(Onlineshopping.Models.UserTable usermodel)
        {
            using (MyonlineshopEntities1 dbmodel = new MyonlineshopEntities1())
            {

                dbmodel.UserTables.Add(usermodel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfull.";
            return View("AddEdit", new UserTable());

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}