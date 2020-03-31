using Almotkaml.MFMinistry.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry
{
    public enum FormCategory
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Father_Mother))]
        Father_Mother = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Father))]
        Father = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Mother))]
        Mother = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Son))]
        Son = 3,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Daughter))]
        Daughter = 4,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Husband))]
        Husband = 5,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Wife1))]
        Wife1 = 6,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Wife2))]
        Wife2 = 7,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Wife3))]
        Wife3 = 8,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Wife4))]
        Wife4 = 9
    }
}
