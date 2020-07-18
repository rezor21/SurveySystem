using SurveySystem.Interfaces;
using SurveySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class CheckCommand : ICommand
    {
        private SurveyService _receiver;
        private string title;
        private string type;

        public CheckCommand(SurveyService receiver, string surveyTitle, string type)
        {
            this._receiver = receiver;
            this.title = surveyTitle;
            this.type = type;
        }

        public bool Execute()
        {
            if(type == "Survey")
            {
                if (_receiver.GetAll().Any(x => x.Title == title))
                {
                    return true;
                }
            }

            if (type == "Question")
            {
                if (_receiver.GetAllQuestions().Any(x => x.Title == title))
                {
                    return true;
                }
            }

            if (type == "Answer")
            {
                if (_receiver.GetAllAnswers().Any(x => x.Title == title))
                {
                    return true;
                }
            }

            return false;
           
        }
    }
}
