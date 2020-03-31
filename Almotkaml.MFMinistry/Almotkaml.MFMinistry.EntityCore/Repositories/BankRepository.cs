using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        private MFMinistryDbContext Context { get; }

        internal BankRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Banks
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Banks
            .Any(e => e.Name == name && e.BankId != idToExcept);
    }
}