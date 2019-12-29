﻿using Microsoft.EntityFrameworkCore;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PWRSyllabus.Infrastructure.EntityFramework
{
    public class StudyProgramRepository: IStudyProgramRepository
    {
        private readonly PWRSyllabusContext _dbContext;

        public StudyProgramRepository(PWRSyllabusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StudyProgram>> GetAllStudiesPrograms()
        {
            var studiesPrograms = await _dbContext.StudyPrograms
                .Include(me => me.StudyProgramSubjectCards)
                .Include(sp => sp.FieldOfStudy)
                .ThenInclude(fos => fos.Faculty)
                .ToListAsync();

            return studiesPrograms;
        }
    }
}