using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.Core.DataAccess
{
    public class AddressDB
    {
        public static Address InsertAddress(Address address)
        {
            string sqlQuery = "INSERT INTO Address(AddressID,CountryID,CityID,Street,ZipCode,HouseNr,ApartmentNr) " +
                " VALUES(@AddressID,@CountryID,@CityID,@Street,@ZipCode,@HouseNr,@ApartmentNr)";
            if (address.AddressID == Guid.Empty)
                address.AddressID = Guid.NewGuid();
            else
                return null;
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "AddressID", DbType.Guid, address.AddressID);
            DBHelper.AddInParameter(dbCommand, "CountryID", DbType.Guid, address.CountryID);
            DBHelper.AddInParameter(dbCommand, "CityID", DbType.Guid, address.CityID);
            DBHelper.AddInParameter(dbCommand, "Street", DbType.String, address.Street);
            DBHelper.AddInParameter(dbCommand, "ZipCode", DbType.String, address.ZipCode);
            DBHelper.AddInParameter(dbCommand, "HouseNr", DbType.String, address.HouseNr);
            DBHelper.AddInParameter(dbCommand, "ApartmentNr", DbType.String, address.ApartmentNr);
            return address;
        }

        public static void UpdateAddress(Address address)
        {
            string sqlQuery = "UPDATE Address SET CountryID=@CountryID, CityID=@CityID, Street=@Street, ZipCode=@ZipCode, HouseNr=@HouseNr, ApartmentNr=@AparmentNr WHERE AddressID=@AddressID";

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "AddressID", DbType.Guid, address.AddressID);
            DBHelper.AddInParameter(dbCommand, "CountryID", DbType.Guid, address.CountryID);
            DBHelper.AddInParameter(dbCommand, "CityID", DbType.Guid, address.CityID);
            DBHelper.AddInParameter(dbCommand, "Street", DbType.String, address.Street);
            DBHelper.AddInParameter(dbCommand, "ZipCode", DbType.String, address.ZipCode);
            DBHelper.AddInParameter(dbCommand, "HouseNr", DbType.String, address.HouseNr);
            DBHelper.AddInParameter(dbCommand, "ApartmentNr", DbType.String, address.ApartmentNr);

            DBHelper.ExecuteNonQuery(dbCommand);
        }

        //public static bool DeleteAddress(int addressID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE AddressID = " + addressID.ToString();
        //    
        //    DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
        //    if (DBHelper.ExecuteNonQuery(dbCommand) > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //public static IList<Address> GetAddress(bool onlyActive)
        //{
        //    string sqlQuery = "SELECT * FROM EMPLOYEE";
        //    if (onlyActive)
        //        sqlQuery += " WHERE Active=1";
        //    return GetAddressListFromQuery(sqlQuery);
        //}


        public static Address GetAddressByID(Guid addressID)
        {
            Address address = null;
            if (addressID == Guid.Empty)
                return address;
            string sqlQuery = "SELECT * FROM Address WHERE AddressID='" + addressID+"'";
            return GetAddressFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Address> GetAddressListFromQuery(string sqlQuery)
        {
            IList<Address> listAddress = new List<Address>();
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listAddress.Add(GetAddressFromReader(dataReader));
                }
            }
            return listAddress;
        }

        private static Address GetAddressFromQuery(string sqlQuery)
        {
            Address address = null;
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    address = GetAddressFromReader(dataReader);
                }
            }
            return address;
        }

        private static Address GetAddressFromReader(IDataReader dataReader)
        {
            Address address = new Address();
            address.AddressID = DBHelper.GetGuid(dataReader, "AddressID");
            address.ZipCode = DBHelper.GetString(dataReader, "ZipCode");
            address.Street = DBHelper.GetString(dataReader, "Street");
            address.HouseNr = DBHelper.GetString(dataReader, "HouseNr");
            address.ApartmentNr = DBHelper.GetString(dataReader, "ApartmentNr");
            //address.City = DBHelper.GetString(dataReader, "City");
            address.CityID = DBHelper.GetGuid(dataReader, "CityID");
            address.CountryID = DBHelper.GetGuid(dataReader, "CountryID");
            return address;
        }

        #endregion

    }
}
