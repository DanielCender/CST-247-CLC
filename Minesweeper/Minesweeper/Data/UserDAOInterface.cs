using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    interface UserDAOInterface
    {
        public User FindById(int id);
        public bool FindByUsernameAndPassword(string username, string password);        
        public bool Create(User model);
        public bool Update(int id, string column, int changeInt);
        public bool Delete(int id);
    }
}
