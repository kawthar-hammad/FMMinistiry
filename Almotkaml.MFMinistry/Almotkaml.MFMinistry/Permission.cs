using Almotkaml.MFMinistry.Resources;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace Almotkaml.MFMinistry
{
    public class Permission : Notify
    {

        public bool Branch { get; set; }


        public bool Nationality { get; set; }


        public bool SanctionType { get; set; }
        public bool Specialty { get; set; }
  
        public bool User { get; set; }
        public bool UserGroup { get; set; }

        public bool Bank { get; set; }
        public bool BankBranch { get; set; }
        public bool Question { get; set; }
        
        public bool City { get; set; }
        public bool Country { get; set; }

    
        public bool Setting { get; set; }

        public bool UserActivity { get; set; }

        public bool CompanyInfo { get; set; }
        public bool GrantRule { get; set; }
        public bool FinancialGroup { get; set; }
        public bool Department { get; set; }
        public bool RecipientGroup { get; set; }
        public bool Drawer { get; set; }
        public bool MartyrForm { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.BackUp))]
        public bool BackUp { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Restore))]
        public bool Restore { get; set; }


    }
    public class PermissionGR : Grants
    {
        public GrantRuleENUM Name { get; set; }

    }

}
