using sRecipe.Repository.ActionResults;
using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sRecipe.API.Controllers
{
    public class CommentsController : ApiControllerBase
    {


        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = _repo.GetComment(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/comments")]
        public IHttpActionResult Post([FromBody]Comment entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest();
                }

                // try mapping & saving

                var result = _repo.InsertComment(entity);
                if (result.Status == RepositoryActionStatus.Created)
                {

                    return Created<Comment>(Request.RequestUri 
                            + "/" + result.Entity.Id.ToString(), result.Entity);
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
