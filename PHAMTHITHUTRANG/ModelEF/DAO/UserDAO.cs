using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
     public class UserDAO
    {
        private PHAMTHITHUTRANGContext db;
        public UserDAO()
        {
            db = new PHAMTHITHUTRANGContext();
        }

        public int login(string user, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public string Insert(UserAccount entityUserAccount)
        {
            db.UserAccounts.Add(entityUserAccount);
            db.SaveChanges();
            return entityUserAccount.UserName;
        }
        public UserAccount Find(string UserName)
        {
            return db.UserAccounts.Find(UserName);
        }


        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }

            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
    }
}
