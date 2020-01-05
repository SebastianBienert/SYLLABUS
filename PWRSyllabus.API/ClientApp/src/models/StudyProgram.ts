import FieldOfStudy, { DefaultFieldOfStudy } from "./FieldOfStudy";

export default interface StudyProgram {
    faculty: string;
    fieldOfStudy: FieldOfStudy;
    specialization: string;
    level: string;
    language: string;
    formOfStudies: string;
}

const DefaultStudyProgram: StudyProgram = {
    faculty: '',
    fieldOfStudy: DefaultFieldOfStudy,
    specialization: '',
    level: '',
    language: '',
    formOfStudies: ''
};