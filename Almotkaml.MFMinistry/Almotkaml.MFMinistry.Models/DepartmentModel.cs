using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.MFMinistry.Resources;

namespace Almotkaml.MFMinistry.Models
{
    public class DepartmentModel
    {
        public IEnumerable<DepartmentGridRow> DepartmentGrid { get; set; } = new HashSet<DepartmentGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public int DepartmentId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.Department))]
        public string DepartmentName { get; set; }
        public IEnumerable<BranchListItem> BranchList { get; set; } = new HashSet<BranchListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Branch))]
        public int BranchId { get; set; }
     
    }
    public class DepartmentGridRow
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }    
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
    public class DepartmentListItem
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}
