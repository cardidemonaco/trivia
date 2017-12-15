using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.DataModel
{
    public class vwQuestionAnswer
    {
        public int QuestionId { get; }
        public Question Question { get; }
        public int AnswerId { get; }
        public Answer Answer { get; }
        public bool CorrectAnswer { get; }

        
    }
}
