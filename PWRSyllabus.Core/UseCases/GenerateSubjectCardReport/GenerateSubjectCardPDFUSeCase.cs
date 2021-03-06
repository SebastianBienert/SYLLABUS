﻿using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using EnumStringValues;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Enums;
using PWRSyllabus.Core.Interfaces;
using PWRSyllabus.Core.Utilities;

namespace PWRSyllabus.Core.UseCases.GenerateSubjectCardReport
{
    public class GenerateSubjectCardPDFUSeCase
    {
        private readonly ISubjectCardRepository _subjectCardRepository;
        private readonly IConverter _pdfConverter;
        public GenerateSubjectCardPDFUSeCase(ISubjectCardRepository subjectCardRepository, IConverter pdfConverter)
        {
            _subjectCardRepository = subjectCardRepository;
            _pdfConverter = pdfConverter;
        }

        public async Task<SubjectCardPDF> Execute(int subjectCardId)
        {
            var subjectCard = await _subjectCardRepository.GetSubjectCardForReport(subjectCardId);
            var template = GetHTMLString(subjectCard);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Karta przedmiotu"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = template,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "pdf.css") },
            };

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var pdfBytes = _pdfConverter.Convert(document);
            var pdfReport = new SubjectCardPDF(pdfBytes, subjectCard.SubjectCode, subjectCard.Id);
            return pdfReport;
        }

        private string GetHTMLString(SubjectCard subjectCard)
        {
            var objectives = subjectCard.Objectivities.Split('|');
            var primaryLiterature = subjectCard.PrimaryLiterature.Split('|');
            var secondaryLiterature = subjectCard.SecondaryLiterature.Split('|');
            var supervisor = subjectCard.Supervisor;
            var prerequisites = subjectCard.Prerequisites.Split('|');
            var teachingTools = subjectCard.TeachingTools.Split('|');

            var educationalEffects = subjectCard.EducationalEffectSubjectCards
                .Select(sc => (educationalEffectcode: sc.EducationalEffect.Code, description: sc.Description));

            var lecture = subjectCard.Courses.FirstOrDefault(c => c.CourseForm == CourseForm.Lecture);
            var lab = subjectCard.Courses.FirstOrDefault(c => c.CourseForm == CourseForm.Laboratory);
            var seminar = subjectCard.Courses.FirstOrDefault(c => c.CourseForm == CourseForm.Seminar);
            var project = subjectCard.Courses.FirstOrDefault(c => c.CourseForm == CourseForm.Project);
            var classes = subjectCard.Courses.FirstOrDefault(c => c.CourseForm == CourseForm.Classes);

			var generatedHtml = new HTMLBuilder()
                .AddHeaderSection(subjectCard)
                .AddSpace()
                .AddMainTable(lecture, lab, seminar, classes, project, subjectCard.FinalCourseForm)
                .AddSpace()
                .AddPrerequisitesSection(prerequisites)
                .AddSpace()
                .AddProgramSection(lecture, lab, seminar, classes, project)
                .AddSpace()
                .AddCourseObjectivesSection(objectives)
                .AddSpace()
                .AddEducationalEffectsSection(educationalEffects)
                .AddSpace()
                .AddTeachingToolsSection(teachingTools)
                .AddSpace()
                .AddLiteratureSection(primaryLiterature, secondaryLiterature)
                .AddSpace()
                .AddSupervisorSection(supervisor)
                .Generate();

            return generatedHtml;
        }
    }
}
