using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class FormsMFM // الاستمارة
    {

        public static FormsMFM New(string formNumber, FormsType type, FormCategory fCategory
            , FormsStatus fStatus, int departmentId,int drawerId,int financialGroupId,int recipientGroupId)
        {
            Check.NotEmpty(formNumber, nameof(formNumber));

            var formsMFM = new FormsMFM()
            {
                FormNumber = formNumber,
                Type = type,
                FCategory = fCategory,
                FStatus = fStatus,
                DepartmentId = departmentId,
                DrawerId = drawerId,
                FinancialGroupId= financialGroupId,
                RecipientGroupId= recipientGroupId,
            };


            return formsMFM;
        }

        private FormsMFM()
        {

        }
        public int FormsMFMId { get; private set; }
        public string FormNumber { get; private set; }// رقم الاستمارة- الباركود
        public FormsType Type { get; private set; }// نوع الاستمارة
        public FormCategory FCategory { get; private set; }// المستفيد من الاستمارة
        //public int FormsStatusId { get; private set; }
        public FormsStatus FStatus { get; private set; }
        public FinancialGroup FinancialGroup { get; private set; }
        public int FinancialGroupId { get; private set; } // رقم المجموعة المالية
        public RecipientGroup RecipientGroup { get; private set; } // الفئة
        public int RecipientGroupId { get; private set; }
        public Department Department { get; private set; } // المكتب
        public int DepartmentId { get; private set; }
        public Drawer Drawer { get; private set; } //الدرج
        public int DrawerId { get; private set; }// رقم الدرج
        public void Modify(string formNumber, FormsType type, FormCategory fCategory
            , FormsStatus fStatus, int departmentId, int drawerId, int financialGroupId, int recipientGroupId)
        {

            FormNumber = formNumber;
            Type = type;
            FCategory = fCategory;
            FStatus = fStatus;
            DepartmentId = departmentId;
            DrawerId = drawerId;
                FinancialGroupId = financialGroupId;
                RecipientGroupId = recipientGroupId;
        }
        public DataCollection DataCollections { get; set; }

    }
}
