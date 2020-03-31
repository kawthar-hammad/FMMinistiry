using Almotkaml.MFMinistry.Domain;
using Almotkaml.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.MFMinistry.Repository
{
    public interface IActivityRepository : IRepository<Activity>
    {
        IEnumerable<Activity> GetUserActivities(DateTime fromDate, DateTime toDate, int userId);

    }
}
