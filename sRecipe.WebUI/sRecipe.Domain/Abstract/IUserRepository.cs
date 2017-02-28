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
        User GetUserByEmail(string email);

        void CreateUser(User user);
        void CreateLog(LogData data);
        bool IsEmailExist(string email);
        bool IsNickNameExist(string username);
    }
}
