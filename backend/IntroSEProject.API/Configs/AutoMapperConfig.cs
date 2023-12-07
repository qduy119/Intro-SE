using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.Models;

namespace IntroSEProject.API.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterModel, User>().ReverseMap();
        }
       
    }
}
