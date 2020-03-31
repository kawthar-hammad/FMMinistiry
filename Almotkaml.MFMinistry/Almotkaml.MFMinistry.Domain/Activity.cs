using System;
using System.Collections.Generic;

namespace Almotkaml.MFMinistry.Domain
{
    public class Activity
    {
        public static Activity New(int userId, string activityType, DateTime activityDate, string description)
        {
            Check.MoreThanZero(userId, nameof(userId));
            Check.NotEmpty(activityType, nameof(activityType));

            var activtiy = new Activity()
            {
                FiredBy_UserId = userId,
                Type = activityType,
                ActivityDate = activityDate,
                Description = description

            };

            // not completed ...
            return activtiy;
        }

        public static Activity New(User user, string activityType, DateTime activityDate,string description)
        {
            Check.NotNull(user, nameof(user));
            Check.NotEmpty(activityType, nameof(activityType));

            var activtiy = new Activity()
            {
                FiredBy_User = user,
                FiredBy_UserId = user.UserId,
                Type = activityType,
                ActivityDate=activityDate,
                Description= description
            };

            return activtiy;
        }

        private Activity() { }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public long ActivityId { get; private set; }
        public DateTime ActivityDate { get; private set; } = DateTime.Now;
        public int FiredBy_UserId { get; private set; }
        public User FiredBy_User { get; private set; }
        public string Type { get; private set; }
        public string Description { get; set; }

        public ICollection<Notification> Notifications { get; } = new HashSet<Notification>();
    }
}
