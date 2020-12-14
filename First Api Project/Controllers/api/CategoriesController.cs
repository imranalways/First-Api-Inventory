using First_Api_Project.Attributes;
using First_Api_Project.Models;
using First_Api_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace First_Api_Project.Controllers.api
{
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        CategoryRepository catrepo = new CategoryRepository();

        [Route(""), BasicAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(catrepo.GetAll());

        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var category = catrepo.Get(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(category);
        }

        [Route("")]
        public IHttpActionResult Post(Category category)
        {
            catrepo.Insert(category);
            return Created("/api/Categories" + category.CategoryId, category);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Category category)
        {
           category.CategoryId= id;
            catrepo.Update(category);
            return Ok(category);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            ProductRepository prodrepo = new ProductRepository();
            var prod=prodrepo.GetProductsByCategory(id);
            if (prod == null)
            {
            }
            else
            {
                foreach (var item in prod)
                {
                    prodrepo.Delete(item.ProductId);
                }
            }
            
            catrepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/Products")]
        public IHttpActionResult GetProductByCategoryId(int id)
        {
            ProductRepository prodrepo = new ProductRepository();
            
            return Ok(prodrepo.GetProductsByCategory(id));
        }

        [Route("{cid}/Products/{pid}")]
        public IHttpActionResult GetProductByCategoryProduct(int cid, int pid)
        {
            ProductRepository prodrepo = new ProductRepository();

            return Ok(prodrepo.GetProductsByCatProd(cid, pid));
        }

        [Route("{pid}/Categories/{cid}/Products")]
        public IHttpActionResult GetProductsCategory(int pid, int cid)
        {
            ProductRepository prodrepo = new ProductRepository();

            return Ok(prodrepo.GetProductsCategory(pid, cid));
        }
    }
}
