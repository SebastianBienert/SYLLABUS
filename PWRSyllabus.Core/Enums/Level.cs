using EnumStringValues;

namespace PWRSyllabus.Core.Enums
{
    public enum Level
    {
        [StringValue("Inzynier")]
        St1Inzynier,
        [StringValue("Licencjat")]
        St1Licencjat,
        [StringValue("Magister")]
        St2Magister,
        [StringValue("Magister inzynier")]
        St2MagisterInzynier,
        [StringValue("Doktor")]
        St3Doktoranckie
    }
}
