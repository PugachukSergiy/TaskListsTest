using DTO = tasklists.Contract.DTO;
using Model = tasklists.Entities;

namespace tasklists.BuisnessLogic.Helpers
{
    public static class MappingHelper
    {
        public static DTO.TaskList MapToDTO(this Model.TaskList taskList)
        {
            return new DTO.TaskList()
            {
                Id = taskList.Id,
                Name = taskList.Name,
                CreationDateTime = taskList.CreationDateTime,
                OwnerId = taskList.OwnerId,
            };
        }

        public static DTO.TaskListPreview MapToDTOPreview(this Model.TaskList taskList)
        {
            return new DTO.TaskListPreview()
            {
                Id = taskList.Id,
                Name = taskList.Name,
            };
        }

        public static DTO.User MapToDTOPreview(this Model.User taskList)
        {
            return new DTO.User()
            {
                Id = taskList.Id,
                Name = taskList.Name,
            };
        }

        public static IEnumerable<DTO.TaskListPreview> MapToDTOPreviews(this IEnumerable<Model.TaskList> taskLists)
        {
            return taskLists.Select(x => x.MapToDTOPreview());
        }

        public static IEnumerable<DTO.User> MapToDTOPreviews(this IEnumerable<Model.User> taskLists)
        {
            return taskLists.Select(x => x.MapToDTOPreview());
        }

        public static void ApplyPropertiesFromDTO(this Model.TaskList targetTaskList, DTO.TaskList sourceTaskList)
        {
            targetTaskList.Name = sourceTaskList.Name;
        }
    }
}
