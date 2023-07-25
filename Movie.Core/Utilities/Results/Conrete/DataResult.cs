using MovieApp.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Utilities.Results.Conrete
{
    public class DataResult<TResult> : Result, IDataResult<TResult>
    {
        public DataResult(TResult data, bool success, int status) : base(status, success)
        {
            Data = data;
        }
        public DataResult(TResult data, bool success, string message, int status) : base(status, success, message)
        {
            Data = data;
        }

        public TResult Data { get; }
    }
}
