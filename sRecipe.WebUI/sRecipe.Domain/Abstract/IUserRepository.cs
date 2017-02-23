using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get;  }

        bool Authenticate(string email, string password);
        bool IsAdministrator(string username);
        User GetUserByEmail(string email);
    }
}
