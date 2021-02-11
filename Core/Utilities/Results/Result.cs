using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool _success , string _message):this(_success)
        {
            Message = _message;
        }
        public Result(bool _success)
        {
            Success = _success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
