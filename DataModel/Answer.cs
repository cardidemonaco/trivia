using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.DataModel
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
    }
}
