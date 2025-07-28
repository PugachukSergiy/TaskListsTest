using tasklists.Contract.Responses;
using tasklists.Entities;

namespace tasklists.BuisnessLogic
{
    public static class ValidationHelper
    {
        public static void ValidateListName(BaseResponse response, string name)
        {
            if(string.IsNullOrEmpty(name))
                response.AddErrorMessage(ErrorMessages.NameLess1Character);
            else if(name.Length > 255) 
                response.AddErrorMessage(ErrorMessages.NameLonger255Character);
        }

        public static void ValidateNotNegativeProperty(BaseResponse response, int propValue, string propName)
        {
            if(propValue < 0)
            {
                response.AddErrorMessage(ErrorMessages.NegativeProperty, propName);
            }
        }

        public static void ValidateOwnershipOrSharing(BaseResponse response, TaskList taskList, int userId)
        {
            if(taskList.OwnerId != userId && (taskList.SharedTo == null || !taskList.SharedTo.Any(x => x.Id == userId)))
            {
                response.AddErrorMessage(ErrorMessages.NoRights);
            }
        }
    }
}
