using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAppRoleDal : IGenericDal<AppRole>
    {
        string GetRoleID(int id);
        public IdentityUserRole<int> GetUserRole(int id);
    }
}
