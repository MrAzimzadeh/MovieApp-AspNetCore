using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Utilities.Results.Abstract
{
    public interface IDataResult<TResult> : IResult
    {
        TResult Data { get; }
    }
}
