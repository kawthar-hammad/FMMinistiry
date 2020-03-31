using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;


namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class GrantRuleExtensions
    {
        public static IEnumerable<GrantRuleListItem> ToList(this IEnumerable<GrantRule> grantRules)
            => grantRules.Select(u => new GrantRuleListItem()
            {
                //Name = u.Name,
                GrantRulesId = u.GrantRuleId
            });

        public static List<GrantRuleGridRow> ToGrid(this IEnumerable<GrantRule> grantRules)
            => grantRules.Select(u => new GrantRuleGridRow()
            {
                GrantName = u.Grant?.Name,
                GrantRulesId = u.GrantRuleId,
                Grantees = u.grantees,
                GrantId = u.GrantId,
            }).ToList();
    }
}