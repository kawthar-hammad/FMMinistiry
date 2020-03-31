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
    public class MartyrFormModel //: PersonalInfoModel
    {
        public int MartyrFormId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.FormNumber))]
        public string FormNumber { get; set; }

        public int MartyrId { get; set; }

        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.MartyrName))]
        public string MartyrName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.Department))]
        public int DepartmentId { get; set; }

        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.Department))]
        public string DepartmentName { get; set; }

        [Display(ResourceType = typeof(Title),
      Name = nameof(Title.Drawer))]
        public string DrawerName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
    ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
    Name = nameof(Title.Drawer))]
        public int DrawerId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.FinancialGroup))]
        public int FinancialGroupId { get; set; }

        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.FinancialGroup))]
        public string FinancialGroupName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.RecipientGroup))]
        public int RecipientGroupId { get; set; }

        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.RecipientGroup))]
        public string RecipientGroupName { get; set; }

     //   [Display(ResourceType = typeof(Title),
     //Name = nameof(Title.FormsStatus))]
        public FormsStatus FormsStatus { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
     ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
     Name = nameof(Title.FormsType))]
        public FormsType FormsType { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
  ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
  Name = nameof(Title.FormCategory))]
        public FormCategory FormCategory { get; set; }

        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public IEnumerable<MartyrFormGridRow> MartyrFormGrid { get; set; } = new HashSet<MartyrFormGridRow>();
        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();
        public IEnumerable<GroupListItem> GroupList { get; set; } = new HashSet<GroupListItem>();
        public IEnumerable<DrawerListItem> DrawerList { get; set; } = new HashSet<DrawerListItem>();
        public IEnumerable<FinancialGroupListItem> FinancialGroupList { get; set; } = new HashSet<FinancialGroupListItem>();

    }

    public class MartyrFormGridRow
    {
        public int MartyrFormId { get; set; }
        public string FormNumber { get; set; }
        public int MartyrId { get; set; }
        public string MartyrName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int FinancialGroupId { get; set; }
        public string FinancialGroupName { get; set; }
        public int RecipientGroupId { get; set; }
        public string RecipientGroupName { get; set; }
    }
}
