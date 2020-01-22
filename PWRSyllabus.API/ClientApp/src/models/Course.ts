export default interface Course {
    id: number;
    ECTS: number;
    ZZU: number;
    CNPS: number;
    CourseForm: string;
}

const DefaultCourse: Course = {
    id: 0,
    ECTS: 0,
    ZZU: 0,
    CNPS: 0,
    CourseForm: ""
};

export {DefaultCourse, Course};