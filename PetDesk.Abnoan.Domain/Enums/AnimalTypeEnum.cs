using System.ComponentModel;

namespace PetDesk.Abnoan.Domain.Enums
{
    public enum AnimalTypeEnum
    {
        [Description("Dog")]
        Dog,
        [Description("Cat")]
        Cat,
        [Description("Bird")]
        Bird,
        [Description("Other")]
        Other
    }
}
