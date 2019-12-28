export default interface MinisterialEffect {
    code: string;
    discipline: string;
    category: string;
    descriptiveCategory: string;
    level: string;
    description: string;
}

const DefaultMinisterialEffect: MinisterialEffect = {
    code : '',
    discipline : '',
    category: '',
    description: '',
    descriptiveCategory: '',
    level: '',
};

export {DefaultMinisterialEffect, MinisterialEffect};
