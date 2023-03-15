using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetListCommentWithDestinationandAppUser();
        List<Comment> GetDestinationById(int id);
        List<Comment> GetListUserComment(int id);
    }
}
