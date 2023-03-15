using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentWithDestinationandAppUser()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Destination).Include(x=>x.AppUser).ToList();
            }
        }

        public List<Comment> GetListUserComment(int id)
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x=>x.Destination).Where(x=>x.AppUserID== id).ToList();
            }
        }

        public List<Comment> GetDestinationById(int id)
        {
            using (var context = new Context())
            {
                return context.Comments.Include(x => x.Destination).Include(x => x.AppUser).Where(x => x.DestinationID == id).ToList();
            }
        }
    }
}
