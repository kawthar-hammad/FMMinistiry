using System.Collections.Generic;

namespace Almotkaml.MFMinistry.Domain
{
    public class Branch
    {
        public static Branch New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var branch = new Branch()
            {
                Name = name,
            };


            return branch;
        }

        private Branch()
        {

        }
        public int BranchId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Department> Departments { get; } = new HashSet<Department>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }

    }
}