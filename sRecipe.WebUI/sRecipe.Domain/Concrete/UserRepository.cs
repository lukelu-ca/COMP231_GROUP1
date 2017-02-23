using sRecipe.Domain.Abstract;
using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Concrete
{
    public class UserRepository : IUserRepository
    {
        private sRecipeContext context = new sRecipeContext();
        public IEnumerable<User> Users { get { return context.Users; } }


        /// <summary>
        /// Authenticate email and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string email, string password)
        {
            User login = Users.Where(s => s.Email == email).FirstOrDefault();
            if (login !=null)
            {
                return login.Password == password;
            }
            else
            { return false; }
        }

        public User GetUserByEmail(string email)
        {
          return Users.First(s => s.Email == email);
        }

        /// <summary>
        /// Check whether the user is an administrator
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsAdministrator(string email)
        {
            User user = GetUserByEmail(email);
            if (user != null)
                return user.Role == Role.Administrator;
            else
                return false;
        }
    }
}
