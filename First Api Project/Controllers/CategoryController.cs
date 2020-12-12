using First_Api_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_Api_Project.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryRepository catrepo = new CategoryRepository();
        public ActionResult Index()
        {
            
            return View(catrepo.GetAll());
        }
    }
}