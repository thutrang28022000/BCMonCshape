using ModelEF;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
//using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        //GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new UserDAO();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {

            var user = new UserDAO();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDAO();
                //
                //
                if (dao.Find(model.UserName) != null)
                {
                    return RedirectToAction("Create", "User");
                }
                var pass = Common.EncryptMD5(model.Password);
                model.Password = pass;
                string result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {

                    RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo người dùng không thành công!");

                }
                
            }
            return View();
        }
    }
}