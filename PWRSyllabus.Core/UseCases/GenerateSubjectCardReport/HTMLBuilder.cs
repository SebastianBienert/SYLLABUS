using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnumStringValues;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Enums;
using PWRSyllabus.Core.Utilities;

namespace PWRSyllabus.Core.UseCases.GenerateSubjectCardReport
{
    public class HTMLBuilder
    {
        private readonly StringBuilder _sb;

        public HTMLBuilder()
        {
            _sb = new StringBuilder();
            _sb.Append($@"
                        <html>
                            <head>
                            </head>
                            <body>");
        }

        public HTMLBuilder AddHeaderSection(SubjectCard subjectCard)
        {
            var studyProgram = subjectCard.StudyProgramSubjectCards
                .Select(x => x.StudyProgram)
                .FirstOrDefault();
            var fieldOfStudy = studyProgram?.FieldOfStudy;
			var headerSection = $@"<div class='upper'>
			                        <h1>Karta przedmiotu</h1>
			                        <table>
				                        <tr>
					                        <td>Nazwa w jezyku polskim</td>
					                        <td>{subjectCard.NameInPolish}</td>
				                          </tr>
				                        <tr>
					                        <td>Nazwa w jezyku angielskim</td>
					                        <td>{subjectCard.NameInEnglish}</td>
				                        </tr>
				                        <tr>
					                        <td>Kierunek studiów (jeśli dotyczy)</td>
					                        <td>{fieldOfStudy?.Name ?? ""}</td>
				                        </tr>
				                        <tr>
					                        <td>Specjalność</td>
					                        <td>{fieldOfStudy?.Specialization ?? ""}</td>
				                        </tr>
				                        <tr>
					                        <td>Stopien studiów i forma</td>
					                        <td>{studyProgram?.FormOfStudies.GetStringValue()}, {studyProgram?.Level.GetStringValue()}</td>
				                        </tr>
				                        <tr>
					                        <td>Kod przedmiotu</td>
					                        <td>{subjectCard.SubjectCode}</td>
				                        </tr>
				                        <tr>
					                        <td>Grupa kursów</td>
					                        <td>{(subjectCard.IsGroupOfCourses ? "Tak" : "Nie")}</td>
				                        </tr>
			                        </table>			
		                        </div>";
            _sb.Append(headerSection);
            return this;
        }

        private HTMLBuilder AddCourseProgram(Course course)
        {
            var courseForm = course.CourseForm.GetStringValue();
            var classes = course.Classes;
            _sb.Append($@"<table>
				            <thead>
					            <tr>
						            <th colspan='2'>Forma zajęć - {courseForm}</th>
						            <th>Liczba godzin</th> 
					            </tr>
				            </thead>
                                <tbody>");
            foreach (var (@class, index) in classes.WithIndex())
            {
                _sb.Append($@"<tr>
						        <td>{courseForm.Substring(0, 2)}{@class.ClassNumber}</td>
						        <td>{@class.Description} 
							        </td>
						        <td>{@class.Hours}</td>
					        </tr>");
            }
            _sb.Append($@"<tr>
						        <td></td>
						        <td>Suma godzin</td>
						        <td>{classes.Sum(c => c.Hours)}</td>
					        </tr>");

			_sb.Append(@"</tbody>
                       	    </table>");
            return this;
        }

        public HTMLBuilder AddProgramSection(
            Course lecture,
            Course laboratory,
            Course seminar,
            Course classes,
            Course project
            )
        {
            _sb.Append($@"<div class='border'>
			                <h3>Treści programowe</h3>");

            if (lecture != null)
                this.AddCourseProgram(lecture);
            if (laboratory != null)
                this.AddCourseProgram(laboratory);
            if (seminar != null)
                this.AddCourseProgram(seminar);
            if (classes != null)
                this.AddCourseProgram(classes);
            if (project != null)
                this.AddCourseProgram(project);

			_sb.Append("</div>");
            return this;
        }

		public HTMLBuilder AddSpace()
		{
            _sb.Append("</br>");
			return this;
		}

        public HTMLBuilder AddMainTable(
			Course lecture,
            Course laboratory,
            Course seminar,
            Course classes,
            Course project,
			CourseForm? finalCourseForm
            )
        {
			
            var table = $@"<table class='second'>
			                <thead>
				                <tr>
					                <th></th>
					                <th>Wykład</th>
					                <th>Ćwiczenia</th> 
					                <th>Laboratorium</th>
					                <th>Projekt</th>
					                <th>Seminarium</th>
				                </tr>
			                </thead>
			                <tbody>
				                <tr>
					                <td>Liczba godzin zajęć zorganizowanych w Uczelni (ZZU)</td>
					                <td>{(lecture == null ? "" : lecture.ZZU.ToString())}</td>
					                <td>{(classes == null ? "" : classes.ZZU.ToString())}</td>
					                <td>{(laboratory == null ? "" : laboratory.ZZU.ToString())}</td>
					                <td>{(project == null ? "" : project.ZZU.ToString())}</td>
					                <td>{(seminar == null ? "" : seminar.ZZU.ToString())}</td>
				                </tr>
				                  <tr>
					                <td>Liczba godzin całkowitego nakładu pracy studenta (CNPS)</td>
					                <td>{(lecture == null ? "" : lecture.CNPS.ToString())}</td>
					                <td>{(classes == null ? "" : classes.CNPS.ToString())}</td>
					                <td>{(laboratory == null ? "" : laboratory.CNPS.ToString())}</td>
					                <td>{(project == null ? "" : project.CNPS.ToString())}</td>
					                <td>{(seminar == null ? "" : seminar.CNPS.ToString())}</td>
				                  </tr>
				                  <tr>
					                <td>Forma zaliczenia</td>
					                <td>{(lecture == null ? "" : lecture.FormOfCrediting)}</td>
					                <td>{(classes == null ? "" : classes.FormOfCrediting)}</td>
					                <td>{(laboratory == null ? "" : laboratory.FormOfCrediting)}</td>
					                <td>{(project == null ? "" : project.FormOfCrediting)}</td>
					                <td>{(seminar == null ? "" : seminar.FormOfCrediting)}</td>
				                  </tr>
				                  <tr>
					                <td>Dla grupy kursów zaznaczyć kurs końcowy</td>
					                <td>{(finalCourseForm == lecture?.CourseForm ? "X" : "")}</td>
					                <td>{(finalCourseForm == classes?.CourseForm ? "X" : "")}</td>
					                <td>{(finalCourseForm == laboratory?.CourseForm ? "X" : "")}</td>
					                <td>{(finalCourseForm == project?.CourseForm ? "X" : "")}</td>
					                <td>{(finalCourseForm == seminar?.CourseForm ? "X" : "")}</td>
				                  </tr>
				                  <tr>
					                <td>Liczba punktów ECTS</td>
					                <td>{(lecture == null ? "" : lecture.ECTS.ToString())}</td>
					                <td>{(classes == null ? "" : classes.ECTS.ToString())}</td>
					                <td>{(laboratory == null ? "" : laboratory.ECTS.ToString())}</td>
					                <td>{(project == null ? "" : project.ECTS.ToString())}</td>
					                <td>{(seminar == null ? "" : seminar.ECTS.ToString())}</td>
				                  </tr>
				                  <tr>
					                <td>w tym liczba punktów odpowiadająca zajęciom o charakterze pratkycznym (P)</td>
					                <td>{(lecture == null ? "" : lecture.ECTSForPracticalClassees.ToString())}</td>
					                <td>{(classes == null ? "" : classes.ECTSForPracticalClassees.ToString())}</td>
					                <td>{(laboratory == null ? "" : laboratory.ECTSForPracticalClassees.ToString())}</td>
					                <td>{(project == null ? "" : project.ECTSForPracticalClassees.ToString())}</td>
					                <td>{(seminar == null ? "" : seminar.ECTSForPracticalClassees.ToString())}</td>
				                  </tr>
				                  <tr>
					                <td>w tym liczba punktów odpowiadająca zajęciom wymagającym bezpośrednioego kontaktu (BK)</td>
					                <td>{(lecture == null ? "" : lecture.ECTSForTeacherStudentContact.ToString())}</td>
					                <td>{(classes == null ? "" : classes.ECTSForTeacherStudentContact.ToString())}</td>
					                <td>{(laboratory == null ? "" : laboratory.ECTSForTeacherStudentContact.ToString())}</td>
					                <td>{(project == null ? "" : project.ECTSForTeacherStudentContact.ToString())}</td>
					                <td>{(seminar == null ? "" : seminar.ECTSForTeacherStudentContact.ToString())}</td>
				                  </tr>
			                </tbody>
		                </table>";

            _sb.Append(table);
            return this;
        }

        public HTMLBuilder AddCourseObjectivesSection(IEnumerable<string> objectives)
        {
            _sb.Append($@"<div class='border'>
			                <h3>Cele przedmiotu</h3>");

            foreach (var (obj, index) in objectives.WithIndex())
            {
                _sb.Append($@"<p>C{index + 1} {obj}</p>");
            }

            _sb.Append("</div>");
            return this;
        }

		public HTMLBuilder AddLiteratureSection(string[] primaryLietrature, string[] secondaryLiterature)
		{
            _sb.Append($@"
		        <div class='border'>
			        <h3>Literatura podstawowa i uzupelniająca</h3>");

            if (primaryLietrature != null && primaryLietrature.Any())
            {
                _sb.Append("<h4>Literatura podstawowa</h4>");
                foreach (var (literature, index) in primaryLietrature.WithIndex())
                {
                    _sb.Append($"<p>[{index + 1}] {literature}</p>");
                }
            }

            if (secondaryLiterature != null && secondaryLiterature.Any())
            {
                _sb.Append("<h4>Literatura uzupelniajaca</h4>");
                foreach (var (literature, index) in secondaryLiterature.WithIndex())
                {
                    _sb.Append($"<p>[{index + 1}] {literature}</p>");
                }
            }

            _sb.Append("</div>");
            return this;
        }

        public HTMLBuilder AddSupervisorSection(Employee supervisor)
        {
            _sb.Append($@"<div class='border'>
			        <h3>Opiekun przedmiotu (imie, nazwisko, adres e-mail)</h3>
			        <p>{supervisor.FirstName} {supervisor.LastName} {supervisor.EmailAddress}</p>			
		        </div>");

            return this;
        }

        public HTMLBuilder AddPrerequisitesSection(IEnumerable<string> prerequisites)
        {
			_sb.Append($@"<div class='border'>
			                <h3>WYMAGANIA WSTĘPNE W ZAKRESIE WIEDZY, UMIEJĘTNOŚCI I INNYCH KOMPETENCJI</h3>");

            foreach (var (prerequisite, index) in prerequisites.WithIndex())
            {
                _sb.Append($@"<p>{index + 1}. {prerequisite}</p>");
            }

            _sb.Append("</div>");
            return this;
		}

        public HTMLBuilder AddEducationalEffectsSection(IEnumerable<(string educationalEffect, string description)> effects)
        {
            _sb.Append($@"<div class='border'>
			                <h3>EFEKTY KSZTAŁCENIA DLA PRZEDMIOTU</h3>");

            foreach (var effect in effects)
            {
                _sb.Append($@"<p>{effect.educationalEffect} - {effect.description}</p>");
            }

            _sb.Append("</div>");
            return this;
        }

		public string Generate()
        {
            _sb.Append(@"
                            </body>
                        </html>");
            var html = _sb.ToString();
            return html;
        }

        
    }
}
