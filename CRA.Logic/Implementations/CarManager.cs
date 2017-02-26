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
    public class CarManager : ICarManager
    {
        private IUnitOfWork _uow;

        public CarManager()
        {
            _uow = new UnitOfWork();
        }

        public GeneralResponse AddOrUpdate(Car car)
        {
            var res = new GeneralResponse();

            if (true)  // validate model
            {
                var dbCar = _uow.Get<Car>().FirstOrDefault(c => c.ID.Equals(car.ID));
                if (dbCar != null) // update
                {
                    dbCar.CarType = car.CarType;
                    dbCar.CarTypeId = car.CarTypeId;
                    dbCar.CurrentMileage = car.CurrentMileage;
                    dbCar.ImageName = car.ImageName;
                    dbCar.ValidForRental = car.ValidForRental;

                    _uow.Update<Car>(dbCar);
                    res.Message = "Car updated";
                }
                else // create
                {
                    _uow.Create<Car>(car);
                    res.Message = "New car added";
                }
                res.IsValid = true;
                _uow.Save();
            }
            else
            {
                res.IsValid = false;
            }

            return res;
        }

        public GeneralResponse Delete(int id)
        {
            var res = new GeneralResponse();
            var car = _uow.Get<Car>().FirstOrDefault(c => c.ID.Equals(id));
            if (car != null)
            {
                _uow.Delete(car);
                _uow.Save();
                res.IsValid = true;
            }

            return res;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _uow.Get<Car>().ToList();
        }

        public Car GetCarById(int id)
        {
            return _uow.Get<Car>().FirstOrDefault(c => c.ID.Equals(id));
        }

        public IEnumerable<CarType> GetAllCarTypes()
        {
            return _uow.Get<CarType>();
        }
    }
}
