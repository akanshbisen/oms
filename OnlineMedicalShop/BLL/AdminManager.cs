using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class AdminManager
    {
        public bool Validate(string email, string password)
        {
            bool status = AdminDao.Validate(email, password);
            return status;
        }
        
    }
}
