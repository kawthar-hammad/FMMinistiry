using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using Almotkaml.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories

{
    public class GrantRepository : Repository<Grant>, IGrantRepository
    {
        private MFMinistryDbContext Context { get; }

        internal GrantRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }
        //public override IEnumerable<GrantRule> GetAll() => Context.GrantRules
        //   .Select(g => GrantRule.Existed(g.GrantRuleId, g.GrantId,
        //       EF.Property<string>(g,
        //           Column(nameof(GrantRule.grantees))).ToDeserializedObject<Grantees>()));

        //public override GrantRule Find(object id)
        //{
        //    var grantRule = Context.GrantRules
        //        .AsNoTracking()
        //        .Select(g => GrantRule.Existed(g.GrantRuleId, g.GrantId,
        //            EF.Property<string>(g,
        //                Column(nameof(GrantRule.grantees))).ToDeserializedObject<Grantees>()))
        //        .FirstOrDefault(g => g.GrantRuleId == (int)id);

        //    if (grantRule == null)
        //        return null;

        //    var grantRuleEntries = Context.ChangeTracker.Entries<GrantRule>().ToList();

        //    foreach (var entityEntry in grantRuleEntries)
        //    {
        //        entityEntry.State = EntityState.Detached;
        //    }

        //    Context.Attach(grantRule);

        //    return grantRule;

        //}

    }
}
