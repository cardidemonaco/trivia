using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.DataModel
{
    public class QuestionCategory
    {
        [Key]
        [Column(Order = 1)]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
