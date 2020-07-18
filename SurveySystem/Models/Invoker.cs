using SurveySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class Invoker
    {
        private ICommand _onStart;

        private ICommand _onFinish;

        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }

        public bool Execute()
        {
            var result = false;
            if (this._onStart is ICommand)
            {
                result = this._onStart.Execute();
            }

            if (this._onFinish is ICommand && result == true)
            {
                result = this._onFinish.Execute();
            }

            return result;
        }
    }
}
