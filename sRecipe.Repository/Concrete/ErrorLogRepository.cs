using sRecipe.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sRecipe.Repository.Entities;

namespace sRecipe.Repository.Concrete
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private sRecipeContext _context = new sRecipeContext();
        public IEnumerable<ErrorLog> ErrorLogs { get { return _context.ErrorLogs; } }


        public void Add(ErrorLog entity)
        {
            _context.ErrorLogs.Add(entity);
            _context.SaveChanges();
        }
    }
}
