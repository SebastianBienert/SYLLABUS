export default interface Employee {
    id: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
}

const DefaultEmployee: Employee = {
    id: 0,
    firstName: 'Jerzy',
    lastName: 'Pietruszko',
    emailAddress: 'jerzy.pietruszko@pwr.edu.pl',
};

export {Employee, DefaultEmployee};