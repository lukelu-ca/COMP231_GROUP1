using sRecipe.Repository.Abstract;
using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        private sRecipeContext context = new sRecipeContext();
        public IEnumerable<User> Users { get { return context.Users; } }
        public IEnumerable<LogData> LogDatas { get { return context.LogDatas; } }


        /// <summary>
        /// Authenticate email and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string email, string password)
        {
            User login = Users.Where(s => s.Email == email).FirstOrDefault();
            if (login != null)
            {
                if (login.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }
        }
        public void CreateLog(LogData data)
        {
            context.LogDatas.Add(data);
            context.SaveChanges();
        }
        public void CreateUser(User user)
        {
                context.Users.Add(user);
                context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return Users.FirstOrDefault(s => s.Email == email);
        }

 
        /// <summary>
        /// Check whether the email has already signed up
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsEmailExist(string email)
        {
            return GetUserByEmail(email) != null;
        }

        public bool IsNickNameExist(string username)
        {
            return Users.FirstOrDefault(s => s.NickName == username) != null;
        }
    }
}
