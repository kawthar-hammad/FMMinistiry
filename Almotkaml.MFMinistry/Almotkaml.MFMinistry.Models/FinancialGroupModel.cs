using Almotkaml.MFMinistry.Resources;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Models
{
    public class FinancialGroupModel
    {
        public IEnumerable<FinancialGroupGridRow> FinancialGroupGrid { get; set; } = new HashSet<FinancialGroupGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int FinancialGroupId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.FinancialGroupNO))]
        public string FinancialGroupNO { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.FinancialGroup))]
        public string Name { get; set; }
    }

    public class FinancialGroupGridRow
    {
        public int FinancialGroupId { get; set; }
        public string FinancialGroupNO { get; set; }
        public string Name { get; set; }
    }

    public class FinancialGroupListItem
    {
        public int FinancialGroupId { get; set; }
        public string Name { get; set; }
    }

}
