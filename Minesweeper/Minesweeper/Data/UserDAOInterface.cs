using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    interface UserDAOInterface
    {
        public User find(User model);
        public User findBy(string field, string val);
        public bool create(User model);
        public bool update(User model);
        public bool delete(User model);
    }
}
