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
    public class UserManager : IUserManager
    {
        private IUnitOfWork _uow;

        public UserManager()
        {
            _uow = new UnitOfWork();
        }

        public GeneralResponse CreateNewUser(User user)
        {
            var res = new GeneralResponse();
            if (true) // validate user
            {
                _uow.Create<User>(user);
                _uow.Save();
                res.IsValid = true;
            }
            else
            {
                res.Errors = new List<string> { "id not valid" };
                res.IsValid = false;
            }

            return res;
        }

        public int GetUserId(string userName)
        {
            var user = _uow.Get<User>().FirstOrDefault(u => u.UserName.Equals(userName));
            if (user != null)
                return user.Id;
            else
            {
                throw new Exception("User not found!");
            }
            
        }

        public GeneralResponse Login(string userName, string password)
        {
            if (_uow.Get<User>().FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password)) != null)
            {
                return new GeneralResponse
                {
                    IsValid = true,
                };
            }
            else
            {
                return new GeneralResponse
                {
                    IsValid = false,
                    Errors = new List<string> { "Username or password isn't valid" },
                };
            }

        }

        public GeneralResponse LoginValid(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
