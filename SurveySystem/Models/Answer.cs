using SurveySystem.Data;
using SurveySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class Answer : Component
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public ICollection<Component> Childs { get; set; }

        public bool Add(Data.ApplicationDbContext context)
        {
            if(context.Answers.Any(x => x.QuestionId == this.ParentId && x.Title == this.Title))
            {
                return false;
            }
            try
            {
                
                var answer = new Data.Answer { Title = this.Title, QuestionId = this.ParentId };
                
                context.Answers.Add(answer);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
