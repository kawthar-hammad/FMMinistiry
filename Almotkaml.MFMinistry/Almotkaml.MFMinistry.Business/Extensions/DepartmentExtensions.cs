
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DepartmentExtensions
    {
        public static IEnumerable<DepartmentGridRow> ToGrid(this IEnumerable<Department> departments)
           => departments.Select(d => new DepartmentGridRow()
           {
               DepartmentName = d. Departmentname,
               DepartmentId = d.DepartmentId,
               BranchName = d.Branch?.Name,
               BranchId = d.BranchId,

           });
        public static IEnumerable<DepartmentListItem> ToList(this IEnumerable<Department> departments)
           => departments.Select(d => new DepartmentListItem()
           {
               DepartmentName = d.Departmentname,
               DepartmentId = d.DepartmentId,
           });
    }
}
