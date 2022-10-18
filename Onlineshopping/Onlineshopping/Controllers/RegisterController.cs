using Onlineshopping.Dal;
using Onlineshopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onlineshopping.Models;
namespace Onlineshopping.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        MyonlineshopEntities1 db = new MyonlineshopEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveData(UserTable model)
        {
            db.UserTables.Add(model);
            db.SaveChanges();
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddEdit(int id=0)
        {
            UserTable usermodel = new UserTable();
            return View(usermodel);
           
        }

        [HttpPost]
        public ActionResult AddEdit(UserTable usermodel)
        {
            using(MyonlineshopEntities1 dbmodel=new MyonlineshopEntities1())
            {
               
                dbmodel.UserTables.Add(usermodel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfull.";
            return RedirectToAction("Index", "Login");

        }

    }
}