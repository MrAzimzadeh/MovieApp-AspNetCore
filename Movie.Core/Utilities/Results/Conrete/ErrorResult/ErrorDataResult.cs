using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Utilities.Results.Conrete.ErrorResult
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(int status) : base(default, false, status)
        {
        }
        public ErrorDataResult(T data, int status) : base(data, false, status)
        {
        }
        public ErrorDataResult(string message, int status) : base(default, false, message, status)
        {
        }
        public ErrorDataResult(T data, string message, int status) : base(data, false, message, status: status)
        {
        }
    }
}
