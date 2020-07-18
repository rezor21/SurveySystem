using SurveySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class Question : Component
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public ICollection<Component> Childs { get; set; }

        public bool Add(Data.ApplicationDbContext context)
        {
            try
            {

                var question = new Data.Question { Title = this.Title, SurveyId = this.ParentId };
                
                context.Questions.Add(question);
                context.SaveChanges();

                if (this.Childs != null)
                    foreach (var child in this.Childs)
                    {
                        child.Add(context);
                    }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
