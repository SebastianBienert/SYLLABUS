import Course from './Course';
import FieldOfStudy from './FieldOfStudy';
import {Employee, DefaultEmployee} from './Employee';

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
    objectivities: string[];
    courses: Course[];
    supervisor: Employee; // !!! ???
    educationalEfects: string[];
    teachingTools: string[];
    literature: string[];
}

const DefaultSubjectCard: SubjectCard = {
    id: 0,
    subjectCode: '',
    nameInPolish: '',
    nameInEnglish: '',
    specialization: '',
    level: '',
    formOfStudies: '',
    isGroupOfCourses: false,
    subjectType: '',
    prerequisites: [],
    objectivities: [],
    courses: [],
    supervisor: DefaultEmployee, // !!! ???
    educationalEfects: [],
    teachingTools: [],
    literature: []
};

export {DefaultSubjectCard, SubjectCard};
