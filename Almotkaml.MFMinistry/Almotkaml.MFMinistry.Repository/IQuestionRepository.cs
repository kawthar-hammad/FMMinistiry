using Almotkaml.MFMinistry.Domain;
using Almotkaml.Repository;

namespace Almotkaml.MFMinistry.Repository
{
    public interface IQuestionRepository : IRepository<Question>, ICheckNameExisted
    {
    }
}
