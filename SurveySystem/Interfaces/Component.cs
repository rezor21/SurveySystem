using SurveySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Interfaces
{
    public interface Component
    {
        public bool Add(ApplicationDbContext context);
        public string Title { get; set; }
        public ICollection<Component> Childs { get; set; }
        public int ParentId { get; set; }
    }
}
