using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MovieApp.Core.Utilities.Results.Abstract;
using MovieApp.Core.Utilities.Results.Conrete.ErrorResult;
using MovieApp.Core.Utilities.Results.Conrete.SuccessResult;

namespace Movie.Core.Utilities.Bussiness
{
    public class BussinessRoles
    {
        public static IResult Check(params IResult[] logic)
        {
            foreach (var res in logic)
            {
                if (!res.Success)
                {
                    return new ErrorResult(406);
                }
            }
            return new SuccessResult(200);
        }
    }
}