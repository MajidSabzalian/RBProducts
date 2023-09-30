using RBProducts.Common.Interfaces;

namespace RBProducts.Common.Models
{
    public class OperationResultDto<T> : IOperationResult
    {
        public OperationResultDto()
        {

        }
        public static OperationResultDto<T> FailException(Exception ex)
        {
            return new OperationResultDto<T>() { IsSuccess = false, Message = ex.Message };
        }
        public static OperationResultDto<T> Fail(string message)
        {
            return new OperationResultDto<T>() { IsSuccess = false, Message = message };
        }
        public static OperationResultDto<T> Fail(T result, string message)
        {
            return new OperationResultDto<T>() { IsSuccess = true, Result = result, Message = message };
        }
        public static OperationResultDto<T> Success()
        {
            return new OperationResultDto<T>() { IsSuccess = true };
        }
        public static OperationResultDto<T> Success(T result)
        {
            return new OperationResultDto<T>() { IsSuccess = true, Result = result };
        }
        public T Result { get; set; }
        public bool IsSuccess { set; get; }
        public string Message { set; get; }

    }
}
