using System.Linq;
using Microsoft.JSInterop.Infrastructure;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Enums;
using PWRSyllabus.Core.UseCases.CreateMinisterialEffect;
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

            CreateMap<Course, CourseDTO>()
                .ForMember(dto => dto.CourseForm,
                           opt => opt.MapFrom(c => MapCourseFormToString(c.CourseForm)));

            CreateMap<CourseDTO, Course>()
                .ForMember(dto => dto.CourseForm,
                           opt => opt.MapFrom(c => GetCourseFormEnum(c.CourseForm)));

            CreateMap<SubjectCard, SubjectCardDTO>();
            //CreateMap<SubjectCardDTO, SubjectCard>();
            CreateMap<SubjectCardDTO, StudyProgramSubjectCard>()
                .ForMember(dto => dto.SubjectCardId,
                           opt => opt.MapFrom(sc => sc.Id));
                //.ForMember(dto => dto.SubjectCard,
                //           opt => opt.MapFrom(sc => new SubjectCard() { 
                //                Id = sc.Id,
                //                NameInEnglish = sc.NameInEnglish
                //                //itd
                //           }));

            CreateMap<StudyProgram, StudyProgramDTO>()
                .ForMember(dto => dto.Level,
                           opt => opt.MapFrom(effect => MapLevelToString(effect.Level)))
                .ForMember(dto => dto.FieldOfStudy,
                           opt => opt.MapFrom(fos => fos.FieldOfStudy))
                .ForMember(dto => dto.Faculty,
                           opt => opt.MapFrom(fos => fos.FieldOfStudy.Faculty.Name))
                .ForMember(dto => dto.Language,
                           opt => opt.MapFrom(fos => fos.LanguageOfStudy))
                .ForMember(dto => dto.FormOfStudies,
                           opt => opt.MapFrom(fos => MapFormOfStudiesToString(fos.FormOfStudies)));

            CreateMap<StudyProgramDTO, StudyProgram>()
                .ForMember(dto => dto.FormOfStudies,
                           opt => opt.MapFrom(sp => GetFormOfStudiesEnum(sp.FormOfStudies)))
                .ForMember(sp => sp.Level,
                           dto => dto.MapFrom(sp => GetLevelEnum(sp.Level)))
                .ForMember(sp => sp.LanguageOfStudy,
                           dto => dto.MapFrom(sp => sp.Language))
                .ForMember(sp => sp.StudyProgramSubjectCards,
                           dto => dto.MapFrom(sp => sp.SubjectCards))
                .ForMember(sp => sp.FieldOfStudyId,
                           dto => dto.MapFrom(sp => sp.FieldOfStudy.Id));


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

        private string MapCourseFormToString(CourseForm courseForm)
        {
            return courseForm switch
            {
                CourseForm.Classes => "C",
                CourseForm.Laboratory => "L",
                CourseForm.Lecutre => "W",
                CourseForm.Project => "P",
                CourseForm.Seminar => "S",
                _ => "W",
            };
        }

        private CourseForm GetCourseFormEnum(string courseForm)
        {
            return courseForm switch
            {
                "C" => CourseForm.Classes,
                "L" => CourseForm.Laboratory,
                "W" => CourseForm.Lecutre,
                "P" => CourseForm.Project,
                "S" => CourseForm.Seminar,
                _ => CourseForm.Lecutre,
            };
        }
    }
}
