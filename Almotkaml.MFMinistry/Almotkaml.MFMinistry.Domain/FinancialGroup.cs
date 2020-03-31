using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class FinancialGroup
    {
        public static FinancialGroup New(string name, string number)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotEmpty(number, nameof(number));

            var financialGroup = new FinancialGroup()
            {
                Name = name,
                Number = number,
            };


            return financialGroup;
        }
     
        private FinancialGroup()
        {

        }
        public int FinancialGroupId { get; private set; }
        public string Name { get; private set; }
        public string Number { get; private set; }
   
        public void Modify(string name, string number)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotEmpty(number, nameof(number));

            Name = name;
            Number = number;
        

        }
        public ICollection<DataCollection> DataCollections { get; set; } = new HashSet<DataCollection>();
        public ICollection<FormsMFM> FormsMFM { get; set; } = new HashSet<FormsMFM>();
    }
}
