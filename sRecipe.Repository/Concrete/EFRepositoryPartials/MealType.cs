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
        public RepositoryActionResult<MealType> InsertMealType(MealType entity)
        {
            return RepositoryActionResultExtensions<MealType, sRecipeContext>
                        .Insert(_ctx,
                                entity
                                );
        }

        public RepositoryActionResult<MealType> DeleteMealType(int id)
        {
            return RepositoryActionResultExtensions<MealType, sRecipeContext>
                 .Delete(_ctx,
                         _ctx.MealTypes
                             .Where(s => s.Id == id)
                              .FirstOrDefault()
                         );
        }


        public RepositoryActionResult<MealType> UpdateMealType(MealType entity)
        {
            return RepositoryActionResultExtensions<MealType, sRecipeContext>
                 .Update(_ctx,
                         _ctx.MealTypes
                             .Where(s => s.Id == entity.Id)
                              .FirstOrDefault(),
                         entity
                         );
        }

        public MealType GetMealType(int id)
        {
            return _ctx.MealTypes.Where(s => s.Id == id).FirstOrDefault();
        }

        public IQueryable<MealType> GetMealTypes()
        {
            return _ctx.MealTypes;
        }

        #endregion
    }
}
