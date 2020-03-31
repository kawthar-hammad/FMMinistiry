using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class FinancialGroupRepository : Repository<FinancialGroup>, IFinancialGroupRepository
    {
        private MFMinistryDbContext Context { get; }

        internal FinancialGroupRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.FinancialGroups
         .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.FinancialGroups
            .Any(e => e.Name == name && e.FinancialGroupId != idToExcept);

    }
}