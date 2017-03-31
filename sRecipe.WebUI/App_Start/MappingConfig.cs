using sRecipe.Repository.Entities;
using sRecipe.WebUI.Infrastructures.Concrete.SerializeModels;
using sRecipe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<UserViewModel, User>()
                       .ReverseMap();
                config.CreateMap<IngredientViewModel, Ingredient>()
                       .ReverseMap();
                config.CreateMap<DirectionViewModel, Direction>()
                       .ReverseMap();
                config.CreateMap<RecipePictureViewModel,Picture>()
                      .ReverseMap();
                config.CreateMap<CommentViewModel, Comment>();

                config.CreateMap<Comment, CommentViewModel>()
                      .ForMember(dest => dest.NickName,
                                 opts => opts.MapFrom(src => src.User.NickName));



                config.CreateMap<Recipe, RecipeViewModel>()
                        .ForMember(dest => dest.MealTypeName,
                                    opts => opts.MapFrom(src => src.MealType.Name)
                                    )
                        .ForMember(dest => dest.UserName,
                                    opts => opts.MapFrom(src => src.User.NickName)
                                    )
                        ;
                config.CreateMap<RecipeViewModel, Recipe>();

                config.CreateMap<MealTypeViewModel, MealType>()
                       .ReverseMap();

                config.CreateMap<LoginViewModel, LogData>()
                        .ForMember(dest => dest.EmailAddress,
                                    opts => opts.MapFrom(src => src.Email)
                                    );

                config.CreateMap<User, sRecipePrincipalSerializeModel>()
                        .ForMember(dest => dest.UserId,
                                   opts => opts.MapFrom(src => src.Id))
                        .ForMember(dest => dest.Profile,
                                    opts => opts.MapFrom(
                                        src =>
                                        new ProfileSerializeModel
                                        {
                                            Location = src.Profile.Location,
                                            ColorTheme = src.Profile.ColorTheme,
                                            ViewTheme = src.Profile.ViewTheme
                                        }
                                        )
                                   );
            });

        }
    }
}