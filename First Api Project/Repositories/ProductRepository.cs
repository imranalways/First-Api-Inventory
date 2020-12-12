//using Code_First_Repository_Pattern.Models;
using First_Api_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace First_Api_Project.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public List<Product> GetTopProducts(int top)
        {
            return GetAll().OrderByDescending(x => x.Price).Take(top).ToList();
        }

        public List<Product> GetProductsByCategory(int id)
        {
            return GetAll().Where(x => x.CategoryId==id).ToList();
        }
        public List<Product> GetProductsByCatProd(int cid,int pid)
        {
            return GetAll().Where(x => x.CategoryId == cid && x.ProductId==pid).ToList();
        }

        public List<Product> GetProductsCategory(int pid, int cid)
        {
            return GetAll().Where(x => x.ProductId == pid || x.CategoryId == cid).ToList();
        }
    }
}