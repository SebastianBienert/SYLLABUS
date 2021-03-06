import Course from './Course';
import FieldOfStudy from './FieldOfStudy';
import {Employee, DefaultEmployee} from './Employee';
import EducationalEffect from '@/models/EducationalEffect';


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
    educationalEffects: EducationalEffect[];
    teachingTools: string[];
    primaryLiterature: string[];
    secondaryLiterature: string[];
}

const DefaultSubjectCard: SubjectCard = {
    id: 0,
    subjectCode: '',
    nameInPolish: '',
    nameInEnglish: '',
    specialization: '',
    level: '6',
    formOfStudies: '',
    isGroupOfCourses: false,
    subjectType: '',
    prerequisites: [],
    objectivities: [],
    courses: [],
    supervisor: DefaultEmployee, // !!! ???
    educationalEffects: [],
    teachingTools: [],
    primaryLiterature: [],
    secondaryLiterature: []
};

export {DefaultSubjectCard, SubjectCard};
