using Almotkaml.Attributes;
using Almotkaml.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class UserActivityExtensions
    {
        public static IEnumerable<UserActivityGridrow> ToGrid(this IEnumerable<Activity> inventories)
          => inventories.Select(i => new UserActivityGridrow()
          {
              ActivityDate = i.ActivityDate.ToString(),
              ActivityId = i.ActivityId,
              Type = typeof(Notify).GetAttribute<PhraseAttribute>(i.Type)?.Display,
              Title = i.FiredBy_User.UserName,
              Description=i.Description
          });
    }
}
