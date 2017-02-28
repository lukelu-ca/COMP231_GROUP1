using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Abstract
{
   public interface IErrorLogRepository
    {
        void Add(ErrorLog entity);
     
    }
}
