using AutoMapper;
using DB;
using MyHealthFirst.DTOs;

namespace MyHealthFirst.AutoMapperProfiles
{
    public class AutoMapperProfile
    {
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
            
                CreateMap<TrainerDTO, Trainer>();
                CreateMap<ClientDTO, Client>();
            }
        }
    }
}
