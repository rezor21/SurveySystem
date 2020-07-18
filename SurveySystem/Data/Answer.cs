using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Data
{
    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
    }
}
