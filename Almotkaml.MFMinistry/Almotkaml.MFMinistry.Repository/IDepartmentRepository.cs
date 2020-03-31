using Almotkaml.MFMinistry.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.MFMinistry.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> GetDepartmentWithBranch(int BranchId);
        IEnumerable<Department> GetDepartmentWithBranch();
        bool DepartmentExisted(string name, int BranchId);
        bool DepartmentExisted(string name, int BranchId, int idToExcept);
    }
}