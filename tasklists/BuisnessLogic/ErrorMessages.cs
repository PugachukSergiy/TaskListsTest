namespace tasklists.BuisnessLogic
{
    public static class ErrorMessages
    {
        public static readonly string TaskListNotFound = "Task list with id:{0} not found.";
        public static readonly string UserNotFound = "User with id:{0} not found.";
        public static readonly string UserIsOwner = "User is owner of the task list.";
        public static readonly string NoRights = "The user does not have rights.";
        public static readonly string AlreadyShared = "Task list is already shared to user.";
        public static readonly string NotShared = "Task list is not shared to user.";
        public static readonly string SelfSharing = "Self sharing attempt.";
        public static readonly string NameLess1Character = "The name must be at least 1 character.";
        public static readonly string NameLonger255Character = "The name must be no longer than 255 characters.";
        public static readonly string NegativeProperty = "Value of {0} can`t be negative";
    }
}
