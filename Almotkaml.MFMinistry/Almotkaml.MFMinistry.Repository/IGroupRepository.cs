using Almotkaml.MFMinistry.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.MFMinistry.Repository
{
    public interface IGroupRepository : IRepository<RecipientGroup>, ICheckNameExisted { }

}