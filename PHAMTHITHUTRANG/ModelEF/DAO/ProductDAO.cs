using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDAO
    {
        private PHAMTHITHUTRANGContext db;

        public ProductDAO()
        {
            db = new PHAMTHITHUTRANGContext();
        }

        public List<Product> ListAll()
        {
            return db.Products.ToList();
        }

        //v
        
        public string Insert(Product entitySanPham)
        {
            db.Products.Add(entitySanPham);
            db.SaveChanges();
            return entitySanPham.ProductID;
        }

        public Product Find(string ProductID)
        {
            return db.Products.Find(ProductID);
        }
        //Hiển thị danh sách sản phẩm : Số lượng tăng dần, Đơn giá giảm dần
        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = (from s in db.Products orderby s.Quantity ascending
                                                               orderby s.UnitCost descending
                                                               select s);
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.ProductName.Contains(keysearch));
            }

            return model.OrderBy(x => x.ProductName).ToPagedList(page, pagesize);
        }

    }
}