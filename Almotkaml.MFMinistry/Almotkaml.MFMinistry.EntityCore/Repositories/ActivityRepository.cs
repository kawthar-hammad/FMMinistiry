using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        private MFMinistryDbContext Context { get; }
        internal ActivityRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }


        public IEnumerable<Activity> GetUserActivities(DateTime fromDate, DateTime toDate, int userId)
        {
            var userActivity = Context.Activities
                .Include(i => i.FiredBy_User)
                .Where(u => u.ActivityDate >= fromDate && u.ActivityDate <= toDate);
            if (userId > 0)
                userActivity = userActivity.Where(u => u.FiredBy_UserId == userId);

            return userActivity;

        }
    }
}
