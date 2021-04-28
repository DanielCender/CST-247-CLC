using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    interface UserDAOInterface
    {
        public User Find(User model);
        public bool FindByUsernameAndPassword(User model);        
        public bool Create(User model);
        public bool Update(User model);
        public bool Delete(User model);
    }
}
