import Course from './Course';

export default interface SubjectCard {
    id: number;
    nameInPolish: string;
    nameInEnglish: string;
    subjectCode: string;
    isGroupOfCourses: boolean;
    prerequisites: string[];
    objectivties: string[];
    courses: Course[];
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
