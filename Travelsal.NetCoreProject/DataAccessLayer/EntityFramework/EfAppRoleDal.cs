using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAppRoleDal : GenericRepository<AppRole>, IAppRoleDal
    {
        public string GetRoleID(int id)
        {
            using (var c = new Context())
            {
                var value = c.UserRoles.Where(x=>x.UserId==id).FirstOrDefault().RoleId;
                return c.Roles.Where(x => x.Id == value).FirstOrDefault().Name;
            }
        }

        public IdentityUserRole<int> GetUserRole(int id)
        {
            using(var c = new Context())
            {
               return c.UserRoles.Where(x => x.UserId == id).FirstOrDefault();
            }
        }
    }
}
