using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerMe.Common.Models
{
    public class QuestionDto
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool Answered { get; set; }
    }
}
