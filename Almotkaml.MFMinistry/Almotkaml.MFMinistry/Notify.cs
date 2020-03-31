// ReSharper disable InconsistentNaming

using Almotkaml.Attributes;
using Almotkaml.MFMinistry.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.MFMinistry
{
    public class Notify
    {
     

        [Phrase(typeof(Notifications), nameof(Branch_Create))]
        public bool Branch_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Branch_Edit))]
        public bool Branch_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Branch_Delete))]
        public bool Branch_Delete { get; set; }

     

       

        [Phrase(typeof(Notifications), nameof(Nationality_Create))]
        public bool Nationality_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Nationality_Edit))]
        public bool Nationality_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Nationality_Delete))]
        public bool Nationality_Delete { get; set; }



      

        [Phrase(typeof(Notifications), nameof(User_Create))]
        public bool User_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(User_Edit))]
        public bool User_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(User_Delete))]
        public bool User_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(UserGroup_Create))]
        public bool UserGroup_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(UserGroup_Edit))]
        public bool UserGroup_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(UserGroup_Delete))]
        public bool UserGroup_Delete { get; set; }


   

        [Phrase(typeof(Notifications), nameof(Bank_Create))]
        public bool Bank_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Bank_Edit))]
        public bool Bank_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Bank_Delete))]
        public bool Bank_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(BankBranch_Create))]
        public bool BankBranch_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(BankBranch_Edit))]
        public bool BankBranch_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(BankBranch_Delete))]
        public bool BankBranch_Delete { get; set; }

     

        [Phrase(typeof(Notifications), nameof(City_Create))]
        public bool City_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(City_Edit))]
        public bool City_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(City_Delete))]
        public bool City_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Country_Create))]
        public bool Country_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Country_Edit))]
        public bool Country_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Country_Delete))]
        public bool Country_Delete { get; set; }


        [Phrase(typeof(Notifications), nameof(Question_Create))]
        public bool Question_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Question_Edit))]
        public bool Question_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Question_Delete))]
        public bool Question_Delete { get; set; }
        [Phrase(typeof(Notifications), nameof(GrantRule_Create))]
        public bool GrantRule_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(GrantRule_Edit))]
        public bool GrantRule_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(GrantRule_Delete))]
        public bool GrantRule_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(FinancialGroup_Create))]
        public bool FinancialGroup_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(FinancialGroup_Edit))]
        public bool FinancialGroup_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(FinancialGroup_Delete))]
        public bool FinancialGroup_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(RecipientGroup_Create))]
        public bool RecipientGroup_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(RecipientGroup_Edit))]
        public bool RecipientGroup_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(RecipientGroup_Delete))]
        public bool RecipientGroup_Delete { get; set; }
        [Phrase(typeof(Notifications), nameof(Department_Create))]
        public bool Department_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Department_Edit))]
        public bool Department_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Department_Delete))]
        public bool Department_Delete { get; set; }
        [Phrase(typeof(Notifications), nameof(Drawer_Create))]
        public bool Drawer_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Drawer_Edit))]
        public bool Drawer_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Drawer_Delete))]
        public bool Drawer_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(MartyrForm_Create))]
        public bool MartyrForm_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(MartyrForm_Edit))]
        public bool MartyrForm_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(MartyrForm_Delete))]
        public bool MartyrForm_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(MissingForm_Create))]
        public bool MissingForm_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(MissingForm_Edit))]
        public bool MissingForm_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(MissingForm_Delete))]
        public bool MissingForm_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Job_Create))]
        //public bool Job_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Job_Edit))]
        //public bool Job_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Job_Delete))]
        //public bool Job_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Vacation_Create))]
        //public bool Vacation_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Vacation_Edit))]
        //public bool Vacation_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Vacation_Delete))]
        //public bool Vacation_Delete { get; set; }
        //public bool Vacation_BalancYear { get; set; }

        //[Phrase(typeof(Notifications), nameof(VacationType_Create))]
        //public bool VacationType_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(VacationType_Edit))]
        //public bool VacationType_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(VacationType_Delete))]
        //public bool VacationType_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Division_Create))]
        //public bool Division_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Division_Edit))]
        //public bool Division_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Division_Delete))]
        //public bool Division_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Note_Create))]
        //public bool Note_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Note_Edit))]
        //public bool Note_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Note_Delete))]
        //public bool Note_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Place_Create))]
        //public bool Place_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Place_Edit))]
        //public bool Place_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Place_Delete))]
        //public bool Place_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Qualification_Create))]
        //public bool Qualification_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Qualification_Edit))]
        //public bool Qualification_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Qualification_Delete))]
        //public bool Qualification_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(QualificationType_Create))]
        //public bool QualificationType_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(QualificationType_Edit))]
        //public bool QualificationType_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(QualificationType_Delete))]
        //public bool QualificationType_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Reward_Create))]
        //public bool Reward_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Reward_Edit))]
        //public bool Reward_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Reward_Delete))]
        //public bool Reward_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(RewardType_Create))]
        //public bool RewardType_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(RewardType_Edit))]
        //public bool RewardType_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(RewardType_Delete))]
        //public bool RewardType_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Staffing_Create))]
        //public bool Staffing_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Staffing_Edit))]
        //public bool Staffing_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Staffing_Delete))]
        //public bool Staffing_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(StaffingType_Create))]
        //public bool StaffingType_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(StaffingType_Edit))]
        //public bool StaffingType_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(StaffingType_Delete))]
        //public bool StaffingType_Delete { get; set; }
        //[Phrase(typeof(Notifications), nameof(StaffingClassification_Create))]
        //public bool StaffingClassification_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(StaffingClassification_Edit))]
        //public bool StaffingClassification_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(StaffingClassification_Delete))]
        //public bool StaffingClassification_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(SubSpecialty_Create))]
        //public bool SubSpecialty_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(SubSpecialty_Edit))]
        //public bool SubSpecialty_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(SubSpecialty_Delete))]
        //public bool SubSpecialty_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(TrainingCourse_Create))]
        //public bool TrainingCourse_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(TrainingCourse_Edit))]
        //public bool TrainingCourse_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(TrainingCourse_Delete))]
        //public bool TrainingCourse_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Unit_Create))]
        //public bool Unit_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Unit_Edit))]
        //public bool Unit_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Unit_Delete))]
        //public bool Unit_Delete { get; set; }
        //[Phrase(typeof(Notifications), nameof(TimeSheet_Create))]
        //public bool TimeSheet_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(TimeSheet_Edit))]
        //public bool TimeSheet_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(TimeSheet_Delete))]
        //public bool TimeSheet_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Evaluation_Create))]
        //public bool Evaluation_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Evaluation_Edit))]
        //public bool Evaluation_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Evaluation_Delete))]
        //public bool Evaluation_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Extrawork_Create))]
        //public bool Extrawork_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Extrawork_Edit))]
        //public bool Extrawork_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Extrawork_Delete))]
        //public bool Extrawork_Delete { get; set; }


        //[Phrase(typeof(Notifications), nameof(SelfCourse_Create))]
        //public bool SelfCourse_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(SelfCourse_Edit))]
        //public bool SelfCourse_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(SelfCourse_Delete))]
        //public bool SelfCourse_Delete { get; set; }


        //[Phrase(typeof(Notifications), nameof(EndServices_Create))]
        //public bool EndServices_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(EndServices_Edit))]
        //public bool EndServices_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(EndServices_Delete))]
        //public bool EndServices_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Bouns_Add))]
        //public bool Bouns_Add { get; set; }

        //[Phrase(typeof(Notifications), nameof(Degree_Add))]
        //public bool Degree_Add { get; set; }


        //[Phrase(typeof(Notifications), nameof(SituationResolveJob_Create))]
        //public bool SituationResolveJob_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(SituationResolveJob_Edit))]
        //public bool SituationResolveJob_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(SituationResolveJob_Delete))]
        //public bool SituationResolveJob_Delete { get; set; }


        //[Phrase(typeof(Notifications), nameof(Absence_Create))]
        //public bool Absence_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Absence_Edit))]
        //public bool Absence_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Absence_Delete))]
        //public bool Absence_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Transfer_Create))]
        //public bool Transfer_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Transfer_Edit))]
        //public bool Transfer_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Transfer_Delete))]
        //public bool Transfer_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Corporation_Create))]
        //public bool Corporation_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Corporation_Edit))]
        //public bool Corporation_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Corporation_Delete))]
        //public bool Corporation_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Delegation_Create))]
        //public bool Delegation_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Delegation_Edit))]
        //public bool Delegation_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Delegation_Delete))]
        //public bool Delegation_Delete { get; set; }

        //public bool DevelopmentTypeA_Create { get; set; }

        //public bool DevelopmentTypeA_Edit { get; set; }

        //public bool DevelopmentTypeA_Delete { get; set; }

        //public bool DevelopmentTypeB_Create { get; set; }

        //public bool DevelopmentTypeB_Edit { get; set; }

        //public bool DevelopmentTypeB_Delete { get; set; }
        //public bool DevelopmentTypeC_Create { get; set; }
        //public bool DevelopmentTypeC_Edit { get; set; }
        //public bool DevelopmentTypeC_Delete { get; set; }
        //public bool DevelopmentTypeD_Create { get; set; }
        //public bool DevelopmentTypeD_Edit { get; set; }
        //public bool DevelopmentTypeD_Delete { get; set; }
        //public bool DevelopmentTypeE_Create { get; set; }
        //public bool DevelopmentTypeE_Edit { get; set; }
        //public bool DevelopmentTypeE_Delete { get; set; }
        //public bool Training_Create { get; set; }
        //public bool Training_Edit { get; set; }
        //public bool Training_Delete { get; set; }
        //public bool DevelopmentState_Create { get; set; }
        //public bool DevelopmentState_Edit { get; set; }
        //public bool DevelopmentState_Delete { get; set; }
        //public bool RequestedQualification_Create { get; set; }
        //public bool RequestedQualification_Edit { get; set; }
        //public bool RequestedQualification_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Premium_Create))]
        //public bool Premium_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Premium_Edit))]
        //public bool Premium_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Premium_Delete))]
        //public bool Premium_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Freeze))]
        //public bool Salary_Freeze { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Allow))]
        //public bool Salary_Allow { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Close))]
        //public bool Salary_Close { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Update))]
        //public bool Salary_Update { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Spent))]
        //public bool Salary_Spent { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Edit))]
        //public bool Salary_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Delete))]
        //public bool Salary_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(AdvancePayment_Create))]
        //public bool AdvancePayment_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(AdvancePayment_Edit))]
        //public bool AdvancePayment_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(AdvancePayment_Delete))]
        //public bool AdvancePayment_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(SalaryInfo_Save))]
        //public bool SalaryInfo_Save { get; set; }

        //[Phrase(typeof(Notifications), nameof(ExactSpecialty_Create))]
        //public bool ExactSpecialty_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(ExactSpecialty_Edit))]
        //public bool ExactSpecialty_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(ExactSpecialty_Delete))]
        //public bool ExactSpecialty_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Holiday_Create))]
        //public bool Holiday_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Holiday_Edit))]
        //public bool Holiday_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Holiday_Delete))]
        //public bool Holiday_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Center_Create))]
        //public bool Center_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Center_Edit))]
        //public bool Center_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Center_Delete))]
        //public bool Center_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_OldSalary))]
        //public bool Salary_OldSalary { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Suspend))]
        //public bool Salary_Suspend { get; set; }

        //[Phrase(typeof(Notifications), nameof(Salary_Unsuspend))]
        //public bool Salary_Unsuspend { get; set; }


        ////[Phrase(typeof(Notifications), nameof(AddSupsended))]
        ////[Display(ResourceType = typeof(Titles), Name = nameof(Notifications.Suspsended))]
        //public bool AddSupsended { get; set; }


        [Phrase(typeof(Notifications), nameof(CompanyInfo_Update))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Edit))]
        public bool CompanyInfo_Update { get; set; }


        //[Phrase(typeof(Notifications), nameof(Setting_Update))]
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Edit))]
        //public bool Setting_Update { get; set; }

        //[Phrase(typeof(Notifications), nameof(Document_Create))]
        //public bool Document_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(Document_Edit))]
        //public bool Document_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(Document_Delete))]
        //public bool Document_Delete { get; set; }

        //[Phrase(typeof(Notifications), nameof(DocumentType_Create))]
        //public bool DocumentType_Create { get; set; }

        //[Phrase(typeof(Notifications), nameof(DocumentType_Edit))]
        //public bool DocumentType_Edit { get; set; }

        //[Phrase(typeof(Notifications), nameof(DocumentType_Delete))]
        //public bool DocumentType_Delete { get; set; }
        //[Phrase(typeof(Notifications), nameof(Employee_Settlement))]
        //public bool Employee_Settlement { get; set; }
        //[Phrase(typeof(Notifications), nameof(Employee_Promotion))]
        //public bool Employee_Promotion { get; set; }
        //[Phrase(typeof(Notifications), nameof(Degree_Edit))]
        //public bool Degree_Edit { get; set; }


    }
    public class Grants
    {
        public bool mother { get; set; }
        public bool fother { get; set; }
        public bool wifemarr { get; set; }
        public bool wifenotmarr { get; set; }
        public bool childmarr { get; set; }
        public bool childnotmarr { get; set; }
        public bool dauthermarr { get; set; }
        public bool dauthernotmarr { get; set; }
    }
}
