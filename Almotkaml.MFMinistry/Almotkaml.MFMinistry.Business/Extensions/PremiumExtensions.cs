using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class PremiumExtensions
    {
        public static IEnumerable<PremiumGridRow> ToGrid(this IEnumerable<Premium> premiums)
            => premiums.Select(d => new PremiumGridRow()
            {
                PremiumId = d.PremiumId,
                Name = d.Name,
                IsSubject = d.IsSubject ? "خاضعة" : "غير خاضعة",
                IsTemporary = d.IsTemporary ? "مؤقتة" : "غير مؤقتة",
                DiscountOrBoun = d.DiscountOrBoun,
                ISAdvancePremmium =d.ISAdvancePremmium
                
            });
        public static ICollection<PremiumListItem> ToList(this IEnumerable<Premium> premiums)
            => premiums.Select(d => new PremiumListItem()
            {
           
                PremiumId = d.PremiumId,
                Name = d.Name,
                ISAdvancePremmium=d.ISAdvancePremmium,
                IsTemporary = d.IsTemporary,
                IsSubject = d.IsSubject,
            }).ToList();
    }
}