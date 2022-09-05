using System.ComponentModel;

namespace PetDesk.Abnoan.Domain.Enums
{
    public enum AppointmentType
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
