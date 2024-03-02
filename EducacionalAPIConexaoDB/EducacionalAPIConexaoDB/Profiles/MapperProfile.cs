using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.ViewModel;
using AutoMapper;

namespace EducacionalAPIConexaoDB.Profiles
{
    public class MapperProfile : Profile
    { 
        public MapperProfile()
        {
            CreateMap<Classroom, ClassroomViewModel>();
            CreateMap<Educational, EducationalViewModel>();
            CreateMap<Email,EmailViewModel>();
            CreateMap<Lack, LackViewModel>();
            CreateMap<Student, StudentViewModel>();

            CreateMap<ClassroomViewModel, Classroom>();
            CreateMap<EducationalViewModel, Educational>();
            CreateMap<EmailViewModel, Email>();
            CreateMap<LackViewModel, Lack>();
            CreateMap<StudentViewModel, Student>();
        }
    }
}
