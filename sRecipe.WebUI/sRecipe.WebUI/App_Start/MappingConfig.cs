﻿using sRecipe.Domain.Entities;
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

                config.CreateMap<RecipeViewModel, Recipe>()
                       .ReverseMap();

                config.CreateMap<MealTypeViewModel, MealType>()
                       .ReverseMap();

                config.CreateMap<LoginViewModel, LogData>()
                        .ForMember(dest => dest.EmailAddress,
                                    opts => opts.MapFrom(src => src.Email)
                                    );
            });

        }
    }
}