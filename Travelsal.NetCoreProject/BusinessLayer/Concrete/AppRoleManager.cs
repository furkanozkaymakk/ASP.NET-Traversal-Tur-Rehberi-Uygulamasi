using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppRoleManager : IAppRoleService
    {
        IAppRoleDal _appRoleDal;

        public AppRoleManager(IAppRoleDal appRoleDal)
        {
            _appRoleDal = appRoleDal;
        }

        public void TAdd(AppRole t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppRole t)
        {
            throw new NotImplementedException();
        }

        public AppRole TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppRole> TGetList()
        {
            throw new NotImplementedException();
        }

        public string TGetRoleID(int id)
        {
            return _appRoleDal.GetRoleID(id);
        }

        public IdentityUserRole<int> TGetUserRole(int id)
        {
            return _appRoleDal.GetUserRole(id);
        }

        public void TUpdate(AppRole t)
        {
            throw new NotImplementedException();
        }
    }
}
