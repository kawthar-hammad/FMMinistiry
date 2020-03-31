using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.EntityCore.Repositories;
using Almotkaml.MFMinistry.Repository;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private MFMinistryDbContext Context { get; }

        internal BranchRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Branches
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Branches
            .Any(e => e.Name == name && e.BranchId != idToExcept);
    }
}