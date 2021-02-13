using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResults<T> : DataResult<T>
    {
        public ErrorDataResults(T data, string messages) : base(data, false, messages)
        {

        }

        public ErrorDataResults(T data) : base(data, false)
        {

        }

        public ErrorDataResults(string messages) : base(default, false, messages)
        {

        }

        public ErrorDataResults() : base(default, false)
        {

        }
    }
}
