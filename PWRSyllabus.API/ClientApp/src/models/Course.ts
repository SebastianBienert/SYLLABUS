import Class from './Class';

export default interface Course {
    id: number;
    ECTS: number;
    ZZU: number;
    CNPS: number;
    CourseForm: string;
    FormOfCrediting: string;
    Classes: Class[];
    isSelected: boolean; // I need it, okay? no matter the cost
}

const DefaultCourse: Course = {
    id: 0,
    ECTS: 0,
    ZZU: 0,
    CNPS: 0,
    CourseForm: "",
    FormOfCrediting: "",
    Classes: [],
    isSelected: false
};

export {DefaultCourse, Course};