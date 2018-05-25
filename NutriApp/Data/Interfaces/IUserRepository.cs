using NutriApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriApp.Data.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Find(string userID);
    }
}
