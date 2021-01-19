using Project4._0_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
    }
}
