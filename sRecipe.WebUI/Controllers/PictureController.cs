using sRecipe.Repository.Abstract;
using sRecipe.Repository.Entities;
using sRecipe.WebUI.Infrastructures.Themes;
using sRecipe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Controllers
{
    public class PictureController : ThemeControllerBase
    {
        public PictureController(IsRecipeEFRepository repo) : base(repo)
        {

        }

        public PartialViewResult Upload(int recipeId, int pictureId)
        {
            Picture pic = _repo.GetPicture(pictureId);
            if (pic == null) pic = new Picture();
            RecipePictureViewModel vm = AutoMapper.Mapper.Map<Picture, RecipePictureViewModel>(pic);
            vm.RecipeId = recipeId;
            return PartialView(vm);
        }

        [HttpPost]
        public ActionResult Upload(RecipePictureViewModel pic, HttpPostedFileBase image = null)
        {
            if (image != null)
            {
                pic.MimeType = image.ContentType;
                pic.Data = new byte[image.ContentLength];
                pic.Size = image.ContentLength;
                pic.Uploaded_Time = DateTime.Now;
                pic.UserId = User.UserId;
                image.InputStream.Read(pic.Data, 0, image.ContentLength);
                Picture entity = AutoMapper.Mapper.Map<RecipePictureViewModel, Picture>(pic);
                _repo.InsertPicture(entity);
                _repo.SetRecipePicture(pic.RecipeId, entity.Id);
                return RedirectToAction("Edit", "recipes", new { id = pic.RecipeId });

            }
            //TempData["message"] = string.Format("{0} has been saved", product.Name);
            else
            {
                // there is something wrong with the data values
                return View(pic);
            }
        }

        public FileContentResult GetPicture(int pictureId)
        {
            Picture pic = _repo.GetPicture(pictureId);
            if (pic != null)
            {
                return File(pic.Data, pic.MimeType);
            }
            else
            {
                return null;
            }
        }
    }
}