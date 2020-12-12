using First_Api_Project.Models;
using First_Api_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace First_Api_Project.Controllers.api
{
    public class ProductsController : ApiController
    {
        ProductRepository prodrepo = new ProductRepository();
        public IHttpActionResult Get()
        {
            return Ok(prodrepo.GetAll());

        }

        public IHttpActionResult Get(int id)
        {
            var product = prodrepo.Get(id);
            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(product);
        }

        public IHttpActionResult Post(Product product)
        {
            prodrepo.Insert(product);
            return Created("/api/Products"+product.ProductId,product);
        }

        public IHttpActionResult Put([FromUri]int id,[FromBody] Product product)
        {
            product.ProductId = id;
            prodrepo.Update(product);
            return Ok(product);
        }

        public IHttpActionResult Delete(int id)
        {
            prodrepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
