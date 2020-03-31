using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class RecipientGroup //الفئات
    {
        public static RecipientGroup New(string name, string number)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotEmpty(number, nameof(number));

            var group = new RecipientGroup()
            {
                GroupName = name,
                GroupNumber = number,
            };


            return group;
        }
        private RecipientGroup()
        {

        }
        public int RecipientGroupId { get; private set; }
        public string GroupNumber { get; private set; }
        public string GroupName { get; private set; }

        public void Modify(string name, string number)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotEmpty(number, nameof(number));

            GroupName = name;
            GroupNumber = number;


        }

        public ICollection<FormsMFM> FormsMFM { get; set; } = new HashSet<FormsMFM>();
    }
}
