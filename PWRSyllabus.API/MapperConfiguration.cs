using System.Linq;
using Microsoft.JSInterop.Infrastructure;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Enums;
using PWRSyllabus.Core.UseCases.CreateMinisterialEffect;
using PWRSyllabus.Core.UseCases.CreateStudyProgram;
using PWRSyllabus.Core.UseCases.UpdateMinisterialEffect;
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
            CreateMap<FieldOfStudy, FieldOfStudyDTO>()
                .ForMember(dto => dto.Faculty,
                           opt => opt.MapFrom(fos => fos.Faculty.Name));

            CreateMap<FieldOfStudyDTO, FieldOfStudy>();

            CreateMap<StudyProgram, StudyProgramDTO>()
                .ForMember(dto => dto.Level,
                           opt => opt.MapFrom(effect => MapLevelToString(effect.Level)))
                .ForMember(dto => dto.FieldOfStudy,
                           opt => opt.MapFrom(fos => fos.FieldOfStudy))
                .ForMember(dto => dto.FormOfStudies,
                           opt => opt.MapFrom(fos => MapFormOfStudiesToString(fos.FormOfStudies)));

            CreateMap<StudyProgramDTO, StudyProgram>()
                .ForMember(dto => dto.FormOfStudies,
                           opt => opt.MapFrom(fos => GetFormOfStudiesEnum(fos.FormOfStudies)))
                .ForMember(sp => sp.Level,
                           dto => dto.MapFrom(effect => GetLevelEnum(effect.Level)))
                .ForMember(sp => sp.FieldOfStudy,
                           dto => dto.MapFrom(fos => fos.FieldOfStudy));

            CreateMap<StudyProgramDTO, CreateStudyProgramInput>()
                .ForMember(input => input.FieldOfStudyId,
                    opt => opt.MapFrom(dto => dto.FieldOfStudy.Id));

            CreateMap<CreateStudyProgramInput, StudyProgram>()
                .ForMember(effect => effect.Level,
                    opt => opt.MapFrom(input => GetLevelEnum(input.Level)));

            CreateMap<MinisterialEffect, MinisterialEffectDTO>()
                .ForMember(dto => dto.Level,
                           opt => opt.MapFrom(effect => MapLevelToString(effect.Level)))
                .ForMember(dto => dto.Discipline,
                            opt => opt.MapFrom(effect => effect.FieldOfKnowledge.Disciplines.FirstOrDefault()));

            CreateMap<MinisterialEffectDTO, CreateMinisterialEffectInput>()
                .ForMember(input => input.DisciplineId,
                    opt => opt.MapFrom(dto => dto.Discipline.Id));
            CreateMap<CreateMinisterialEffectInput, MinisterialEffect>()
                .ForMember(effect => effect.Level,
                    opt => opt.MapFrom(input => GetLevelEnum(input.Level)));

            CreateMap<MinisterialEffectDTO, UpdateMinisterialEffectInput>()
                .ForMember(input => input.DisciplineId,
                    opt => opt.MapFrom(dto => dto.Discipline.Id));
            CreateMap<UpdateMinisterialEffectInput, MinisterialEffect>()
                .ForMember(effect => effect.Level,
                    opt => opt.MapFrom(input => GetLevelEnum(input.Level)));


        }

        private string MapLevelToString(Level level)
        {
            if (level == Level.St1Inzynier || level == Level.St1Licencjat)
                return "6";
            if (level == Level.St2Magister || level == Level.St2MagisterInzynier)
                return "7";
            return "8";
        }

        //TODO WIKTOR NIECH MI WYJASNI CO ZNACZY LEVEL NA MOCKUPACH A NASZE ENUMY
        private Level GetLevelEnum(string level)
        {
            if (level == "6")
                return Level.St1Inzynier;
            if (level == "7")
                return Level.St2MagisterInzynier;

            return Level.St3Doktoranckie;
        }

        private string MapFormOfStudiesToString(FormOfStudies formOfStudies)
        {
            if (formOfStudies == FormOfStudies.FullTime)
                return "Stacjonarne";
            if (formOfStudies == FormOfStudies.PartTime)
                return "Niestacjonarne";
            return "Stacjonarne";
        }

        private FormOfStudies GetFormOfStudiesEnum(string formOfStudies)
        {
            if (formOfStudies == "Stacjonarne")
                return FormOfStudies.FullTime;
            if (formOfStudies == "Niestacjonarne")
                return FormOfStudies.PartTime;

            return FormOfStudies.FullTime;
        }
    }
}
