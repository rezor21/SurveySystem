using Microsoft.AspNetCore.Identity;
using SurveySystem.Data;
using SurveySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class AuthCommand : ICommand
    {
        private ApplicationDbContext _context;
        private string _userName;
        public AuthCommand(ApplicationDbContext context, string userName)
        {
            _context = context;
            _userName = userName;
        }

        public bool Execute()
        {
            if (_context.Users.Any(x => x.UserName == _userName))
            {
                return true;
            }

            return false;
        }
    }
}
