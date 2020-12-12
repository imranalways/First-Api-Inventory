using First_Api_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_Api_Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductRepository prodrepo = new ProductRepository();
        public ActionResult Index()
        {
            return View(prodrepo.GetAll());
        }
    }
}