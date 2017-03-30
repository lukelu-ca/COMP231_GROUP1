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

        #region Direction CRUD
        public RepositoryActionResult<Direction> InsertDirection(Direction entity)
        {
            return RepositoryActionResultExtensions<Direction, sRecipeContext>
                        .Insert(_ctx,
                                entity
                                );
        }

        public IQueryable<Direction> GetDirections()
        {
            return _ctx.Directions;
        }

        public Direction GetDirection(int id)
        {
            return _ctx.Directions.Where(s => s.Id == id).FirstOrDefault();
        }

        public RepositoryActionResult<Direction> UpdateDirection(Direction entity)
        {
            return RepositoryActionResultExtensions<Direction, sRecipeContext>
                 .Update(_ctx,
                         _ctx.Directions
                             .Where(s => s.Id == entity.Id)
                              .FirstOrDefault(),
                         entity
                         );
        }
        public RepositoryActionResult<Direction> DeleteDirection(int id)
        {
            return RepositoryActionResultExtensions<Direction, sRecipeContext>
                 .Delete(_ctx,
                         _ctx.Directions
                             .Where(s => s.Id == id)
                              .FirstOrDefault()
                         );
        }
        #endregion
    }
}
