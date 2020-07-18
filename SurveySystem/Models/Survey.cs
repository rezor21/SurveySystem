using SurveySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class Survey : Component
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public ICollection<Component> Childs { get; set; }

        public bool Add( Data.ApplicationDbContext context)
        {
            try
            {
               
                var survey = new Data.Survey { Title = this.Title};

                context.Surveys.Add(survey);
                context.SaveChanges();

                if(this.Childs != null)
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
