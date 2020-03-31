using System.ComponentModel.DataAnnotations;
using Almotkaml.MFMinistry.Resources;

namespace Almotkaml.MFMinistry
{
    public enum Gender
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Male))]
        Male = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Female))]
        Female = 1
    }
}
