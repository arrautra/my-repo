using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICache _cache;
        public HomeController()
        {
            _cache = new MyCache();
        }

        public ActionResult Index()
        {
            var cache = DependencyResolver.Current.GetService<ICache>();
            string cacheVal = _cache.Get<string>("Key1");
            if (cacheVal == null)
            {
                _cache.Add("Key1", "value1", DateTime.Now.Add(new TimeSpan(0, 5, 0)));
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


}