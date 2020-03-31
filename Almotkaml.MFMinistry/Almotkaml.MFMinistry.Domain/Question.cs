using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class Question
    {
        public static Question New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var question = new Question()
            {
                Name = name,
            };


            return question;
        }

        private Question()
        {

        }
        public int QuestionId { get; private set; }
        public string Name { get; private set; }
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }

    }
}
