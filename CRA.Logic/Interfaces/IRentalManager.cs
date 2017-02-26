using CRA.Entities;
using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Logic.Interfaces
{
    public interface IRentalManager
    {
        GeneralResponse CreateNewRental(int carId, int userId, DateTime startDate, DateTime endDate);
        GeneralResponse EndRental(int rentalId, DateTime actualEndDate);
        List<RentalTracking> GetCurrentlyActiveRentals();
        List<RentalTracking> GetAllRentals();
        List<RentalTracking> GetRentalsByUser(string username);
        List<Car> GetActiveCars();
    }
}
