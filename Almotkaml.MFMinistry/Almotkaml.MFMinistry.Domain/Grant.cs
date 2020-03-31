using System.Collections.Generic;

namespace Almotkaml.MFMinistry.Domain
{
    public class Grant
    {
        public static Grant New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var grant = new Grant()
            {
                Name = name,
            };


            return grant;
        }

        private Grant()
        {

        }
        public int GrantId { get; private set; }
        public string Name { get; private set; }

        public ICollection<GrantRule> GrantRules { get; } = new HashSet<GrantRule>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }

    }
}