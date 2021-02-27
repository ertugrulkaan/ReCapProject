using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                // params ile gonderilen is kurali basarisiz ise dondurulur
                // ilk hatada doner eger hepsini dondurmek istersek list dondururuz
                //List<IResult> errorResults = new List<IResult>();
                if (!logic.Success)
                {
                    //errorResult.Add(logic);
                    return logic;
                }
            }
            //return errorResult;
            return null;
        }
    }
}
