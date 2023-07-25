using MovieApp.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Utilities.Results.Conrete
{
    public class Result : IResult
    {
        public Result(int status, bool success)
        {
            Status = status;
            Success = success;
        }

        public Result(int status, bool success, string message) : this(status, success)
        {
            Message = message;
        }

        public int Status { get; }
        public bool Success { get; }
        public string Message { get; }
    }
}
