using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private MFMinistryDbContext Context { get; }

        internal DepartmentRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Department> GetDepartmentWithBranch(int BranchId)
        {
            return Context.Departments
                .Include(d => d.Branch)
                .Where(d => d.BranchId == BranchId);
        }

        public IEnumerable<Department> GetDepartmentWithBranch()
        {
            return Context.Departments
                .Include(d => d.Branch);
        }

        public bool DepartmentExisted(string name, int BranchId) => Context.Departments
            .Any(e => e.Departmentname == name && e.BranchId == BranchId);

        public bool DepartmentExisted(string name, int BranchId, int idToExcept) => Context.Departments
            .Any(e => e.Departmentname == name && e.DepartmentId != idToExcept && e.BranchId == BranchId);


    }
}