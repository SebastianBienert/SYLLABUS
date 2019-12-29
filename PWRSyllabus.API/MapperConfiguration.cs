using System.Linq;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Enums;
using PWRSyllabusAPI.DTOs;
using Profile = AutoMapper.Profile;

namespace PWRSyllabusAPI
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Discipline, DisciplineDTO>().ReverseMap();
            CreateMap<StudyProgram, StudyProgramDTO>()
                .ForMember(dto => dto.Level,
                           opt => opt.MapFrom(effect => MapLevelToString(effect.Level)));
            CreateMap<MinisterialEffect, MinisterialEffectDTO>()
                .ForMember(dto => dto.Level,
                           opt => opt.MapFrom(effect => MapLevelToString(effect.Level)))
                .ForMember(dto => dto.Discipline,
                            opt => opt.MapFrom(effect => effect.FieldOfKnowledge.Disciplines.FirstOrDefault()));
            
        }

        private string MapLevelToString(Level level)
        {
            if (level == Level.St1Inzynier || level == Level.St1Licencjat)
                return "6";
            if (level == Level.St2Magister || level == Level.St2MagisterInzynier)
                return "7";
            return "8;";
        }
        
    }
}
