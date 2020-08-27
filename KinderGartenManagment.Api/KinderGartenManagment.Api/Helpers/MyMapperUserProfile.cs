using KinderGartenManagment.Api.Models;
using KinderGartenManagment.Api.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Helpers
{
    public class MyMapperProfile : Profile
    {
        public MyMapperProfile()
        {
            CreateMap<UserViewModel, User>()
                .ReverseMap();
            CreateMap<User, SUserViewModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles.FirstOrDefault().Role.Name))
                .ReverseMap();
            CreateMap<ClasseViewModel, Classe>()
                .ReverseMap();
            CreateMap<GroupeViewModel, Groupe>()
                 .ReverseMap();
            CreateMap<EleveViewModel, Eleve>()
                .ReverseMap();
            CreateMap<ParentViewModel, Parent>()
                .ReverseMap();
            CreateMap<EleveParentViewModel, EleveParent>()
                .ReverseMap();
            CreateMap<EleveGroupeViewModel, EleveGroupe>()
                .ReverseMap();
            CreateMap<ConventionViewModel, Convention>()
                .ReverseMap();
        }
    }
}
