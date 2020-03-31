using Almotkaml.MFMinistry.Domain.DataCollectionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class DataCollection // البيانات
    {
        public string BookFamilySourceNumber { get; set; }
        public int DataCollectionId { get; set; }
        //public int FormsMFMId { get; set; }
        public FormsMFM FormsMFM { get; set; }
        //public FinancialGroup FinancialGroup { get; set; }
        //public int FinancialGroupId { get; set; }
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
        public Nationality Nationality { get; set; }
        public int? WifeNationalityId { get; set; }
        public Nationality WifeNationality { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public SocialStatus SocialStatus { get; set; }
        public int? ChildernCount { get; set; }

        public string GetFullName() => FirstName + " " + FatherName + " " + GrandfatherName + " " + LastName;

        public DataCollectionModifier Modify()
        {
            return new DataCollectionModifier(this);
        }
    }
}
