using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Data
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
