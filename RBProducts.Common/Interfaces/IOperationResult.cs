using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBProducts.Common.Interfaces
{
    public interface IOperationResult
    {
        bool IsSuccess { set; get; }
        string Message { set; get; }
    }
}
