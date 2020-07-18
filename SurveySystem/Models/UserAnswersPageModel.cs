using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class UserAnswersPageModel
    {
        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
