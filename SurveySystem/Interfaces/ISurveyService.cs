using Microsoft.AspNetCore.Identity;
using SurveySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Interfaces
{
    public interface ISurveyService
    {
        Survey Get(int id);
        ICollection<Survey> GetAll();
        bool Add(Component component, string userName);
        ICollection<Question> GetAllQuestions();
        void AddUserAnswers(ICollection<Models.UserAnswer> userAnswers);
        IdentityUser GetUser(string name);
    }
}
