import FieldOfStudy, { DefaultFieldOfStudy } from "./FieldOfStudy";
import SubjectCard from './SubjectCard';

export default interface StudyProgram {
    id: number,
    fieldOfStudy: FieldOfStudy;
    level: string;
    language: string;
    formOfStudies: string;
    subjectCards: SubjectCard[];
}

const DefaultStudyProgram: StudyProgram = {
    id: 0,
    fieldOfStudy: DefaultFieldOfStudy,
    level: '',
    language: '',
    formOfStudies: '',
    subjectCards: []
};

export {DefaultStudyProgram, StudyProgram};
