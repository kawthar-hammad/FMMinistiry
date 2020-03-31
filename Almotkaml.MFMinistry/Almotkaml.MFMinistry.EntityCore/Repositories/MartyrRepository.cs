using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class MartyrRepository : Repository<FormsMFM>, IMartyrRepository
    {
        private MFMinistryDbContext Context { get; }

        internal MartyrRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Banks
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Banks
            .Any(e => e.Name == name && e.BankId != idToExcept);

        public override IEnumerable<FormsMFM> GetAll()
        {
            return Context.FormsMFM
                .Include(d=>d.Department)
                .Include(d=>d.FinancialGroup)
                .Include(d=>d.RecipientGroup)
                .Include(d=>d.Drawer)
                .Where(e=>e.FStatus==FormsStatus.Martyr);
            
        }
    }
}