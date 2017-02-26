using CRA.Entities;
using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Logic.Interfaces
{
    public interface ICarManager
    {
        GeneralResponse AddOrUpdate(Car car);
        GeneralResponse Delete(int id);
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        IEnumerable<CarType> GetAllCarTypes();

    }
}
