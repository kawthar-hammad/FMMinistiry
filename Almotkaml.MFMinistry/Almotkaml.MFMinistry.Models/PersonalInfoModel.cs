using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Models
{
    public class PersonalInfoModel
    {
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandfatherName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string NationalNumber { get; set; }
        public int? NationalityId { get; set; }
        public string Nationality { get; set; }
        public int? WifeNationalityId { get; set; }
        public string WifeNationality { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public SocialStatus SocialStatus { get; set; }
        public int? ChildernCount { get; set; }
    }
}
