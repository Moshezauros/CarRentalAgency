using CRA.Entities;
using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Logic.Interfaces
{
    public interface IUserManager
    {
        GeneralResponse CreateNewUser(User user);
        GeneralResponse LoginValid(string userName, string password);
        int GetUserId(string userName);
    }
}
