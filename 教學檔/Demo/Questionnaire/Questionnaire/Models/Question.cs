using System;
using System.Collections.Generic;

#nullable disable

namespace Questionnaire.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
