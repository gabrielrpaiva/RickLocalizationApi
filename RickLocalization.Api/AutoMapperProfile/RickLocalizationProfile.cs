using AutoMapper;
using RickLocalization.Api.ViewModels;
using RickLocalization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Api.AutoMapperProfile
{
    public class RickLocalizationProfile : Profile
    {
        public RickLocalizationProfile()
        {
            #region Entity X ViewModel

            CreateMap<HumansEntity, HumansViweModel>();
            CreateMap<DimensionsEntity, DimensionViewModel>();

            CreateMap<HumansByDimensionsEntity, HumansByDimensionsViewModel>()
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Human != null ? m.Human.Name : null))
                .ForMember(vm => vm.DimentionName, map => map.MapFrom(m => m.Dimensions != null ? m.Dimensions.Name : null))
                .ForMember(vm => vm.PartnerName, map => map.MapFrom(m => m.HumanResponsibleForMe != null
                 ? m.HumanResponsibleForMe.Name : m.ResponsibleForWhichHuman.Name));

            CreateMap<TravelHistoryEntity, TravelHistoryViewModel>()
                .ForMember(vm => vm.DimensionName, map => map.MapFrom(m => m.Dimensions != null ? m.Dimensions.Name : null));

            #endregion

            #region ViewModel X Entity

            CreateMap<HumansViweModel, HumansEntity>();
            CreateMap<DimensionViewModel, DimensionsEntity>();
            CreateMap<HumansByDimensionsViewModel, HumansByDimensionsEntity>();
            CreateMap<TravelHistoryViewModel, TravelHistoryEntity>();

            #endregion
        }
    }
}
