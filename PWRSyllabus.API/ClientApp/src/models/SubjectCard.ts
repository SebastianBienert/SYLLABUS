export default interface SubjectCard {
    nameInPolish: string;
    nameInEnglish: string;
    subjectCode: string;
    isGroupOfCourses: boolean;
    prerequisites: string[];
    objectivties: string[];
}
