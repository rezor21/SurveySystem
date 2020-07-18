using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class UserAnswer
    { 
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string Answer { get; set; }
        public bool Value { get; set; }
    }
}
