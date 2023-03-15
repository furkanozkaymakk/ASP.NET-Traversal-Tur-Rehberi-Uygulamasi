using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _commentDal.TGetByID(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
        public List<Comment> TGetDestinationById(int id)
        {
            return _commentDal.GetDestinationById(id);
        }

        public List<Comment> TGetListCommentWithDestinationandAppUser()
        {
            return _commentDal.GetListCommentWithDestinationandAppUser();
        }

        public List<Comment> TGetListUserComment(int id)
        {
            return _commentDal.GetListUserComment(id);
        }
    }
}
