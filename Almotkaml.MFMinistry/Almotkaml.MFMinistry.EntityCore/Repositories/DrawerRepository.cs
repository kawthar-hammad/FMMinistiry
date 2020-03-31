using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class DrawerRepository : Repository<Drawer>, IDrawerRepository
    {
        private MFMinistryDbContext Context { get; }

        internal DrawerRepository(MFMinistryDbContext context)
            : base(context)
        {


            ////////
            Context = context;
        }

        public bool NameIsExisted(string DrawerNumber) => Context.Drawers
            .Any(e => e.DrawerNumber == DrawerNumber);

        public bool NameIsExisted(string DrawerNumber, int idToExcept) => Context.Drawers
            .Any(e => e.DrawerNumber == DrawerNumber && e.DrawerId != idToExcept);
    }
}