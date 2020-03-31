using Almotkaml.MFMinistry.Abstraction;

namespace Almotkaml.MFMinistry.Business.App_Business.General
{
    public class BackUpRestoreBusiness : Business, IBackUpRestoreBusiness
    {
        public BackUpRestoreBusiness(HrMFMinistry humanResource) : base(humanResource)
        {
        }

        public void Prepare()
        {

        }

        public bool BackUp(string path)
        {
            return UnitOfWork.BackUp(path);
        }

        public bool Restore(string path)
        {
            return false;

            //if (UnitOfWork.Restore(path))
            //    return "Succeed";

            //return "Failed";
        }
    }
}