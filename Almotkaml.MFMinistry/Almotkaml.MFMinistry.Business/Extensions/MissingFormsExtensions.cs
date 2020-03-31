using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class MissingFormsExtensions
    {
        public static IEnumerable<MissingFormGridRow> ToMissingGrid(this IEnumerable<FormsMFM> FormsMF)
           => FormsMF.Select(d => new MissingFormGridRow()
           {
               DepartmentId = d.DepartmentId,
               DepartmentName = d.Department?.Departmentname,
               FinancialGroupId = d.FinancialGroupId,
               FinancialGroupName = d.FinancialGroup?.Name,
               MissingFormId = d.FormsMFMId,
               FormNumber = d.FormNumber,
               MissingName = d.DataCollections?.GetFullName(),
               RecipientGroupId = d.RecipientGroupId,
               RecipientGroupName = d.RecipientGroup?.GroupName,
           });

    }
}
