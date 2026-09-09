using AutoMapper;
using Quiz.API.Dtos;
using Quiz.API.Models;

namespace Quiz.API.Mapping {
  public class MappingProfile: Profile {
    public MappingProfile() {
      CreateMap<OptionsDto, Option>();
      CreateMap<Option, OptionsDto>();
      CreateMap<QuestionCreateDto, Question>()
        .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
        .ReverseMap();
    }
  }
}
