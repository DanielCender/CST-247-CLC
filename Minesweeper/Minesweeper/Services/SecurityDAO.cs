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
        UserDBService service = new UserDBService();

        public bool Create(User model)
        {
            // Get DB Connection
            var dbConnection = database.DbConnection();

            // Return if registered
            return service.RegisterUser(model, dbConnection);

        }

        public bool Delete(User model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Find(User model)
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool FindByUsernameAndPassword(User user)
        {
            var dbConnection = database.DbConnection();            
            
            // Return if found
            return service.FindByUsernameAndPassword(user.UserName, user.Password, dbConnection);
        }

        public bool FindByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        // TODO: Fix this implementation, this isn't going to work

        public bool Update(int first, string second, int third)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
