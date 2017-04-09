using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;
using AutoMapper;
using sRecipe.DTO.Models;
using sRecipe.Repository.Entities;
using sRecipe.Repository.Abstract;

namespace sRecipe.DTO
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }

        public RecipeModel Create(Recipe entity)
        {
            RecipeModel model = Mapper.Map<Recipe, RecipeModel>(entity);

            model.Links = new List<LinkModel>()
            {
                CreateLink(_urlHelper.Link("", new { controller="recipes", id = entity.Id }), "self"),
                CreateLink(_urlHelper.Link("", new { controller="picture", id = (entity.PictureId != null  ? entity.PictureId : 0) }), "picture")
            };
            return model;
        }

        public IngredientModel Create(Ingredient entity)
        {
            IngredientModel model = Mapper.Map<Ingredient, IngredientModel>(entity);
            model.Links = new List<LinkModel>()
            {
                CreateLink(_urlHelper.Link("", new { controller="Ingredients", id = entity.Id }), "self"),
                CreateLink(_urlHelper.Link("", new { controller="picture", id = (entity.PictureId != null  ? entity.PictureId : 0) }), "picture")
            };
            return model;
        }

        public MealTypeModel Create(MealType entity)
        {
            MealTypeModel model = Mapper.Map<MealType, MealTypeModel>(entity);
            return model;
        }

        public MealType Parse(MealTypeModel model)
        {
            return Mapper.Map<MealTypeModel, MealType>(model);
        }

        public Recipe Parse(RecipeModel model)
        {
            return Mapper.Map<RecipeModel, Recipe>(model);
        }

        public PictureModel Create(Picture entiy)
        {
            return Mapper.Map<Picture, PictureModel>(entiy);
        }
        public LinkModel CreateLink(string href, string rel, string method = "GET", bool isTemplated = false)
        {
            return new LinkModel()
            {
                Href = href,
                Rel = rel,
                Method = method,
                IsTemplated = isTemplated
            };
        }

        
    }
}
