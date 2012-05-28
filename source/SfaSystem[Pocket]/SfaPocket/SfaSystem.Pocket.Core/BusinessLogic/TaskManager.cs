using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class TaskManager
    {
        public static void UpdateTask(Task task)
        {
            task.DateModified = DateTime.Now;
            TaskDB.UpdateTask(task);
        }

        public static IList<Task> GetTaskList()
        {
            return TaskDB.GetTasks();
        }

        public static IList<Task> GetTasks(Guid taskStatusID, Guid assignedToID)
        {
            return TaskDB.GetTasks(taskStatusID,assignedToID);
        }

        public static Task GetTaskByID(Guid taskID)
        {
            return TaskDB.GetTaskByID(taskID);
        }
    }
}
