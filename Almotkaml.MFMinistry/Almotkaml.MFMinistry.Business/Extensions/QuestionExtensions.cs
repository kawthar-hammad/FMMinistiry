using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class QuestionExtensions
    {
        public static IEnumerable<QuestionGridRow> ToGrid(this IEnumerable<Question> question)
         => question.Select(d => new QuestionGridRow()
         {
             QuestionId=d.QuestionId,
             Name = d.Name
           
         });
    }
}
