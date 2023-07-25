using MovieApp.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Utilities.Results.Conrete.SuccessResult
{
    public class SuccessResult : Result
    {
        public SuccessResult(int statues) : base(statues, true)
        {

        }
        public SuccessResult(int status, string message) : base(status, true, message)
        {
        }
    }
}
