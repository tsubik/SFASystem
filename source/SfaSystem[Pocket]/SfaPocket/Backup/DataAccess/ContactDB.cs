using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using SFASystem.Pocket.Core.Common;
using System.Data;

namespace SFASystem.Pocket.Core.DataAccess
{
    class ContactDB
    {
        public static Contact InsertContact(Contact contact)
        {
            string sqlQuery = "INSERT INTO Contact(ContactID,FirstName,LastName,Email,Phone) " +
                " VALUES(@ContactID,@FirstName,@LastName,@Email,@Phone)";

            if (contact.ContactID == Guid.Empty)
                contact.ContactID = Guid.NewGuid();
            else
                return null;
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "ContactID", DbType.Guid, contact.ContactID);
            DBHelper.AddInParameter(dbCommand, "FirstName", DbType.String, contact.FirstName);
            DBHelper.AddInParameter(dbCommand, "LastName", DbType.String, contact.LastName);
            DBHelper.AddInParameter(dbCommand, "Email", DbType.String, contact.Email);
            DBHelper.AddInParameter(dbCommand, "Phone", DbType.String, contact.Phone);
            return contact;
        }

        public static void UpdateContact(Contact contact)
        {
            string sqlQuery = "UPDATE Contact SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone WHERE ContactID='" + contact.ContactID+"'";

            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "FirstName", DbType.String, contact.FirstName);
            DBHelper.AddInParameter(dbCommand, "LastName", DbType.String, contact.LastName);
            DBHelper.AddInParameter(dbCommand, "Email", DbType.String, contact.Email);
            DBHelper.AddInParameter(dbCommand, "Phone", DbType.String, contact.Phone);
            DBHelper.ExecuteNonQuery(dbCommand);
        }

        public static IList<Contact> GetCustomerFacContacts(Guid customerFacilityID)
        {
            if (customerFacilityID == Guid.Empty)
                return new List<Contact>();
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM Contact con ");
            builder.Append("INNER JOIN FacilityContacts faccon ON con.ContactID=faccon.ContactID ");
            builder.Append("JOIN CustomerFacility custfac ON faccon.CustomerFacilityID=custfac.CustomerFacilityID ");
            builder.Append("WHERE custfac.CustomerFacilityID='" + customerFacilityID.ToString() + "'");

            return GetContactListFromQuery(builder.ToString());
        }
        public static IList<Contact> GetCustomerContacts(Guid customerID)
        {
            if (customerID == Guid.Empty)
                return new List<Contact>();
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM Contact con ");
            builder.Append("INNER JOIN FacilityContacts faccon ON con.ContactID=faccon.ContactID ");
            builder.Append("JOIN CustomerFacility custfac ON faccon.CustomerFacilityID=custfac.CustomerFacilityID ");
            builder.Append("JOIN Customer cust ON custfac.CustomerID=cust.CustomerID ");
            builder.Append("WHERE cust.CustomerID='" + customerID.ToString() + "'");

            return GetContactListFromQuery(builder.ToString());
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
            Contact contact = null;
            if (contactID == Guid.Empty)
                return contact;
            string sqlQuery = "SELECT * FROM Contact WHERE ContactID='" + contactID.ToString()+"'";
            return GetContactFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Contact> GetContactListFromQuery(string sqlQuery)
        {
            IList<Contact> listContact = new List<Contact>();
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
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
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
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
            contact.ContactID = DBHelper.GetGuid(dataReader, "ContactID");
            contact.FirstName = DBHelper.GetString(dataReader, "FirstName");
            contact.LastName = DBHelper.GetString(dataReader, "LastName");
            contact.Phone = DBHelper.GetString(dataReader, "Phone");
            contact.Email = DBHelper.GetString(dataReader, "Email");
            return contact;
        }

        #endregion
    }
}
