using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.MFMinistry.Resources;

namespace Almotkaml.MFMinistry.Models
{
    public class GroupModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int RecipientGroupId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.RecipientGroup))]
        public string GroupName { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.RecipientGroupNO))]
        public string GroupNumber { get; set; }
        public IEnumerable<GroupGridRow> GroupGrid { get; set; } = new HashSet<GroupGridRow>();
        public IEnumerable<GroupListItem> GroupList { get; set; } = new HashSet<GroupListItem>();
      
    }
    public class GroupGridRow
    {
        public int RecipientGroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }
     

    }
    public class GroupListItem
    {
        public int RecipientGroupId { get; set; }
        public string GroupName { get; set; }
    }
}