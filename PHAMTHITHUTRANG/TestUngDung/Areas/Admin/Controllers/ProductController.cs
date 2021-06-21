using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        PHAMTHITHUTRANGContext dbcontext = new PHAMTHITHUTRANGContext();
        ProductDAO dao = new ProductDAO();

        //GET: Admin/Product
        public ActionResult Index(int page = 1, int pagesize = 2)
        {
            var product = new ProductDAO();
            var model = product.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 2)
        {

            var product = new ProductDAO();
            var model = product.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

    
        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var id_sp = new ProductDAO();
                if (id_sp.Find(model.ProductID) != null)
                {
                    return RedirectToAction("Create", "Product");
                }

                string result = id_sp.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {

                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo sản phẩm không thành công");

                }
            }
            return View(model);
        }
    

        public void SetViewBag(string selectedId = null)
        {
            var cate = new CategoryDAO();
            ViewBag.type = new SelectList(cate.ListAll(), "CategoryID", "CategoryName", selectedId);

        }



    }
}