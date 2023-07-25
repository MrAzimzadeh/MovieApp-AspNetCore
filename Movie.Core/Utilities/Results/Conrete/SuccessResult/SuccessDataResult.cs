using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Utilities.Results.Conrete.SuccessResult
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(int status) : base(data: default, success: true, status: status)
        {
        }
        public SuccessDataResult(T data, int status) : base(data, true, status: status)
        {
        }
        public SuccessDataResult(string message, int status) : base(default, true, message, status: status)
        {
        }
        public SuccessDataResult(T data, string message, int status) : base(data, true, message, status: status)
        {
        }
    }
}
