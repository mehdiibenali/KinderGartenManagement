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
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles.FirstOrDefault().Role.Name))
                .ReverseMap();
            CreateMap<ClasseViewModel, Classe>()
                .ReverseMap();
            CreateMap<EnrollementViewModel, Enrollement>()
                 .ReverseMap();
            CreateMap<EleveViewModel, Eleve>()
                .ReverseMap();
            CreateMap<ParentViewModel, Parent>()
                .ReverseMap();
            CreateMap<EleveParentViewModel, EleveParent>()
                .ReverseMap();
            CreateMap<EleveEnrollementViewModel, EleveEnrollement>()
                .ReverseMap();
            CreateMap<ConventionViewModel, Convention>()
                .ReverseMap();
            CreateMap<ParentConventionViewModel, ParentConvention>()
                .ReverseMap();
            CreateMap<ConventionFeeViewModel, ConventionFee>()
                .ReverseMap();
            CreateMap<ParameterViewModel, Parameter >()
                .ReverseMap();
            CreateMap<PayementViewModel, Payement>()
                .ReverseMap();
            CreateMap<PayementEnrollementViewModel, PayementEnrollement>()
                .ReverseMap();
            CreateMap<ModaliteViewModel, Modalite>()
                .ReverseMap();
            CreateMap<UnpaidViewModel, PayementEnrollementViewModel>()
                .ReverseMap();
            CreateMap<EleveEnrollement, ShowEleveEnrollementViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Enrollement.Name))
                .ForMember(dest => dest.DateDeDebut, opt => opt.MapFrom(src => src.DateDeDebut))
                .ForMember(dest => dest.DateDeFin, opt => opt.MapFrom(src => src.DateDeFin))
                .ForMember(dest => dest.Classe, opt => opt.MapFrom(src => src.Enrollement.Classe.Name))
                .ReverseMap();
        }
    }
}
