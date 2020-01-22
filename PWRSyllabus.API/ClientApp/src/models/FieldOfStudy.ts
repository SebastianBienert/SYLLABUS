export default interface FieldOfStudy {
    id: number;
    name: string;
    specialization: string;
    faculty: string;
}

const DefaultFieldOfStudy: FieldOfStudy = {
    id: 0,
    name: '',
    specialization: '',
    faculty: '',
};

export {DefaultFieldOfStudy, FieldOfStudy};
