
using Almotkaml.MFMinistry;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class MartyrFormsExtensions
    {
        public static IEnumerable<MartyrFormGridRow> ToGrid(this IEnumerable<FormsMFM> departments)
           => departments.Select(d => new MartyrFormGridRow()
           {
               DepartmentId =d.DepartmentId,
               DepartmentName=d.Department?.Departmentname,
               FinancialGroupId=d.FinancialGroupId,
               FinancialGroupName=d.FinancialGroup?.Name,
               MartyrFormId=d.FormsMFMId,
               FormNumber=d.FormNumber,
               MartyrName=d.DataCollections?.GetFullName(),
               RecipientGroupId=d.RecipientGroupId,
               RecipientGroupName=d.RecipientGroup?.GroupName,
           });
       
    }
}
