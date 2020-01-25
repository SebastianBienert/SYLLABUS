import Course from './Course';
import FieldOfStudy from './FieldOfStudy';
import Employee from './Employee';

export default interface SubjectCard {
    id: number;
    subjectCode: string;
    nameInPolish: string;
    nameInEnglish: string;
    specialization: string;
    level: string;
    formOfStudies: string;
    isGroupOfCourses: boolean;
    subjectType: string;
    prerequisites: string[];
    objectivties: string[];
    courses: Course[];
    supervisor: Employee; // !!! ???
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
