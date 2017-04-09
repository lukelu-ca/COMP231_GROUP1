using sRecipe.API.Helpers;
using sRecipe.Repository.Abstract;
using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace sRecipe.API.Controllers
{
    [RoutePrefix("api/picture")]
    public class PictureController : BaseApiController
    {
        public PictureController(IsRecipeEFRepository repo) : base(repo)
        {

        }

        //POST api/picture
        [Route("{id:int}")]
        [HttpPost]
        public HttpResponseMessage Post(int id, int userId = 1)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    Stream filestream = postedFile.InputStream;
                    byte[] buffer = ReadFully(filestream);
                    Picture pic = new Picture()
                    {
                        MimeType = postedFile.ContentType,
                        Data = buffer,
                        FileName = "",
                        Description = "",
                        UserId = userId,
                    };
                    TheRepository.InsertPicture(pic);
                    if (id != 0)
                    {
                        Recipe recipe = TheRepository.GetRecipe(id);
                        recipe.PictureId = pic.Id;
                        TheRepository.UpdateRecipe(recipe);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(pic));
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        private byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        //GET api/picture/5
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var pic = TheRepository.GetPicture(id);

            MemoryStream ms;
            string mimetype;
            if (pic != null && pic.Data != null)
            {
                ms = new MemoryStream(pic.Data);
                mimetype = pic.MimeType;
            }
            else
            {
                using (FileStream file = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/images/nophoto.png")
                    , FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms = new MemoryStream(bytes);
                    mimetype = "image/gif";
                }
            }
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mimetype);
            return response;
        }

    }
}
