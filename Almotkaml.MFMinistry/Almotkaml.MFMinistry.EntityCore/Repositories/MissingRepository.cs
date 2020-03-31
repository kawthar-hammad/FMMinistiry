using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class MissingRepository : Repository<FormsMFM>, IMissingRepository
    {
        private MFMinistryDbContext Context { get; }

        internal MissingRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string formNumber) => Context.FormsMFM
            .Any(e => e.FormNumber == formNumber);

        public bool NameIsExisted(string formNumber, int idToExcept) => Context.FormsMFM
            .Any(e => e.FormNumber == formNumber && e.FormsMFMId != idToExcept);

        public override IEnumerable<FormsMFM> GetAll()
        {
            return Context.FormsMFM
                .Include(d=>d.Department)
                .Include(d=>d.FinancialGroup)
                .Include(d=>d.RecipientGroup)
                .Include(d=>d.Drawer)
                .Where(e=>e.FStatus==FormsStatus.Missing);
            
        }
    }
}