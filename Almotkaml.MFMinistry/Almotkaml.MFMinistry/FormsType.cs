using Almotkaml.MFMinistry.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry
{
    public enum FormsType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Single))]
        Single = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Marrid))]
        Marrid = 2,
       

    }
}
