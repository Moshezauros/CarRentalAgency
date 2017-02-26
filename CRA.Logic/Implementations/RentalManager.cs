using CRA.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRA.Entities;
using DBEntities;

namespace CRA.Logic.Implementations
{
    public class RentalManager : IRentalManager
    {
        private IUnitOfWork _uow;

        public RentalManager()
        {
            _uow = new UnitOfWork();
        }

        public GeneralResponse CreateNewRental(int carId, int userId, DateTime startDate, DateTime endDate)
        {
            var res = new GeneralResponse();

            var car = _uow.Get<Car>().FirstOrDefault(c => c.ID.Equals(carId));
            if (car != null && car.ValidForRental && true) // replace true with model validation
            {
                RentalTracking newRental = new RentalTracking
                {
                    CarId = carId,
                    UserId = userId,
                    StartDate = startDate,
                    PlannedEndDate = endDate
                };

                _uow.Create<RentalTracking>(newRental);
                _uow.Save();

                res.IsValid = true;
                res.Message = newRental.ID.ToString();
            }
            else
            {
                // errors
            }

            return res;
        }

        public GeneralResponse EndRental(int rentalId, DateTime actualEndDate)
        {
            var res = new GeneralResponse();
            var rentalTracking = _uow.Get<RentalTracking>().FirstOrDefault(rt => rt.ID.Equals(rentalId));
            if (rentalTracking != null && rentalTracking.ActualEndDate == null)
            {
                rentalTracking.ActualEndDate = actualEndDate;
                _uow.Save();
                res.IsValid = true;
                res.Message = "Car returned!";
            }
            else
            {

            }

            return res;
        }

        public List<Car> GetActiveCars()
        {

            var res = _uow.Get<Car>().Where(c => c.ValidForRental).OrderBy(c => c.CarType.Manufacturer).ThenBy(c => c.CarType.Model).ToList();
            return res;
        }

        //public List<RentalTracking> GetAllOrders()
        //{
        //    var res = _uow.Get<RentalTracking>().ToList();
        //    return res;
        //}

        public List<RentalTracking> GetCurrentlyActiveRentals()
        {
            var currentlyActive = _uow.Get<RentalTracking>().Where(rt => rt.StartDate <= DateTime.Today && rt.ActualEndDate == null).ToList();

            return currentlyActive;
        }

        public List<RentalTracking> GetRentalsByUser(string username)
        {
            return _uow.Get<RentalTracking>().Where(rt => rt.User.UserName.Equals(username)).ToList();
        }

        public List<RentalTracking> GetAllRentals()
        {
            return _uow.Get<RentalTracking>().ToList();
        }
    }
}
