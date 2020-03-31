using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SalaryInfoBusiness : Business, ISalaryInfoBusiness
    {
        public SalaryInfoBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        protected bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.SalaryInfo && permission;

        public SalaryInfoIndexModel Index()
        {
            if (!HavePermission())
                return Null<SalaryInfoIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Employees.GetAll().ToGridEmployee().Where(s=>s.Active==true).ToArray();

            return new SalaryInfoIndexModel()
            {
                SalaryInfoGrid = grid,
                CanSubmit = ApplicationUser.Permissions.SalaryInfo_Save,
            };
        }

        public SalaryInfoIndexModel Index(SalaryInfoIndexModel model)
        {
            throw new System.NotImplementedException();
        }

        public void Refresh(SalaryInfoFormModel model)
        {
            if (model == null)
                return;

            model.BankBranchList = model.BankId > 0
                ? UnitOfWork.BankBranches.GetBankBranchWithBank(model.BankId).ToList()
                : new HashSet<BankBranchListItem>();

            //var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            //if (employee?.JobInfo?.JobType == JobType.Designation)
            //{
            //    var salaryUnits = UnitOfWork.SalaryUnits.GetBySalayClassification(model.SalayClassification).ToList();

            //    if (salaryUnits == null)
            //        return;

            //    model.BasicSalary = employee.GetBasicSalaryByDegree(salaryUnits, model.SalayClassification);
            //    model.ExtraValue = employee.GetExtraValueByDegree(salaryUnits, model.SalayClassification);
            //    model.ExtraGeneralValue = employee.GetExtraGeneralValueByDegree(salaryUnits, model.SalayClassification);
            //}
        }

        public SalaryInfoFormModel Find(int id)
        {
            var salaryUnits = UnitOfWork.SalaryUnits.GetAll().ToList();

            //if (salaryUnits == null)
            //    return Null<SalaryInfoFormModel>(RequestState.NotFound);
            var salaryUnits2 = UnitOfWork.SalaryUnits.GetAll().ToList();


            UnitOfWork.Complete(n => n.SalaryInfo_Save);
            if (!HavePermission(ApplicationUser.Permissions.SalaryInfo_Save))
                return Null<SalaryInfoFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<SalaryInfoFormModel>(RequestState.BadRequest);

            var employee = UnitOfWork.Employees.Find(id);

            if (employee == null)
                return Null<SalaryInfoFormModel>(RequestState.NotFound);

            //var salayClassification = SalayClassification.Default;

            //if (employee.SalaryInfo != null)
            var salayClassification = employee.JobInfo.SalayClassification;

          //  var salaryUnits = UnitOfWork.SalaryUnits.GetBySalayClassification(salayClassification ?? 0).ToList();

            //if (salaryUnits == null)
            //    return Null<SalaryInfoFormModel>(RequestState.NotFound);
            var basicSalary = employee.GetBasicSalaryByDegree(salaryUnits, salayClassification ?? 0);
           //7 var salaryUnits2 = UnitOfWork.SalaryUnits.GetAll().ToList();
          

            var extraValue = employee.GetExtraValueByDegree(salaryUnits, salayClassification ?? 0);
            var extraGeneralValue = employee.GetExtraGeneralValueByDegree(salaryUnits, salayClassification ?? 0);

            var bankId = employee.SalaryInfo?.BankBranch?.BankId ?? 0;
            if (employee.JobInfo?.CurrentSituation?.CurrentSituationId ==26)
            {
                var newSalary = basicSalary / 2;
                var newextraValue = extraValue / 2;
                var newextraGeneralValue = extraGeneralValue / 2;
                extraValue = newextraValue;
                extraGeneralValue = newextraGeneralValue;
                basicSalary = newSalary;

            }

            return new SalaryInfoFormModel()
            {
                //
                Bouns = employee.JobInfo?.Bouns??0,
                Bounshr = employee.JobInfo?.Bounshr??0,
                DegreeNow =   employee.JobInfo?.DegreeNow??0,
                //
                EmployeeId = id,
                BankBranchId = employee.SalaryInfo?.BankBranchId ?? 0,
                BankId = bankId,
                BankBranchList = UnitOfWork.BankBranches.GetBankBranchWithBank(bankId).ToList(),
                BankList = UnitOfWork.Banks.GetAll().ToList(),
                BasicSalary = employee.JobInfo.JobType == JobType.Designation ?
                                basicSalary : employee.SalaryInfo?.BasicSalary ?? 0,
                BondNumber = employee.SalaryInfo?.BondNumber,
                FinancialNumber = employee.SalaryInfo?.FinancialNumber,
                GuaranteeType = employee.SalaryInfo?.GuaranteeType ?? 0,
                GuaranteeTypeSafe= employee.SalaryInfo?.GuaranteeType ?? 0,


                SecurityNumber = employee.SalaryInfo?.SecurityNumber,
                EmployeePremiumList = UnitOfWork.Employees.GetEmployeePremiumBy(employee.EmployeeId).ToList(),
                PremiumList = UnitOfWork.Premiums.GetAll().ToList(),
                EmployeeName = employee.GetFullName(),
                ExtraValue = employee.JobInfo.JobType == JobType.Designation ?
                                extraValue : employee.SalaryInfo?.ExtraValue ?? 0,
                ExtraGeneralValue = employee.JobInfo.JobType == JobType.Designation ?
                                extraGeneralValue : employee.SalaryInfo?.ExtraGeneralValue ?? 0,
                SalayClassification = salayClassification == SalayClassification.Clamp
                        ? typeof(SalayClassification).DisplayFieldName(SalayClassification.Clamp.ToString())
                        : typeof(SalayClassification).DisplayFieldName(SalayClassification.Default.ToString()),
                IsDesignation = employee.JobInfo?.JobType == JobType.Designation,
                FileNumber = employee.SalaryInfo?.FileNumber,
                CanSubmit = ApplicationUser.Permissions.SalaryInfo_Save
            };

        }
        
        public bool Save(int id, SalaryInfoFormModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.SalaryInfo_Save))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var empolyee = UnitOfWork.Employees.Find(id);

            var premiums = UnitOfWork.Premiums.GetAll();//////////

            var premiumDto = new Collection<PremiumDto>();

            foreach (var premium in premiums)
            {
                var dto = new PremiumDto()
                {
                    Premium = premium,
                    Value = model.EmployeePremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.Value ?? 0,
                    AllValue = model.EmployeePremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.AllValue ?? 0,
                   PartOfvalue  = model.EmployeePremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.PartOfvalue ?? 0,
                    IsAvance = model.EmployeePremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.ISAdvance ?? 0,
                  ValueIncpect= model.EmployeePremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.Valuinspect ?? 0,
                    ISAdvancePremmium = model.EmployeePremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.ISAdvancePremmium ?? 0,

                };
                premiumDto.Add(dto);
            }
            if (empolyee.SalaryInfo == null)
            {
                var salaryInfo = SalaryInfo.New(empolyee, model.BankBranchId, model.GuaranteeType, model.BondNumber,
                    model.BasicSalary, model.SecurityNumber, model.FinancialNumber, premiumDto
                    , model.FileNumber, model.ExtraValue, model.ExtraGeneralValue,model.GuaranteeTypeSafe);

                UnitOfWork.Employees.AddSalaryInfo(salaryInfo);
            }
            else
            {
                empolyee.SalaryInfo.Modify(empolyee, model.BankBranchId, model.GuaranteeType, model.BondNumber
                    , model.BasicSalary, model.SecurityNumber, model.FinancialNumber, premiumDto
                    , model.FileNumber, model.ExtraValue, model.ExtraGeneralValue,model.GuaranteeTypeSafe);///////////////
            }

            UnitOfWork.Complete(n => n.SalaryInfo_Save);

            return SuccessEdit();
        }

        public SalaryInfoIndexModel EndedSalary()
        {
            var date2 = DateTime.Now;

            if (!HavePermission())
                return Null<SalaryInfoIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Employees.GetEmployeeWithoutSalaries(date2, 2).ToGridEmployee().ToList();

            return new SalaryInfoIndexModel()
            {
                SalaryInfoGrid = grid,
                CanSubmit = ApplicationUser.Permissions.SalaryInfo_Save,
            };
        }
    }
}