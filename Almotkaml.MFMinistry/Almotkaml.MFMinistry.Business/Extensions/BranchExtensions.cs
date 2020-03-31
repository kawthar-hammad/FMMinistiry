using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class BranchExtensions
    {
        public static IEnumerable<BranchListItem> ToList(this IEnumerable<Branch> branches)
         => branches.Select(d => new BranchListItem()
         {
             Name = d.Name,
             BranchId = d.BranchId
         });
    }
}
