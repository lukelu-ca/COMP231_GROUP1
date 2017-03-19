using sRecipe.Repository.Abstract;
using System;
using System.Linq;
using sRecipe.Repository.ActionResults;
using sRecipe.Repository.Entities;
using sRecipe.Repository.Helpers;

namespace sRecipe.Repository.Concrete
{
    public partial class sRecipeEFRepository : IsRecipeEFRepository
    {
        #region User CRUD
        public RepositoryActionResult<User> InsertUser(User entity)
        {
            return RepositoryActionResultExtensions<User, sRecipeContext>
                        .Insert(_ctx,
                                entity
                                );
        }

        public RepositoryActionResult<User> DeleteUser(int id)
        {
            return RepositoryActionResultExtensions<User, sRecipeContext>
                 .Delete(_ctx,
                         _ctx.Users
                             .Where(s => s.Id == id)
                              .FirstOrDefault()
                         );
        }


        public RepositoryActionResult<User> UpdateUser(User entity)
        {
            return RepositoryActionResultExtensions<User, sRecipeContext>
                 .Update(_ctx,
                         _ctx.Users
                             .Where(s => s.Id == entity.Id)
                              .FirstOrDefault(),
                         entity
                         );
        }

        public User GetUser(int id)
        {
            return _ctx.Users.Where(s => s.Id == id).FirstOrDefault();
        }

        public IQueryable<User> GetUsers()
        {
            return _ctx.Users;
        }

        #endregion
    }
}
