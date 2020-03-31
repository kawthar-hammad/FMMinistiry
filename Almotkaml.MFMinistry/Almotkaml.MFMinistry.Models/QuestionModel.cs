using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.MFMinistry.Resources;

namespace Almotkaml.MFMinistry.Models
{
    public class QuestionModel
    {
        public IEnumerable<QuestionGridRow> QuestionGrid { get; set; } = new HashSet<QuestionGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int QuestionId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Question))]
        public string Name { get; set; }
    }
    public class QuestionGridRow
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
    }
    public class QuestionListItem
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
    }






}