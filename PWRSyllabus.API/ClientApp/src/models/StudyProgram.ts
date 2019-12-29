export default interface StudyProgram {
    faculty: string;
    fieldOfStudy: string;
    specialization: string;
    level: string;
    language: string;
    formOfStudies: string;
}

const DefaultStudyProgram: StudyProgram = {
    faculty: '',
    fieldOfStudy: '',
    specialization: '',
    level: '',
    language: '',
    formOfStudies: ''
};