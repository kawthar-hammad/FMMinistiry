using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class CountryExtensions
    {
        public static IEnumerable<CountryListItem> ToList(this IEnumerable<Country> countries)
           => countries.Select(d => new CountryListItem()
           {
               Name = d.Name,
               CountryId = d.CountryId
           });
    }
}
