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
                CreateMap<MealDTO, Meal>();
                CreateMap<NutricionistDTO, Nutricionist>();
                CreateMap<DietDTO, Diet>();
                //como en entrenamiento tenemos en la clase una lista de ejercicios y en el dto un listado de enteros tengo que mapear
                //ese dato concreto para que me convierta el entero a ejercicio
                CreateMap<TrainingDTO, Training>().ForMember(ent => ent.Exercises, dto =>
                dto.MapFrom(campo => campo.Exercises.Select(id => new Exercise { Id = id })));
                CreateMap<ExerciseDTO, Exercise>();
            }
        }
    }
}
