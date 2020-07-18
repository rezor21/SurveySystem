﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Data
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
