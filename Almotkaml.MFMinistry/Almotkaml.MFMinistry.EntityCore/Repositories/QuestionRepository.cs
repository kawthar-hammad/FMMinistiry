using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.EntityCore.Repositories;
using Almotkaml.MFMinistry.Repository;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private MFMinistryDbContext Context { get; }

        internal QuestionRepository(MFMinistryDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Questions
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Questions
            .Any(e => e.Name == name && e.QuestionId != idToExcept);
    }
}