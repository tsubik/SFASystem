using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.BusinessLogic
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
        //    
        //    DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
        //    if (DBHelper.ExecuteNonQuery(dbCommand) > 0)
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

        public static Contact GetContactByID(Guid contactID)
        {
            return ContactDB.GetContactByID(contactID);
        }

    }
}
