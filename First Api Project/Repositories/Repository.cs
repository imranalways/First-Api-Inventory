//using Code_First_Repository_Pattern.Models;
using First_Api_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace First_Api_Project.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected InventoryDBEntities context = new InventoryDBEntities();
        public void Delete(int id)
        {
            context.Set<T>().Remove(Get(id));
            context.SaveChanges();
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}