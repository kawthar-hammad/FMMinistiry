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
    public class GrantRuleModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int GrantId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
                ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
                Name = nameof(Title.GrantName))]
        public string GrantName { get; set; }
        public Grantees Grantees { get; set; }
        public IList<GrantRuleGridRow> GrantRuleGrid { get; set; } = new List<GrantRuleGridRow>();
    }

    public class GrantRuleGridRow
    {
        public int GrantRulesId { get; set; }
        public GrantRuleENUM Name { get; set; }
        public int GrantId { get; set; }
        public string GrantName { get; set; }
        public Grantees Grantees { get; set; }

    }

    public class GrantRuleFormModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Group))]
        public GrantRuleENUM Name { get; set; }
        public int GrantId { get; private set; }
        public Grantees grantees { get; set; }
        public bool CanSubmit { get; set; }
        //public Grants Grants { get; set; }
    }

    public class GrantRuleListItem
    {
        public int GrantRulesId { get; set; }
        public GrantRuleENUM Name { get; set; }

    }



}
