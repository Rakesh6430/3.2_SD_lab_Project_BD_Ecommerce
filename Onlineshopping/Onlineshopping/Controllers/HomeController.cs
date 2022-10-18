using Onlineshopping.Dal;
using Onlineshopping.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Onlineshopping.Controllers
{
    public class HomeController : Controller
    {
        MyonlineshopEntities ctx = new MyonlineshopEntities();
        public ActionResult Index(string search, int? page)
        {
            HomeIndex model = new HomeIndex();
            return View(model.CreateModel(search,3, page));
        }
        /*
        public ActionResult AddToCart(int productId)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = ctx.products.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = ctx.products.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            return Redirect("Index");
        }
        
         */

        public ActionResult AddToCart(int productId, string url)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = ctx.products.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = ctx.products.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.Productid == productId)
                    {
                        int prevQty = cart[i].Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Quantity = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Product.Productid == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = 1
                            });
                        }
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("Index");
        }




        public ActionResult Removefromcart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            //var product = ctx.products.Find(productId);
            foreach(Item item in cart)
            {
                if(item.Product.Productid==productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }

        public ActionResult checkout()
        {
            
            return View();
        }
        public ActionResult checkoutDetails()
        {
            return View();
        }
    }
}