using Dapper;
using Microsoft.EntityFrameworkCore;
using NutriApp.Data.Interfaces;
using NutriApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriApp.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(NutriAppContext context) : base(context)
        {
        }

        public User Find(string userID)
        {
            return Db.Database.GetDbConnection().QueryFirstOrDefault<User>(
                                "SELECT UserID, AccessKey " +
                                "FROM dbo.Users " +
                                "WHERE UserID = @UserID", new { UserID = userID });
        }
    }
}

