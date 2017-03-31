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
        #region Picture CRUD
        public RepositoryActionResult<Picture> InsertPicture(Picture entity)
        {
            return RepositoryActionResultExtensions<Picture, sRecipeContext>
                        .Insert(_ctx,
                                entity
                                );
        }

        public RepositoryActionResult<Picture> DeletePicture(int id)
        {
            return RepositoryActionResultExtensions<Picture, sRecipeContext>
                 .Delete(_ctx,
                         _ctx.Pictures
                             .Where(s => s.Id == id)
                              .FirstOrDefault()
                         );
        }


        public RepositoryActionResult<Picture> UpdatePicture(Picture entity)
        {
            return RepositoryActionResultExtensions<Picture, sRecipeContext>
                 .Update(_ctx,
                         _ctx.Pictures
                             .Where(s => s.Id == entity.Id)
                              .FirstOrDefault(),
                         entity
                         );
        }

        public Picture GetPicture(int id)
        {
            return _ctx.Pictures.Where(s => s.Id == id).FirstOrDefault();
        }

        public IQueryable<Picture> GetPictures()
        {
            return _ctx.Pictures;
        }

        #endregion
    }
}
