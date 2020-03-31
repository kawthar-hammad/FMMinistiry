using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class FinancialGroupExtensions
    {
        public static IEnumerable<FinancialGroupGridRow> ToGrid(this IEnumerable<FinancialGroup> financialGroup)
           => financialGroup.Select(d => new FinancialGroupGridRow()
           {
               FinancialGroupId=d.FinancialGroupId,
               Name=d.Name,
               FinancialGroupNO=d.Number,
           });

        public static IEnumerable<FinancialGroupListItem> ToList(this IEnumerable<FinancialGroup> financialGroup)
          => financialGroup.Select(d => new FinancialGroupListItem()
          {
              FinancialGroupId = d.FinancialGroupId,
              Name = d.Name,
          });
    }
}
