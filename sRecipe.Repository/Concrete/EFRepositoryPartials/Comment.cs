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
        #region Comment CRUD
        public RepositoryActionResult<Comment> InsertComment(Comment entity)
        {
            return RepositoryActionResultExtensions<Comment, sRecipeContext>
                        .Insert(_ctx,
                                entity
                                );
        }

        public RepositoryActionResult<Comment> DeleteComment(int id)
        {
            return RepositoryActionResultExtensions<Comment, sRecipeContext>
                 .Delete(_ctx,
                         _ctx.Comments
                             .Where(s => s.Id == id)
                              .FirstOrDefault()
                         );
        }


        public RepositoryActionResult<Comment> UpdateComment(Comment entity)
        {
            return RepositoryActionResultExtensions<Comment, sRecipeContext>
                 .Update(_ctx,
                         _ctx.Comments
                             .Where(s => s.Id == entity.Id)
                              .FirstOrDefault(),
                         entity
                         );
        }

        public Comment GetComment(int id)
        {
            return _ctx.Comments.Where(s => s.Id == id).FirstOrDefault();
        }

        public IQueryable<Comment> GetComments()
        {
            return _ctx.Comments;
        }

        #endregion
    }
}
