interface TraceMatrix{
    rows: MatrixRow[]
}

interface MatrixRow{
    ministerialEffectCode: string,
    ministerialEffectID: number,
    ministerialEffectDescription: string,
    educationalEffectCode: string,
    educationalEffectID: number,
    educationalEffectDescription: string
}


export {TraceMatrix, MatrixRow}