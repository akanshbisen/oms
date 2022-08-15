using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;



namespace BLL
{
    public class UserManager
    {
        public bool ValidateUser(string email, string password)
        {
            bool status = UserDao.ValidateUser(email, password);
            return status;
        }
        public bool RegisterUser(User u)
        {
            bool status = UserDao.RegisterUser(u);
            return status;
        }
    }
}
