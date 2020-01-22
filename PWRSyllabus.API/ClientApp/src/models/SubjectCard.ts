import Course from './Course';
import FieldOfStudy from './FieldOfStudy';

export default interface SubjectCard {
    id: number;
    nameInPolish: string;
    nameInEnglish: string;
    subjectCode: string;
    fieldOfStudy: FieldOfStudy;
    specialization: string;
    level: string;
    formOfStudies: string;
    isGroupOfCourses: boolean;
    subjectType: string;
    prerequisites: string[];
    objectivties: string[];
    courses: Course[];
    supervisor: string; // !!! ???
}

const DefaultSubjectCard: SubjectCard = {
    id: 0,
    nameInPolish: '',
    nameInEnglish: '',
    subjectCode: '',
    isGroupOfCourses: false,
    prerequisites: [],
    objectivties: [],
    courses: []
};

export {DefaultSubjectCard, SubjectCard};
