using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurveySystem.Interfaces;
using SurveySystem.Models;

namespace SurveySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISurveyService _surveyService;

        public HomeController(ILogger<HomeController> logger, ISurveyService surveyService)
        {
            _logger = logger;
            _surveyService = surveyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Surveys()
        {
          
            var list = _surveyService.GetAll();
            return View("Surveys", list);
        }

        [Authorize]
        public IActionResult AddItemView()
        {
            return View();
        }

        [Authorize]
        [Route("Home/AddQuestionView/{parentId:int}")]
        public IActionResult AddQuestionView([FromRoute]int parentId)
        {

            return View(new Question { ParentId = parentId});
        }

        [Authorize]
        [Route("Home/AddAnswerView/{parentId:int}")]
        public IActionResult AddAnswerView([FromRoute]int parentId)
        {
            return View();
        }

        [Authorize]
        public IActionResult UserAnswerView()
        {
            return View("UserAnswerView", _surveyService.GetAll());
        }

        [Authorize]
        [Route("Home/AddUserAnswerView/{questionId:int}")]
        public IActionResult AddUserAnswerView([FromRoute]int questionId)
        {
            var result = new List<UserAnswer>();
            var questions = _surveyService.GetAllQuestions();
            var question = questions.SingleOrDefault(x => x.Id == questionId);
            foreach(var item in question.Answers){
                var userAnswer = new UserAnswer { QuestionId = questionId, UserId = _surveyService.GetUser(User.Identity.Name).Id, Answer = item.Title, Value = false };
                result.Add(userAnswer);
            }
            return View(new UserAnswersPageModel { UserAnswers = result } );
        }

        [Authorize]
        public IActionResult AddItem(Survey component)
        {
            _surveyService.Add(component, User.Identity.Name);
            return Surveys();
        }

        [Authorize]
        public IActionResult AddQuestion(Question component)
        {
            _surveyService.Add(component, User.Identity.Name);
            return Surveys();
        }

        [Authorize]
        public IActionResult AddAnswer(Answer component)
        {
            _surveyService.Add(component, User.Identity.Name);
            return Surveys();
        }

        [HttpPost]
        [Route("Home/ChoiceAnswer")]
        public IActionResult ChoiceAnswer(ICollection<UserAnswer> userAnswers)
        {
            
            _surveyService.AddUserAnswers(userAnswers);
            return UserAnswerView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
