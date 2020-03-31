using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DegreeBusiness : Business, IDegreeBusiness
    {
        public DegreeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Degree && permission;

        public DegreeModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Degree))
                return Null<DegreeModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Employees.GetEmployeeDegree();

            return new DegreeModel()
            {
                CanSubmit = ApplicationUser.Permissions.Degree_Add,
                DegreeGrid = grid.ToDegreeGrid(),
                JobList = UnitOfWork.Jobs.GetAll().ToList().ToList()
            };
        }

        public bool Submit(DegreeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Degree_Add))
                return Fail(RequestState.NoPermission);

            if (model == null)
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return Fail(RequestState.NotFound);

            var modify = employee.JobInfo.Modify();

            var selectedRow = model.DegreeGrid.FirstOrDefault(e => e.EmployeeId == model.EmployeeId);

            if (selectedRow == null)
                return Fail("selected row not found");
            //  var degree & bouns = «·„— » «·√”«”Ì „‰ «·œ—Ã… Ê«·⁄·«Ê… «·Õ«·Ì… -- basicSalary
            // «·„— »«  «·√”«”Ì… ›Ì «·œ—Ã… «· «·Ì… »ÕÌÀ ÌﬂÊ‰ >= «·„— » «·Õ«·Ì(«·œ—Ã… Ê«·⁄·«Ê… ·√ﬁ—» ﬁÌ„… ··„— » «·Õ«·Ì „‰ Â–Â «·ﬁ«∆„… ) 
            var date = employee.JobInfo?.DateDegreeNow;
            var firstHalfYear = new DateTime(date.GetValueOrDefault().Year, 6, 30);
            var secondHalfYear = new DateTime(date.GetValueOrDefault().Year, 12, 31);

            if (date <= firstHalfYear)
            {
                if (employee.JobInfo.DegreeNow < 10 && employee.JobInfo.Bouns >= 4)
                {
                    modify
                        .DateDegreeNow(firstHalfYear.AddYears(4))
                        .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                        .Bouns(employee.JobInfo.Bouns - 4)
                        .Job(selectedRow.JobId)
                        .Confirm();
                }
                else if (employee.JobInfo.DegreeNow == 10 && employee.JobInfo.Bouns >= 5)
                {
                    modify
                        .DateDegreeNow(firstHalfYear.AddYears(5))
                        .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                        .Bouns(employee.JobInfo.Bouns - 5)
                        .Job(selectedRow.JobId)
                        .Confirm();
                }
                else if (employee.JobInfo.DegreeNow >= 11 && employee.JobInfo.Bouns >= 1)
                {
                    modify
                        .DateDegreeNow(firstHalfYear.AddYears(1))
                        .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                        .Bouns(employee.JobInfo.Bouns - 1)
                        .Job(selectedRow.JobId)
                        .Confirm();
                }
            }
            else if (date > firstHalfYear && date <= secondHalfYear)
            {
                if (employee.JobInfo.DegreeNow < 10 && employee.JobInfo.Bouns >= 4)
                {
                    modify
                        .DateDegreeNow(secondHalfYear.AddYears(4))
                        .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                        .Bouns(employee.JobInfo.Bouns - 4)
                        .Job(selectedRow.JobId)
                        .Confirm();
                }
                else if (employee.JobInfo.DegreeNow == 10 && employee.JobInfo.Bouns >= 5)
                {
                    modify
                        .DateDegreeNow(secondHalfYear.AddYears(5))
                        .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                        .Bouns(employee.JobInfo.Bouns - 5)
                        .Job(selectedRow.JobId)
                        .Confirm();
                }
                else if (employee.JobInfo.DegreeNow >= 11 && employee.JobInfo.Bouns >= 1)
                {
                    modify
                        .DateDegreeNow(secondHalfYear.AddYears(1))
                        .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                        .Bouns(employee.JobInfo.Bouns - 1)
                        .Job(selectedRow.JobId)
                        .Confirm();
                }
            }

            UnitOfWork.Complete(n => n.Degree_Add);

            return SuccessCreate();

        }

        public bool Submit(JobInfoDegreeModel model, int type)
        {
            if (!HavePermission(ApplicationUser.Permissions.Degree_Add))
                return Fail(RequestState.NoPermission);

            if (model == null)
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return Fail(RequestState.NotFound);

            var modify = employee.JobInfo.Modify();

            if (type == 1)
            {
                var DegreeNowDate = Convert.ToDateTime(model.DirectlyDate);
                modify
                       .DirectlyDate(DegreeNowDate)
                       .DegreeNow(model.Degree)
                       .Bouns(model.Bouns)
                       .Job(model.JobId)
                       .Confirm();

            }

            if (type == 2)
            {
                var date = employee.JobInfo?.DateDegreeNow;
                var firstHalfYear = new DateTime(date.GetValueOrDefault().Year, 6, 30);
                var secondHalfYear = new DateTime(date.GetValueOrDefault().Year, 12, 31);

                if (date <= firstHalfYear)
                {
                    if (employee.JobInfo.DegreeNow < 10 && employee.JobInfo.Bouns >= 4)
                    {
                        modify
                            .DateDegreeNow(firstHalfYear.AddYears(4))
                            .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                            .Bouns(employee.JobInfo.Bouns - 4)
                            .Job(model.JobId)
                            .Confirm();
                    }
                    else if (employee.JobInfo.DegreeNow == 10 && employee.JobInfo.Bouns >= 5)
                    {
                        modify
                            .DateDegreeNow(firstHalfYear.AddYears(5))
                            .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                            .Bouns(employee.JobInfo.Bouns - 5)
                             .Job(model.JobId)
                            .Confirm();
                    }
                    else if (employee.JobInfo.DegreeNow >= 11 && employee.JobInfo.Bouns >= 1)
                    {
                        modify
                            .DateDegreeNow(firstHalfYear.AddYears(1))
                            .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                            .Bouns(employee.JobInfo.Bouns - 1)
                             .Job(model.JobId)
                            .Confirm();
                    }
                }
                else if (date > firstHalfYear && date <= secondHalfYear)
                {
                    if (employee.JobInfo.DegreeNow < 10 && employee.JobInfo.Bouns >= 4)
                    {
                        modify
                            .DateDegreeNow(secondHalfYear.AddYears(4))
                            .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                            .Bouns(employee.JobInfo.Bouns - 4)
                             .Job(model.JobId)
                            .Confirm();
                    }
                    else if (employee.JobInfo.DegreeNow == 10 && employee.JobInfo.Bouns >= 5)
                    {
                        modify
                            .DateDegreeNow(secondHalfYear.AddYears(5))
                            .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                            .Bouns(employee.JobInfo.Bouns - 5)
                            .Job(model.JobId)
                            .Confirm();
                    }
                    else if (employee.JobInfo.DegreeNow >= 11 && employee.JobInfo.Bouns >= 1)
                    {
                        modify
                            .DateDegreeNow(secondHalfYear.AddYears(1))
                            .DegreeNow(employee.JobInfo?.DegreeNow + 1)
                            .Bouns(employee.JobInfo.Bouns - 1)
                             .Job(model.JobId)
                            .Confirm();
                    }
                }

            }



            UnitOfWork.Complete(n => n.Degree_Add);

            return SuccessCreate();

        }
        public bool Cancel(DegreeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Degree_Add))
                return Fail(RequestState.NoPermission);

            if (model == null)
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return Fail(RequestState.NotFound);

            employee.JobInfo.Modify()
                .DateDegreeNow(employee.JobInfo?.DateDegreeNow?.AddYears(1))
                .Confirm();

            UnitOfWork.Complete(n => n.Degree_Add);

            return SuccessCreate();

        }
    }
}