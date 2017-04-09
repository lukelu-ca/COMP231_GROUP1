
using sRecipe.DTO.Models;
using sRecipe.Repository.Entities;

namespace sRecipe.DTO
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Recipe, RecipeModel>()
                        .ForMember(dest => dest.MealTypeName,
                                    opts => opts.MapFrom(src => src.MealType.Name)
                                    )
                        .ForMember(dest => dest.UserName,
                                    opts => opts.MapFrom(src => src.User.NickName)
                                    )
                        ;
                config.CreateMap<RecipeModel, Recipe>();
                config.CreateMap<Picture, PictureModel>()
                       .ReverseMap();

                config.CreateMap<Ingredient, IngredientModel>()
                     .ReverseMap();

                config.CreateMap<MealType, MealTypeModel>()
                        .ForMember(dest => dest.MealTypeName,
                                    opts => opts.MapFrom(src => src.Name)
                                   );
                
                config.CreateMap<MealTypeModel, MealType>()
                        .ForMember(dest => dest.Name,
                                    opts => opts.MapFrom(src => src.MealTypeName)
                                   );


            });
        }
    }
}
