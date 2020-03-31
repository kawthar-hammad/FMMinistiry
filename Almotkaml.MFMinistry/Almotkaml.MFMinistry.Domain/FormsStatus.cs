using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class FormsStatus
    {
        public static FormsStatus New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var formsStatus = new FormsStatus()
            {
                Name = name,
            };

            return formsStatus;
        }
        private FormsStatus()
        {

        }
        public int FormsStatusId { get; private set; }
        public string Name { get; private set; }
        public ICollection<FormsMFM> FormsMFM { get; } = new HashSet<FormsMFM>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;
        }
    }
}

