using Ninject;
using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using sRecipe.WebUI.Infrastructures.Abstract;
using sRecipe.WebUI.Infrastructures.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Infrastructures
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            //Inject Repository
            kernel.Bind<IRecipeRepository>().To<RecipeRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IErrorLogRepository>().To<ErrorLogRepository>();

            //Inject FormsAuthentication
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}