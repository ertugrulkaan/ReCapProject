using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string _message) : base(false, _message)
        {
        }
        public ErrorResult() : base(false)
        {

        }
    }
}
