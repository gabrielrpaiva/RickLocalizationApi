using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Api.Response
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; } = true;

        public IEnumerable<object> Errors { get; set; } = null;
    }
}
