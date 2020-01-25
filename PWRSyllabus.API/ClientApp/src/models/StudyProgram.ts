import FieldOfStudy, { DefaultFieldOfStudy } from "./FieldOfStudy";
import SubjectCard from './SubjectCard';

export default interface StudyProgram {
    fieldOfStudy: FieldOfStudy;
    level: string;
    language: string;
    formOfStudies: string;
    subjectCards: SubjectCard[];
}

const DefaultStudyProgram: StudyProgram = {
    fieldOfStudy: DefaultFieldOfStudy,
    level: '',
    language: '',
    formOfStudies: '',
    subjectCards: []
};

export {DefaultStudyProgram, StudyProgram};
