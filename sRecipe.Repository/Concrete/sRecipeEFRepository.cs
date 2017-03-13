using sRecipe.Repository.Abstract;

namespace sRecipe.Repository.Concrete
{
    public partial class sRecipeEFRepository : IsRecipeEFRepository
    {
        sRecipeContext _ctx;
        public sRecipeEFRepository()
        {
            _ctx = new sRecipeContext();
        }
    }
}
