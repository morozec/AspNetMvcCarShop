using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarShop.Models;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ShopDBEntities _db = new ShopDBEntities();
        public ActionResult Index()
        {
            var items = _db.Cars;
            return View(items);
        }

        public ActionResult CarPage(int itemId)
        {
            var item = _db.Cars.FirstOrDefault(x => x.Id == itemId);
            return View(item);
        }
       
        [ChildActionOnly]
        public ActionResult Nav()
        {
            var items = _db.Cars;
            var result = "";
            foreach (var item in items)
            {
                result += $"<li><a href='/Home/CarPage/?itemId={item.Id}' title={item.Title}>{item.Title}</a></li>";
            }

            return Content(result);
        }

        [HttpGet]
        public ActionResult Form(int itemId=0)
        {
            ViewBag.item = itemId;
            return PartialView();
        }

        [ChildActionOnly]
        public string FormOptions(int itemId = 0)
        {
            var str = "";
            var items = _db.Cars;
            foreach (var car in items)
            {
                var selected = car.Id == itemId ? "selected" : "";
                str += $"<option value={car.Id} {selected}>{car.Title}</options>";
            }

            return str;
        }

        [HttpPost]
        public string Form(string name, string tel, int car)
        {
            var order = new Order()
            {
                UserName = name,
                CarId = car,
                UserTel = tel,
                Status = "Создана"
            };
            _db.Orders.Add(order);
            _db.SaveChanges();
            return $"Ваша заявка на авто {_db.Cars.FirstOrDefault(x => x.Id == car).Title} принята";
        }
    }
}