using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string _message):base(true,_message)
        {
        }
        public SuccessResult():base(true)
        {

        }
    }
}
