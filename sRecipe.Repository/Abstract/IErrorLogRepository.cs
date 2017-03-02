using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Abstract
{
   public interface IErrorLogRepository
    {
        void Add(ErrorLog entity);
     
    }
}
