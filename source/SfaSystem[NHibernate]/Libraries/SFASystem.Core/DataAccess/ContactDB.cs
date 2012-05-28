using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SFASystem.Core.Common;
using System.Data;

namespace SFASystem.Core.DataAccess
{
    class ContactDB
    {
        public static Contact InsertContact(Contact contact)
        {
            string sqlQuery = "INSERT INTO Contact(FirstName,LastName,Email,Phone) " +
                " VALUES(@FirstName,@LastName,@Email,@Phone);SELECT @@Identity";

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "FirstName", DbType.String, contact.FirstName);
            db.AddInParameter(dbCommand, "LastName", DbType.String, contact.LastName);
            db.AddInParameter(dbCommand, "Email", DbType.String, contact.Email);
            db.AddInParameter(dbCommand, "Phone", DbType.String, contact.Phone);
           
            contact.ContactID = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return contact;
        }

        public static void UpdateContact(Contact contact)
        {
            string sqlQuery = "UPDATE Contact SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone WHERE ContactID=" + contact.ContactID;

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "FirstName", DbType.String, contact.FirstName);
            db.AddInParameter(dbCommand, "LastName", DbType.String, contact.LastName);
            db.AddInParameter(dbCommand, "Email", DbType.String, contact.Email);
            db.AddInParameter(dbCommand, "Phone", DbType.String, contact.Phone);
            db.ExecuteNonQuery(dbCommand);
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
            Contact contact = null;
            if (contactID == 0)
                return contact;
            string sqlQuery = "SELECT * FROM Contact WHERE ContactID=" + contactID.ToString();
            return GetContactFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Contact> GetContactListFromQuery(string sqlQuery)
        {
            IList<Contact> listContact = new List<Contact>();
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listContact.Add(GetContactFromReader(dataReader));
                }
            }
            return listContact;
        }

        private static Contact GetContactFromQuery(string sqlQuery)
        {
            Contact contact = null;
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    contact = GetContactFromReader(dataReader);
                }
            }
            return contact;
        }

        private static Contact GetContactFromReader(IDataReader dataReader)
        {
            Contact contact = new Contact();
            contact.ContactID = DBHelper.GetInt(dataReader, "ContactID");
            contact.FirstName = DBHelper.GetString(dataReader, "FirstName");
            contact.LastName = DBHelper.GetString(dataReader, "LastName");
            contact.Phone = DBHelper.GetString(dataReader, "Phone");
            contact.Email = DBHelper.GetString(dataReader, "Email");
            return contact;
        }

        #endregion
    }
}
