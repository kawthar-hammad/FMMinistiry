using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private MFMinistryDbContext Context { get; }

        internal CountryRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Countries
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Countries
            .Any(e => e.Name == name && e.CountryId != idToExcept);
    }
}