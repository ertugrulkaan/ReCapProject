using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler icin baslangic
    public interface IResult
    {
        //sadece okunabilir read only
        bool Success { get; }
        string Message { get; }

    }
}
