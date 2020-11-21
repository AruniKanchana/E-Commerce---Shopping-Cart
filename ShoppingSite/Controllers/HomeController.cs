using ShoppingSite.Models.Home;
using System;
using System.Collections.Generic;
using ShoppingSite.Repositary;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingSite.DAF;

namespace ShoppingSite.Controllers
{
    public class HomeController : Controller
    {
        dbMyOnlineShoppingEntities dcon = new dbMyOnlineShoppingEntities();
        
        public ActionResult Index(string search, int? page)
        {
              HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search,4, page));
        }

        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CheckoutDetails()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult DecreaseQty(int productId)
        {
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = dcon.Tbl_Product.Find(productId);
                foreach (var item in cart)
                {
                    if (item.Product.ProductId == productId)
                    {
                        int previousQty = item.Quantity;
                        if (previousQty > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = previousQty - 1
                                
                            });
                           
                        }
                        break;
                    }
                }
                 Session["cart"] = cart;
            }
            return Redirect("Checkout");
        }
        public ActionResult AddtoCart(int productId)
        {
            if(Session["cart"]==null)
            {
                List<Item> cart = new List<Item>();
                var product = dcon.Tbl_Product.Find(productId);
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
                var product = dcon.Tbl_Product.Find(productId);
                for(int i= 0; i < count; i++)
                {
                    if (cart[i].Product.ProductId == productId)
                    {
                        int previousQty = cart[i].Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Quantity = previousQty + 1
                        });
                        break;
                    }
                
                    else
                    {
                         var prd = cart.Where(x => x.Product.ProductId == productId).SingleOrDefault();
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
        public ActionResult RemoveCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach(var item in cart)
            {
                if (item.Product.ProductId == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            
            Session["cart"] = cart;
            return Redirect("Checkout");
        }

        
    }
}