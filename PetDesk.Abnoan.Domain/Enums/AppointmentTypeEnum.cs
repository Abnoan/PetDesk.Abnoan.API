using System.ComponentModel;

namespace PetDesk.Abnoan.Domain.Enums
{
    public enum AppointmentTypeEnum
    {
        [Description("Wellness")]
        Wellness,
        [Description("Surgery")]
        Surgery,
        [Description("Grooming")]
        Grooming,
        [Description("Dental")]
        Dental,
        [Description("Other")]
        Other
    }
}
