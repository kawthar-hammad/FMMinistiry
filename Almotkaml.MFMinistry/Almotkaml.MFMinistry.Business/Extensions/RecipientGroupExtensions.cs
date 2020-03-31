using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class RecipientGroupExtensions
    {
        public static IEnumerable<GroupGridRow> ToGrid(this IEnumerable<RecipientGroup> financialGroup)
           => financialGroup.Select(d => new GroupGridRow()
           {
               
           });

        public static IEnumerable<GroupListItem> ToList(this IEnumerable<RecipientGroup> financialGroup)
          => financialGroup.Select(d => new GroupListItem()
          {
              RecipientGroupId=d.RecipientGroupId,
              GroupName=d.GroupName,
          });
    }
}
