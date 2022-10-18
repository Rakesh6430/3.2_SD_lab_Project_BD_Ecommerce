using Newtonsoft.Json;
using Onlineshopping.Dal;
using Onlineshopping.Models;
using Onlineshopping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Onlineshopping.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public GenericUnitOfWork unitofwork=new GenericUnitOfWork();
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = unitofwork.GetRepositoryInstance<category>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.categoryid.ToString(), Text = item.categoryName });
            }
            return list;
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult category()
        {
            List<category> allcategories = unitofwork.GetRepositoryInstance<category>().GetAllRecordsIQueryable().Where(i => i.Isdelete == false).ToList();
            return View(allcategories);
        }

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int categoryId)
        {
            Categorydetail cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<Categorydetail>(JsonConvert.SerializeObject(unitofwork.GetRepositoryInstance<category>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new Categorydetail();
            }
            return View("UpdateCategory", cd);

        }
        public ActionResult Product()
        {
            return View(unitofwork.GetRepositoryInstance<product>().GetProduct());
        }

        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(unitofwork.GetRepositoryInstance<product>().GetFirstorDefault(productId));
        }

        [HttpPost]
        public ActionResult ProductEdit(product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/productimages/"), pic);
                file.SaveAs(path);
            }
            tbl.productimage = file!=null?pic: tbl.productimage;
            tbl.modifieddate = DateTime.Now;
            unitofwork.GetRepositoryInstance<product>().Update(tbl);
            return RedirectToAction("Product");
        }

        public ActionResult CategoryEdit(int categoryId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(unitofwork.GetRepositoryInstance<product>().GetFirstorDefault(categoryId));
        }

        [HttpPost]
        public ActionResult CategoryEdit(category tbl)
        {
            unitofwork.GetRepositoryInstance<category>().Update(tbl);
            return RedirectToAction("Category");
        }

        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(product tbl,HttpPostedFileBase file)
        {
            string pic=null;
            if(file!=null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/productimages/"), pic);
                file.SaveAs(path);
            }
            tbl.productimage = pic;
            tbl.createdate = DateTime.Now;
            unitofwork.GetRepositoryInstance<product>().Add(tbl);
            return RedirectToAction("Product");
        }
    }

}
