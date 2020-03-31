using Almotkaml.MFMinistry.Models;
using System;
using Almotkaml.MFMinistry.Abstraction;

namespace Almotkaml.MFMinistry.Business.App_Business.General
{
    public class HomeBusiness : Business, IHomeBusiness
    {
        public HomeBusiness(HrMFMinistry mfMinistry) : base(mfMinistry)
        {
        }

        public HomeModel View()
        {
           

            return new HomeModel()
            {
                //DeserveBouneshr = UnitOfWork.Employees.EmployeesDeserveBounshrCount(),

                //AreAbsent = UnitOfWork.Absences.AbsentEmployeesCount(DateTime.Today),
                //DeserveBounes = UnitOfWork.Employees.EmployeesDeserveBounsCount(),
                //DeserveDegree = UnitOfWork.Employees.EmployeesDeserveDegreeCount(),
                //EmployeesWithoutJobInfo = UnitOfWork.Employees.EmployeesWithoutJobInfoCount(),
                //EmployeesWithoutSalaryInfo = UnitOfWork.Employees.EmployeesWithoutSalaryInfoCount(),
                //HaveExtraWork = UnitOfWork.ExtraWorks.HaveExtraWorkCount(DateTime.Today),
                //InVacation = UnitOfWork.Vacations.EmployeesInVacationCount(DateTime.Today),
                //SuspendedSalary = UnitOfWork.Employees.EmployeesCount()
            };
        }
    }
}