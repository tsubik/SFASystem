using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using System.Data.Common;
using SFASystem.Pocket.Core.DataAccess;
using System.Data;

namespace SFASystem.Pocket.Core.DataAccess
{
    public class TaskDB
    {
        public static IList<Task> GetTasks()
        {
            string sqlQuery = "SELECT * FROM Task";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetTaskListFromQuery(sqlQuery);
        }

        public static IList<Task> GetTasks(Guid taskStatusID, Guid assignedTo)
        {
            string sqlQuery = "SELECT * FROM Task ";
            bool needAnd = false;
            bool isWhere = false;
            if (assignedTo != Guid.Empty)
            {
                sqlQuery += " WHERE AssignedTo='" + assignedTo.ToString() + "'";
                isWhere = true;
                needAnd = true;
            }
            if (taskStatusID != Guid.Empty)
            {
                if (!isWhere)
                    sqlQuery += " WHERE ";
                if (needAnd)
                    sqlQuery += " AND ";
                sqlQuery += " TaskStatus='" + taskStatusID + "'";
                isWhere = true;
                needAnd = true;
            }
            return GetTaskListFromQuery(sqlQuery);
        }

        public static Task GetTaskByID(Guid taskID)
        {
            Task task = null;
            if (taskID == Guid.Empty)
                return task;

            string sqlQuery = "SELECT * FROM Task WHERE TaskID='" + taskID + "'";
            return GetTaskFromQuery(sqlQuery);
        }

        internal static void UpdateTask(Task task)
        {
            if (task == null)
                return;
            if (task.TaskID == Guid.Empty)
                return;
            string sqlQuery = "UPDATE Task SET Name=@Name, CreatedBy=@CreatedBy, AssignedTo=@AssignedTo, " +
                "GivenBy=@GivenBy, ApprovedBy=@ApprovedBy, FullDescription=@FullDescription, " +
                "DateCreated=@DateCreated, DateModified=@DateModified, DateExecuted=@DateExecuted, " +
                "DateToEndTask=@DateToEndTask, IsApproved=@IsApproved, TaskStatus=@TaskStatus WHERE TaskID=@TaskID";

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "TaskID", DbType.Guid, task.TaskID);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, task.Name);
            DBHelper.AddInParameter(dbCommand, "CreatedBy", DbType.Guid, task.CreatedByID);
            DBHelper.AddInParameter(dbCommand, "AssignedTo", DbType.Guid, task.AssignedToID);
            DBHelper.AddInParameter(dbCommand, "GivenBy", DbType.Guid, task.GivenByID);
            if(task.ApprovedByID != Guid.Empty)
                DBHelper.AddInParameter(dbCommand, "ApprovedBy", DbType.Guid, task.ApprovedByID);
            else
                DBHelper.AddInParameter(dbCommand, "ApprovedBy", DbType.Guid, DBNull.Value);
            DBHelper.AddInParameter(dbCommand, "FullDescription", DbType.String, task.FullDescription);
            DBHelper.AddInParameter(dbCommand, "DateCreated", DbType.DateTime, task.DateCreated);
            DBHelper.AddInParameter(dbCommand, "DateModified", DbType.DateTime, task.DateModified);
            if(task.DateExecuted.HasValue)
                DBHelper.AddInParameter(dbCommand, "DateExecuted", DbType.DateTime, task.DateExecuted);
            else
                DBHelper.AddInParameter(dbCommand, "DateExecuted", DbType.DateTime, DBNull.Value);
            DBHelper.AddInParameter(dbCommand, "DateToEndTask", DbType.DateTime, task.DateToEndTask);
            DBHelper.AddInParameter(dbCommand, "IsApproved", DbType.Boolean, task.IsApproved);
            DBHelper.AddInParameter(dbCommand, "TaskStatus", DbType.Guid, task.TaskStatusID);
            DBHelper.ExecuteNonQuery(dbCommand);
        }


        #region Helper Methods

        private static IList<Task> GetTaskListFromQuery(string sqlQuery)
        {
            IList<Task> listTask = new List<Task>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listTask.Add(GetTaskFromReader(dataReader));
                }
            }
            return listTask;
        }

        private static Task GetTaskFromQuery(string sqlQuery)
        {
            Task task = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    task = GetTaskFromReader(dataReader);
                }
            }
            return task;
        }

        private static Task GetTaskFromReader(IDataReader dataReader)
        {
            Task task = new Task();
            task.TaskID = DBHelper.GetGuid(dataReader, "TaskID");
            task.Name = DBHelper.GetString(dataReader, "Name");
            task.CreatedByID = DBHelper.GetGuid(dataReader, "CreatedBy");
            task.AssignedToID = DBHelper.GetGuid(dataReader, "AssignedTo");
            task.GivenByID = DBHelper.GetGuid(dataReader, "GivenBy");
            task.ApprovedByID = DBHelper.GetGuid(dataReader, "ApprovedBy");
            task.FullDescription = DBHelper.GetString(dataReader, "FullDescription");
            task.DateCreated = DBHelper.GetDateTime(dataReader, "DateCreated");
            task.DateModified = DBHelper.GetNullableDateTime(dataReader, "DateModified");
            task.DateExecuted = DBHelper.GetNullableDateTime(dataReader, "DateExecuted");
            task.DateToEndTask = DBHelper.GetNullableDateTime(dataReader, "DateToEndTask");
            task.IsApproved = DBHelper.GetBoolean(dataReader, "IsApproved");
            task.TaskStatusID = DBHelper.GetGuid(dataReader, "TaskStatus");
            return task;
        }

        #endregion

      
    }
}
