using PWRSyllabus.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PWRSyllabus.Core.Interfaces
{
    public interface IStudyProgramRepository
    {
        Task<IEnumerable<StudyProgram>> GetAllStudiesPrograms();
        Task<StudyProgram> GetStudyProgram(int studyProgramId);
        Task<IEnumerable<StudyProgram>> SearchStudyPrograms(string query, int pageSize, int pageNumber);
    }
}
    