export default interface MinisterialEffect {
    id: number;
    code: string;
    discipline: string;
    category: string;
    descriptiveCategory: string;
    level: string;
    description: string;
}

const DefaultMinisterialEffect: MinisterialEffect = {
    id: 0,
    code : '',
    discipline : '',
    category: '',
    description: '',
    descriptiveCategory: '',
    level: '',
};

export {DefaultMinisterialEffect, MinisterialEffect};
