export default interface Class {
    id: number;
    ClassNumber: number;
    Description: string;
    Hours: number;
}

const DefaultClass: Class = {
    id: 0,
    ClassNumber: 0,
    Description: "number",
    Hours: 0
};

export {DefaultClass, Class};