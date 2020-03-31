using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.MFMinistry.Resources;

namespace Almotkaml.MFMinistry.Models
{
    public class DrawerModel
    {
        public IEnumerable<DrawerGridRow> DrawerGrid { get; set; } = new HashSet<DrawerGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int DrawerId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Drawer))]
        public string DrawerNumber { get; set; }
    }
    public class DrawerGridRow
    {
        public int DrawerId { get; set; }
        public string DrawerNumber { get; set; }
    }
    public class DrawerListItem
    {
        public int DrawerId { get; set; }
        public string DrawerNumber { get; set; }
    }
}
