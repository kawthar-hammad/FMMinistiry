using Almotkaml.MFMinistry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class Department
    {
        public static Department New(string Departmentname, int branchId)
        {
            Check.NotEmpty(Departmentname, nameof(Departmentname));
            Check.MoreThanZero(branchId, nameof(branchId));

            var department = new Department()
            {
                Departmentname = Departmentname,
                BranchId = branchId,
            };


            return department;
        }
        public static Department New(string Departmentname, Branch branch)
        {
            Check.NotEmpty(Departmentname, nameof(Departmentname));
            Check.NotNull(branch, nameof(branch));

            var department = new Department()
            {
                Departmentname = Departmentname,
                Branch = branch
            };


            return department;
        }

        private Department()
        {

        }
        public int DepartmentId { get; private set; }
        public string Departmentname { get; private set; }
        public int BranchId { get; private set; }
        public Branch Branch { get; private set; }
        public void Modify(string departmentname, int branchId)
        {
            Check.NotEmpty(departmentname, nameof(departmentname));
            Check.MoreThanZero(branchId, nameof(branchId));

            Departmentname = departmentname;
            BranchId = branchId;
            Branch = null;

        }
        public void Modify(string departmentname, Branch branch)
        {
            Check.NotEmpty(departmentname, nameof(departmentname));
            Check.NotNull(Branch, nameof(branch));

            Departmentname = departmentname;
            Branch = branch;

        }
        //public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    }
}
