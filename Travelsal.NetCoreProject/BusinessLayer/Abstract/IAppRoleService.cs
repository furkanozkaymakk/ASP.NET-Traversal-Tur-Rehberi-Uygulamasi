using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        string TGetRoleID(int id);
        public IdentityUserRole<int> TGetUserRole(int id);
    }
}
