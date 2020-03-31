using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using Almotkaml.MFMinistry.Business.Extensions;
using System.Linq;
using Almotkaml.MFMinistry.Abstraction;

namespace Almotkaml.MFMinistry.Business.App_Business.MainSettings
{
    public class QuestionBusiness : Business, IQuestionBusiness
    {
        public QuestionBusiness(HrMFMinistry mfMinistry)
            : base(mfMinistry)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Question && permission;


        public QuestionModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.Question_Create))
                return Null<QuestionModel>(RequestState.NoPermission);

            return new QuestionModel()
            {
                CanCreate = ApplicationUser.Permissions.Question_Create,
                CanEdit = ApplicationUser.Permissions.Question_Edit,
                CanDelete = ApplicationUser.Permissions.Question_Delete,
                QuestionGrid = UnitOfWork.Questions.GetAll().ToGrid()
            };
        }

        public void Refresh(QuestionModel model)
        {

        }

        public bool Select(QuestionModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Question_Edit))
                return Fail(RequestState.NoPermission);
            if (model.QuestionId <= 0)
                return Fail(RequestState.BadRequest);

            var question = UnitOfWork.Questions.Find(model.QuestionId);

            if (question == null)
                return Fail(RequestState.NotFound);

            model.Name = question.Name;
            return true;
        }

        public bool Create(QuestionModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Question_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Questions.NameIsExisted(model.Name))
                return NameExisted();
            var question = Question.New(model.Name);
            UnitOfWork.Questions.Add(question);

            UnitOfWork.Complete(n => n.Question_Create);

            return SuccessCreate();
        }

        public bool Edit(QuestionModel model)
        {
            if (model.QuestionId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Question_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var question = UnitOfWork.Questions.Find(model.QuestionId);

            if (question == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Questions.NameIsExisted(model.Name, model.QuestionId))
                return NameExisted();
            question.Modify(model.Name);

            UnitOfWork.Complete(n => n.Question_Edit);

            return SuccessEdit();
        }

        public bool Delete(QuestionModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Question_Delete))
                return Fail(RequestState.NoPermission);

            if (model.QuestionId <= 0)
                return Fail(RequestState.BadRequest);

            var question = UnitOfWork.Questions.Find(model.QuestionId);

            if (question == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Questions.Remove(question);
            if (!UnitOfWork.TryComplete(n => n.Question_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}