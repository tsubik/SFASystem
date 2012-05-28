using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Core.Common;
using SFASystem.Core.DataAccess;

namespace SFASystem.Core.BusinessLogic
{
    public class ContactManager
    {
        public static Contact InsertContact(Contact contact)
        {
            return ContactDB.InsertContact(contact);
        }

        public static void UpdateContact(Contact contact)
        {
            ContactDB.UpdateContact(contact);
        }

        //public static bool DeleteContact(int contactID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE ContactID = " + contactID.ToString();
        //    Database db = new SqlDatabase(DBHelper.GetConnectionString());
        //    DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
        //    if (db.ExecuteNonQuery(dbCommand) > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //public static IList<Contact> GetContact(bool onlyActive)
        //{
        //    string sqlQuery = "SELECT * FROM EMPLOYEE";
        //    if (onlyActive)
        //        sqlQuery += " WHERE Active=1";
        //    return GetContactListFromQuery(sqlQuery);
        //}

        public static Contact GetContactByID(int contactID)
        {
            return ContactDB.GetContactByID(contactID);
        }

    }
}
