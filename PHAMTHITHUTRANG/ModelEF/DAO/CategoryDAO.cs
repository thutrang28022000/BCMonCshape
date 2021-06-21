using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
   public class CategoryDAO
    {
        PHAMTHITHUTRANGContext db = null;
        public CategoryDAO()
        {
            db = new PHAMTHITHUTRANGContext();
        }


        public Category Find(string CategoryID)
        {
            return db.Categories.Find(CategoryID);
        }

        public string Insert(Category entityProduct)
        {
            db.Categories.Add(entityProduct);
            db.SaveChanges();
            return entityProduct.CategoryID;
        }
        //chưa cần
        //public void Edit(Category entity)
        //{
        //    var result = db.Categories.Where(x => x.CategoryID.Contains(entity.CategoryID)).FirstOrDefault();
        //    db.Entry(result).CurrentValues.SetValues(entity);
        //    db.SaveChanges();
        //}

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }

        public IEnumerable<Category> ListWhereAll(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CategoryID.Contains(searchString) || x.CategoryName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CategoryID).ToPagedList(page, pageSize);
        }




    }
}