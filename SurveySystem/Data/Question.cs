using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Data
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SurveyId { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
