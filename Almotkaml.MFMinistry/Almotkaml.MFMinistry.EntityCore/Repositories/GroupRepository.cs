using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class GroupRepository : Repository<RecipientGroup>, IGroupRepository
    {
        private MFMinistryDbContext Context { get; }

        internal GroupRepository(MFMinistryDbContext context)
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