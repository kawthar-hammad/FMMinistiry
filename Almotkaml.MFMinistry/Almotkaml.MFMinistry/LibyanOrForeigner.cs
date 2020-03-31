using System.ComponentModel.DataAnnotations;
using Almotkaml.MFMinistry.Resources;

namespace Almotkaml.MFMinistry
{
    public enum LibyanOrForeigner
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Libyan))]
        Libyan = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Foreigner))]
        Foreigner = 1
    }
}