using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppinCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(int id, bool? getBool)
        {
            if (getBool == false)
            {
                Course courses = APIConsumer<Course>.GetObject("course", id.ToString());

                if (Session["cart"] == null)
                {
                    List<ShoppingCart> cart = new List<ShoppingCart>();
                    cart.Add(new ShoppingCart() {Course = courses, Quantity = 1});
                    Session["cart"] = cart;
                    Session["count"] = 1;
                }
                else
                {
                    List<ShoppingCart> cart = (List<ShoppingCart>) Session["cart"];

                    int index = ItemExists(id, false);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                        Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                    }
                    else
                    {
                        cart.Add(new ShoppingCart() {Course = courses, Quantity = 1});
                        Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                    }

                    Session["card"] = cart;

                }
                return RedirectToAction("Index", "Course");


            }
            if(getBool == true)
            {
                Product products = APIConsumer<Product>.GetObject("product", id.ToString());

                if (Session["cart"] == null)
                {
                    List<ShoppingCart> cart = new List<ShoppingCart>();
                    cart.Add(new ShoppingCart() {Product = products, Quantity = 1});
                    Session["cart"] = cart;
                    Session["count"] = 1;
                }
                else
                {
                    List<ShoppingCart> cart = (List<ShoppingCart>) Session["cart"];

                    int index = ItemExists(id, true);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                        Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                    }
                    else
                    {
                        cart.Add(new ShoppingCart() {Product = products, Quantity = 1});
                        Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                    }

                    Session["card"] = cart;
                }

                return RedirectToAction("Index", "Product");
            }

            return null;
        }

        public ActionResult RemoveQuantity(int id, bool? getBool)
        {
            if (getBool == false)
            {
                List<ShoppingCart> cart = (List<ShoppingCart>) Session["cart"];
                int index = ItemExists(id, false);
                if (cart[index].Quantity > 1)
                {
                    cart[index].Quantity--;
                    Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                }
                else
                {
                    cart.RemoveAt(index);
                    Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                }

                Session["cart"] = cart;
            }
            else
            {
                List<ShoppingCart> cart = (List<ShoppingCart>) Session["cart"];
                int index = ItemExists(id, true);
                if (cart[index].Quantity > 1)
                {
                    cart[index].Quantity--;
                    Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                }
                else
                {
                    cart.RemoveAt(index);
                    Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                }

                Session["cart"] = cart;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id, bool? getBool)
        {
            if (getBool == false)
            {
                List<ShoppingCart> cart = (List<ShoppingCart>) Session["cart"];
                int index = ItemExists(id, false);
                Session["cart"] = cart;

                if (index != -1)
                {
                    int aantal = cart[index].Quantity;
                    Session["count"] = Convert.ToInt32(Session["count"]) - aantal;
                }
                else if (cart.Count == 0)
                {
                    Session["count"] = 0;
                }

                cart.RemoveAt(index);
            }
            else
            {
                List<ShoppingCart> cart = (List<ShoppingCart>) Session["cart"];
                int index = ItemExists(id, true);
                Session["cart"] = cart;

                if (index != -1)
                {
                    int aantal = cart[index].Quantity;
                    Session["count"] = Convert.ToInt32(Session["count"]) - aantal;
                }
                else if (cart.Count == 0)
                {
                    Session["count"] = 0;
                }

                cart.RemoveAt(index);
            }

            return RedirectToAction("Index");
        }

        private int ItemExists(int? id, bool isProduct)
        {
            List<ShoppingCart> cart = (List<ShoppingCart>) Session["cart"];

            for (int i = 0; i < cart.Count; i++)
            {
                if (isProduct == false)
                {
                    if (cart[i].Product == null)
                    {
                        if (cart[i].Course.Id.Equals(id))
                        {

                            return i;
                        }
                    }
                }
                else {
                    if (cart[i].Course == null)
                    {
                        if (cart[i].Product.Id.Equals(id))
                        {
                            return i;
                        }
                    }
                }
            }

            return -1;
        }
    }
}