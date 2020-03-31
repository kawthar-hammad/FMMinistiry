
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class BankBranchExtensions
    {
        public static IEnumerable<BankBranchListItem> ToList(this IEnumerable<BankBranch> bankBranchs)
            => bankBranchs.Select(d => new BankBranchListItem()
            {
                Name = d.Name,
                BankBranchId = d.BankBranchId,

            });

        //public static IEnumerable<BankBranchGridRow> ToGrid(this IEnumerable<BankBranch> bankBranchs, IList<IAccountingManual> accountingManuals)
        //    => bankBranchs.Select(d => new BankBranchGridRow()
        //    {
        //        BankBranchId = d.BankBranchId,
        //        BankId = d.BankId,
        //        BankName = d.Bank?.Name,
        //        Name = d.Name,
        //        AccountingManualName = accountingManuals.FirstOrDefault(a => a.AccountingManualId == d.AccountingManualId)?.Name
        //    });
        public static IEnumerable<BankBranchGridRow> ToGrid(this IEnumerable<BankBranch> bankBranchs)
            => bankBranchs.Select(d => new BankBranchGridRow()
            {
                BankBranchId = d.BankBranchId,
                BankId = d.BankId,
                BankName = d.Bank?.Name,
                Name = d.Name,
            });
    }
}