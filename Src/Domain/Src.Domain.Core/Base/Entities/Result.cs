using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Base.Entities
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Result(bool success,string? message=null)
        {
            Success = success;
            Message = message;
        }
    }
}
