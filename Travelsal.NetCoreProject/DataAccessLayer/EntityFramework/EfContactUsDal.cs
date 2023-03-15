using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangeToFalse(int id)
        {
            using(var c = new Context())
            {
                var value = c.ContactUses.Where(x => x.ContactUsID == id);
                
            }
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using (var c = new Context())
            {
                var values = c.ContactUses.Where(x=>x.MessageStatus==false).ToList();
                return values;
            }
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (var c = new Context())
            {
                var values = c.ContactUses.Where(x => x.MessageStatus == true).ToList();
                return values;
            }
        }

        public List<ContactUs> GetListContactUsOrderByFirstRead()
        {
            using(var c = new Context())
            {
                return c.ContactUses.OrderBy(x=>x.MessageStatus).ToList();
            }
        }
    }
}
