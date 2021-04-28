using Microsoft.Data.SqlClient;
using Minesweeper.Data;
using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Services
{
    public class SecurityDAO : UserDAOInterface
    {
        Database database = new Database();

        public bool Create(User model)
        {
            // Get DB Connection
            var dbConnection = database.DbConnection();

            // Return if registered
            return database.RegisterUser(model, dbConnection);
        }

        public bool Delete(User model)
        {
            throw new NotImplementedException();
        }

        public User Find(User model)
        {
            throw new NotImplementedException();
        }

        public bool FindByUsernameAndPassword(User user)
        {
            var dbConnection = database.DbConnection();            
            
            // Return if found
            return database.FindByUsernameAndPassword(user, dbConnection);
        }

        public bool Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
