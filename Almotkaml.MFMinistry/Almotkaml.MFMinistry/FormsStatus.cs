using Almotkaml.MFMinistry.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry
{
    public enum FormsStatus
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Martyr))]
        Martyr = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Injuring))]
        Injuring = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Missing))]
        Missing = 3,
    }
}
