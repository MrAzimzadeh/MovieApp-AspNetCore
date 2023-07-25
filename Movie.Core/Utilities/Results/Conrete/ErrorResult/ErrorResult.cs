using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Utilities.Results.Conrete.ErrorResult
{

    public class ErrorResult : Result
    {
        public ErrorResult(int status) : base(status, false)
        {
        }
        public ErrorResult(int status, string message) : base(status, false, message)
        {
        }
    }
}
