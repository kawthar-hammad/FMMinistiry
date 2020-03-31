using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        private MFMinistryDbContext Context { get; }

        internal NationalityRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Nationalities.Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Nationalities.Any(e => e.Name == name && e.NationalityId != idToExcept);

    }
}