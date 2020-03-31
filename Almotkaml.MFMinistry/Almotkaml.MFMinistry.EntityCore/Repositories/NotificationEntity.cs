using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        internal NotificationRepository(MFMinistryDbContext context)
            : base(context)
        {
        }
    }
}
