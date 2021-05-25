using Microsoft.Data.SqlClient;
using Minesweeper.Data;
using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Services
{
    public class UserSecurityDAO : UserDAOInterface
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

        public bool Delete(int id)
        {
            var dbConnection = database.DbConnection();
            return service.DeleteUser(id, dbConnection);
        }

        public User FindById(int id)
        {
            var dbConnection = database.DbConnection();
            return service.FindById(id, dbConnection);
        }

        public bool FindByUsernameAndPassword(string username, string password)
        {
            var dbConnection = database.DbConnection();            
            
            // Return if found
            return service.FindByUsernameAndPassword(username, password, dbConnection);
        }

        //public bool Update(int id, string column, string changeString)
        //{
        //    var dbConnection = database.DbConnection();
        //    return service.UpdateUser(id, column, changeString, dbConnection);
        //}

        public bool Update(int id, string column, int changeInt)
        {
            var dbConnection = database.DbConnection();
            return service.UpdateUser(id, column, changeInt, dbConnection);
        }
    }
}
