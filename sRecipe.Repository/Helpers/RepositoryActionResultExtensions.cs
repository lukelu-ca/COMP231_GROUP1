using sRecipe.Repository.ActionResults;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Helpers
{
    public static class RepositoryActionResultExtensions<T, D>
                where T : class //the object will be insert, update, delete
                where D : DbContext //the dbcontext
    {
        public static RepositoryActionResult<T> Insert(D ctx, T e)
        {
            try
            {
                ctx.Set<T>().Add(e); //add a object into the table
                var result = ctx.SaveChanges(); //save the data
                if (result > 0)
                {
                    //if insert successfully, return created and the object which was inserted
                    return new RepositoryActionResult<T>(e, RepositoryActionStatus.Created);
                }
                else
                {
                    //if insert failed, return nothingmodified
                    return new RepositoryActionResult<T>(e, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                //if there is error causing, return the error
                return new RepositoryActionResult<T>(null, RepositoryActionStatus.Error, ex);
            }
        }
        /// <summary>
        /// Delete an object from table
        /// </summary>
        /// <param name="ctx">the DBContext object</param>
        /// <param name="table">the table object in dbcontext</param>
        /// <param name="exp">
        /// the object contains is the object exist
        /// usual using  ctx.table.Where(s => s.Id == id).FirstOrDefault()
        /// </param>
        /// <returns></returns>
        public static RepositoryActionResult<T> Delete(D ctx, T exp)
        {
            try
            {
                //check is the object already existed?
                if (exp != null)
                {
                    //if object exist, remove it
                    ctx.Set<T>().Remove(exp);
                    ctx.SaveChanges();
                    //return deleted successfully
                    return new RepositoryActionResult<T>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<T>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<T>(null, RepositoryActionStatus.Error, ex);
            }
        }

        /// <summary>
        /// update an object in the table
        /// </summary>
        /// <param name="ctx">the DBContext object</param>
        /// <param name="table">the table object in dbcontext</param>
        /// <param name="exp">
        /// the object contains whether the entity exists
        /// usual using  ctx.table.Where(s => s.Id == id).FirstOrDefault()
        /// </param>
        /// <param name="e">
        /// the object contains the actual updated values of this class
        /// </param>
        /// <returns></returns>
        public static RepositoryActionResult<T> Update(D ctx, T exp, T e)
        {
            try
            {

                // you can only update when an entity already exists for this id


                if (exp == null)
                {
                    return new RepositoryActionResult<T>(e, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                //ctx.Entry(e).State = EntityState.Modified;

                //// attach & save
                //table.Attach(e);

                //// set the updated entity state to modified, so it gets updated.
                //ctx.Entry(e).State = EntityState.Modified;

                ctx.Set<T>().AddOrUpdate(e);

                var result = ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<T>(e, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<T>(e, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<T>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}
