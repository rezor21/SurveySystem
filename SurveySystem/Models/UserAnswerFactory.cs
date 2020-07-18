using SurveySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class UserAnswerFactory
    {
        public UserAnswerFactory()
        {
        }

        public Data.Answer GetAnswer(UserAnswer myAnswer, ApplicationDbContext context)
        {
            Data.Answer answer;
            answer = context.Answers.FirstOrDefault(x => x.QuestionId == myAnswer.QuestionId && x.Title == myAnswer.Answer);
            if (answer == null)
            {
                answer = new Data.Answer { QuestionId = myAnswer.QuestionId, Title = myAnswer.Answer };
                context.Answers.Add(answer);
                context.SaveChanges();
            }

            return answer;
        }
    }
}
