using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SalaryExtensions
    {
        public static IEnumerable<SalaryGridRow> ToGridSerch(this IEnumerable<Salary> salaries, ISettings settings)
          => salaries.Select(d => new SalaryGridRow()
          {
              EmloyeeId = d.EmployeeId,

              MonthGrid = d.MonthDate.Month,
              YearGrid = d.MonthDate.Year,

              EmployeeName = d.Employee?.GetFullName(),
              BasicSalary = d.BasicSalary,
              FinalSalary = d.FinalSalary(settings),
              JobNumber = d.Employee?.JobInfo?.GetJobNumber(),
              MonthDate = d.MonthDate.FormatToString(),
              BankId = d.BankBranch.BankId


          }).ToList()
           ;
        public static IEnumerable<SalaryGridRow> ToGrid(this IEnumerable<Salary> salaries, ISettings settings)
            => salaries.Select(d => new SalaryGridRow()
            {
                SalaryId = d.SalaryId,
                EmployeeName = d.Employee?.GetFullName(),
                BasicSalary = d.BasicSalary,
                FinalSalary = d.NetSalary(settings),
                TotalSalary = d.TotalSalary(settings),
                IsSuspended = d.IsSuspended,
                SuspendedNote = d.SuspendedNote,
                JobNumber = d.Employee?.JobInfo?.GetJobNumber(),
                MonthDate = d.MonthDate.FormatToString(),
                TotalDiscount = d.GetBasicSalary(),
            });
        public static IEnumerable<TemporaryPremiumGridRow> ToGrid(this IEnumerable<TemporaryPremium> temporaryPremium)
            => temporaryPremium.Select(d => new TemporaryPremiumGridRow()
            {
                IsSubject = d.IsSubject,
                Name = d.Name,
                SalaryId = d.SalaryId,
                TemporaryPremiumId = d.TemporaryPremiumId,
                Value = d.Value
            });
        public static IList<SalaryPremiumListItem> ToList(this IEnumerable<SalaryPremium> premiums)
        => premiums.Select(d => new SalaryPremiumListItem()
        {
            PremiumId = d.PremiumId,
            Value = d.Value
        }).ToList();

    }
}