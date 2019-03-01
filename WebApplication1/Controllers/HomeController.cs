using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AjaxFormIndex()
        {
            return View();
        }

        public PartialViewResult AjaxUrunGetir()
        {
            var urunler = db.Products.ToList();
            return PartialView("_urunlerPartialView", urunler);
        }
        public PartialViewResult getNancy(string personel)
        {
            List<Orders> orders=null;
            if (!string.IsNullOrEmpty(personel))
            {
                var per = db.Employees.FirstOrDefault(i => i.FirstName == personel);
                if (per!=null)
                {
                     orders = db.Orders.Where(i => i.EmployeeID == per.EmployeeID).ToList();
                }
            }
            return PartialView("_ajaxPartialNancy", orders);
           
        }

        public PartialViewResult Details(int? id)
        {
            var ordersD = db.Order_Details.Where(i=>i.OrderID==id).ToList();

            return PartialView("_ordersPartialView", ordersD);
        }
    }
}