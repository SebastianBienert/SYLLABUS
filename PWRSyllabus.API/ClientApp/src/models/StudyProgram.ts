import FieldOfStudy, { DefaultFieldOfStudy } from "./FieldOfStudy";
import SubjectCard from './SubjectCard';

export default interface StudyProgram {
    faculty: string;
    fieldOfStudy: FieldOfStudy;
    specialization: string;
    level: string;
    language: string;
    formOfStudies: string;
    subjectCards: SubjectCard[];
}

const DefaultStudyProgram: StudyProgram = {
    faculty: '',
    fieldOfStudy: DefaultFieldOfStudy,
    specialization: '',
    level: '',
    language: '',
    formOfStudies: '',
    subjectCards: []
};

export {DefaultStudyProgram, StudyProgram};
