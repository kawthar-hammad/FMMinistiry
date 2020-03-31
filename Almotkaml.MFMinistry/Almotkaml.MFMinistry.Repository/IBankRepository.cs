using Almotkaml.MFMinistry.Domain;
using Almotkaml.Repository;

namespace Almotkaml.MFMinistry.Repository
{
    public interface IBankRepository : IRepository<Bank>, ICheckNameExisted { }
}