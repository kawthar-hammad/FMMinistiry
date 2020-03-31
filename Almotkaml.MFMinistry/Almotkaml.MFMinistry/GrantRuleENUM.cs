using System.ComponentModel.DataAnnotations;
using Almotkaml.MFMinistry.Resources;

namespace Almotkaml.MFMinistry
{
    public enum GrantRuleENUM
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.healthy))]
        healthy = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.social))]
        social = 1 ,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.educational))]
        educational = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.material))]
        material = 3






    }
}
