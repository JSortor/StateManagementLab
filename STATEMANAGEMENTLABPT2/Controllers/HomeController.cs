using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STATEMANAGEMENTLABPT2.Models;
using STATEMANAGEMENTLABPT2.Views.Home;

namespace STATEMANAGEMENTLABPT2.Controllers
{
    public class HomeController : Controller
    {
        List<Items> ItemList = new List<Items>()
        {
            new Items("Hot Chocolate", "Milk, Cocoa, Sugar, Fat", 1.99),
            new Items("Latte", "Milk, Coffee", 1.99),
            new Items("Coffee", "Coffee, Water", 1.00),
            new Items("Tea", "Black Tea", 1.00),
            new Items("Frozen Lemonade", "Lemon, Sugar, Ice", 1.00)
        };

        List<Items> ShoppingCart = new List<Items>();
        List<User> UserList = new List<User>();

        public ActionResult Index()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to Justin's Java Hut, We have been in business for only 2 days now but we have all the confidence in the world in our amazing barista's to provide you with the most amazing coffee you have ever had......So happy your looking into JJH now go register and place your first order";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Checkout our contacts below";
            return View();
        }

        public ActionResult RegisterUsers(User newUser)
        {
            Session["CurrentUser"] = newUser;
            ViewBag.CurrentUser = newUser;
            if(Session["CurrentUser"] == null)
            {
                Session["Registered"] = UserList;
                UserList.Add(newUser);
            }
            else
            {
                UserList = (List<User>)Session["Registered"];
            }
            ViewBag.Registered = newUser;
            return View();
        }

        public ActionResult Confirm()
        {
            return View();
        }

        public ActionResult LoginPage(User newUser)
        {
            if (UserList.Contains(newUser))
            {
                Session["CurrentUser"] = newUser;
                return View();
            }
            return View();
        }

        public ActionResult Welcome(User newUser)
        {
            if(Session["CurrentUser"] != null)
            {
                newUser = (User)Session["CurrentUser"];
                ViewBag.CurrentUser = newUser;
                return RedirectToAction("Login Page");
            }
             else
            {
                if (ModelState.IsValid)
                {
                    ViewBag.CurrentUser = newUser;
                    Session["CurrentUser"] = newUser;
                    return View();
                }
                else
                {
                    return View("RegisterUsers");
                }
            }
        }

        public ActionResult Logout()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            Session.Remove("CurrentUser");
            return View();
        }

        public ActionResult ListItems()
        {
            ViewBag.ItemList = ItemList;
            return View();
        }

        public ActionResult AddItem(string itemName)
        {
            if (Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Items>)Session["ShoppingCart"];
            }
            foreach(Items item in ItemList)
            {
                if (item.ItemName == itemName)
                {
                    ShoppingCart.Add(item);
                }
            }
            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("ListItems");
        }

        public ActionResult Cart()
        {
            ShoppingCart = (List<Items>)Session["ShoppingCart"];
            ViewBag.ShoppingCart = ShoppingCart;
            return View();
        }

        public ActionResult DeleteItem(string itemName)
        {
            int i = 0;
            if(Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Items>)Session["ShoppingCart"];
            }
            foreach(Items item in ShoppingCart)
            {
                if(item.ItemName == itemName)
                {
                    break;
                }
                i++;
            }
            ShoppingCart.RemoveAt(i);
            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("Cart");
        }
    }
}