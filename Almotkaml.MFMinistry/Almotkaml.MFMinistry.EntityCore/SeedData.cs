using Almotkaml.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.EntityCore.Resource;
using Almotkaml.MFMinistry.Resources;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore
{
    internal static class SeedData
    {
        private static MFMinistryDbContext Context { get; set; }
        public static void Load(MFMinistryDbContext context)
        {
            Context = context;
            SeedUserWithGroups();
         
        }

        private static void SeedUserWithGroups()
        {
            if (Context.Users.Any())
                return;

            var stringPermission = new Permission().ToSerializedObject().Replace("false", "true");

            var fullPermission = stringPermission.ToDeserializedObject<Permission>();

            var userGroup = ObjectCreator.Create<UserGroup>(typeof(UserGroup));
            userGroup.SetValue(g => g.Name, "Administrator");
            userGroup.SetValue(g => g.Permissions, fullPermission);

            var stringNotifications = new Notify().ToSerializedObject().Replace("false", "true");

            var fullNotifications = stringNotifications.ToDeserializedObject<Notify>();

            var user = ObjectCreator.Create<User>(typeof(User));
            user.SetValue(g => g.UserGroup, userGroup);
            user.SetValue(g => g.Notify, fullNotifications);
            user.SetValue(g => g.Password, "!QA2ws3ed");
            user.SetValue(g => g.Title, "Almotkaml");
            user.SetValue(g => g.UserName, "Admin");

            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}