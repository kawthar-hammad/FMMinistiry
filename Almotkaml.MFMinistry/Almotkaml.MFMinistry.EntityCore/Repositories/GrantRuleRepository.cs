using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using Almotkaml.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories

{
    public class GrantRuleRepository : Repository<GrantRule>, IGrantRuleRepository
    {
        private MFMinistryDbContext Context { get; }

        internal GrantRuleRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }
        public override IEnumerable<GrantRule> GetAll() => Context.GrantRules.Include(g => g.Grant)
           .Select(g => GrantRule.Existed(g.GrantRuleId, g.GrantId,
               EF.Property<string>(g,
                   Column(nameof(GrantRule.grantees))).ToDeserializedObject<Grantees>(),g.Grant));

        public override GrantRule Find(object id)
        {
            var grantRule = Context.GrantRules
                .AsNoTracking()
                .Select(g => GrantRule.Existed(g.GrantRuleId, g.GrantId,
                    EF.Property<string>(g,
                        Column(nameof(GrantRule.grantees))).ToDeserializedObject<Grantees>(), g.Grant))
                .FirstOrDefault(g => g.GrantRuleId == (int)id);

            if (grantRule == null)
                return null;

            var grantRuleEntries = Context.ChangeTracker.Entries<GrantRule>().ToList();

            foreach (var entityEntry in grantRuleEntries)
            {
                entityEntry.State = EntityState.Detached;
            }

            Context.Attach(grantRule);

            return grantRule;

        }
      
    }
}
