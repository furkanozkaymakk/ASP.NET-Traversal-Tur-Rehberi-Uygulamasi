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
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            return _reservationDal.GetListWithReservationByAccepted(id);
        }

        public List<Reservation> GetListWithReservationByPrevius(int id)
        {
            return _reservationDal.GetListWithReservationByPrevius(id);
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            return _reservationDal.GetListWithReservationByWaitApproval(id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public List<Reservation> TGetApprovalReservation()
        {
            return _reservationDal.GetApprovalReservation();
        }

        public Reservation TGetByID(int id)
        {
            return _reservationDal.TGetByID(id);
        }

        public List<Reservation> TGetCurrentReservation()
        {
            return _reservationDal.GetCurrentReservation();
        }

        public List<Reservation> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<Reservation> TGetOldReservation()
        {
            return _reservationDal.GetOldReservation();
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
