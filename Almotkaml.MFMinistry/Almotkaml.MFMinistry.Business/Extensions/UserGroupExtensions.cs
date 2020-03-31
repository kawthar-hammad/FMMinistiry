using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class UserGroupExtensions
    {
        public static IEnumerable<UserGroupListItem> ToList(this IEnumerable<UserGroup> usersGroups)
            => usersGroups.Select(u => new UserGroupListItem()
            {
                Name = u.Name,
                UserGroupId = u.UserGroupId
            });

        public static IEnumerable<UserGroupGridRow> ToGrid(this IEnumerable<UserGroup> usersGroups)
            => usersGroups.Select(u => new UserGroupGridRow()
            {
                Name = u.Name,
                UserGroupId = u.UserGroupId
            });
    }
}