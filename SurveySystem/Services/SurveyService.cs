using Microsoft.AspNetCore.Identity;
using SurveySystem.Data;
using SurveySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Services
{
    public class SurveyService : ISurveyService
    {
        private static SurveyService _instance;
        private readonly ApplicationDbContext _context;

        public SurveyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Survey Get(int id)
        {
            var dbSurvey = _context.Surveys.SingleOrDefault(x => x.Id == id);

            if (dbSurvey == null)
                return null;

            return dbSurvey;
        }

        public ICollection<Survey> GetAll()
        {
            var questions = _context.Questions.ToList();
            var answers = _context.Answers.ToList();
            return _context.Surveys.ToList();
        }

        public ICollection<Question> GetAllQuestions()
        {
            var answers = _context.Answers.ToList();
            return _context.Questions.ToList();
        }

        public ICollection<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();
        }

        public bool Add(Component component, string userName)
        {
            Models.Invoker invoker = new Models.Invoker();
            invoker.SetOnStart(new Models.AuthCommand(_context, userName));
            component.Add(_context);
            invoker.SetOnFinish(new Models.CheckCommand(this, component.Title, component.GetType().Name));

            
            return invoker.Execute();
        }

        public void AddUserAnswers(ICollection<Models.UserAnswer> userAnswers)
        {
            var factory = new Models.UserAnswerFactory();
            foreach(var userAnswer in userAnswers)
            {
                if (userAnswer.Value)
                {
                    var answer = factory.GetAnswer(userAnswer, _context);
                    var dbItem = new Data.UserAnswer { AnswerId = answer.Id, UserId = userAnswer.UserId };
                    _context.UsersAnswers.Add(dbItem);
                    _context.SaveChanges();
                }
                
            }
        }

        public IdentityUser GetUser(string name)
        {
            return _context.Users.SingleOrDefault(x => x.UserName == name);
        }
    }
}
