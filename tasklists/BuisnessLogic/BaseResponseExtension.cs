using tasklists.Contract;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic
{
    public static class BaseResponseExtension
    {
        public static void AddErrorMessage(this BaseResponse response, string message, params object?[] arg)
        {
            response.Status = ResponseStatus.ERROR;
            response.ErrorMessages.Add(string.Format(message, arg));
        }
    }
}
