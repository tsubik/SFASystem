using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SFASystem.Core.Common;

namespace SFASystem.Core.DataAccess
{
    public class AddressDB
    {
        public static Address InsertAddress(Address address)
        {
            string sqlQuery = "INSERT INTO Address(CountryID,CityID,Street,ZipCode,HouseNr,ApartmentNr) " +
                " VALUES(@CountryID,@CityID,@Street,@ZipCode,@HouseNr,@ApartmentNr);SELECT @@Identity";

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, address.CountryID);
            db.AddInParameter(dbCommand, "CityID", DbType.Int32, address.CityID);
            db.AddInParameter(dbCommand, "Street", DbType.String, address.Street);
            db.AddInParameter(dbCommand, "ZipCode", DbType.String, address.ZipCode);
            db.AddInParameter(dbCommand, "HouseNr", DbType.String, address.HouseNr);
            db.AddInParameter(dbCommand, "ApartmentNr", DbType.String, address.ApartmentNr);

            address.AddressID = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return address;
        }

        public static void UpdateAddress(Address address)
        {
            string sqlQuery = "UPDATE Address SET CountryID=@CountryID, CityID=@CityID, Street=@Street, ZipCode=@ZipCode, HouseNr=@HouseNr, ApartmentNr=@AparmentNr WHERE AddressID=" + address.AddressID;

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, address.CountryID);
            db.AddInParameter(dbCommand, "CityID", DbType.String, address.City.CityID);
            db.AddInParameter(dbCommand, "Street", DbType.String, address.Street);
            db.AddInParameter(dbCommand, "ZipCode", DbType.String, address.ZipCode);
            db.AddInParameter(dbCommand, "HouseNr", DbType.String, address.HouseNr);
            db.AddInParameter(dbCommand, "ApartmentNr", DbType.String, address.ApartmentNr);
            db.AddInParameter(dbCommand, "AddressID", DbType.Int32, address.AddressID);

            db.ExecuteNonQuery(dbCommand);
        }

        //public static bool DeleteAddress(int addressID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE AddressID = " + addressID.ToString();
        //    Database db = new SqlDatabase(DBHelper.GetConnectionString());
        //    DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
        //    if (db.ExecuteNonQuery(dbCommand) > 0)
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


        public static Address GetAddressByID(int addressID)
        {
            Address address = null;
            if (addressID == 0)
                return address;
            string sqlQuery = "SELECT * FROM Address WHERE AddressID=" + addressID;
            return GetAddressFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Address> GetAddressListFromQuery(string sqlQuery)
        {
            IList<Address> listAddress = new List<Address>();
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
            address.AddressID = DBHelper.GetInt(dataReader, "AddressID");
            address.ZipCode = DBHelper.GetString(dataReader, "ZipCode");
            address.Street = DBHelper.GetString(dataReader, "Street");
            address.HouseNr = DBHelper.GetString(dataReader, "HouseNr");
            address.ApartmentNr = DBHelper.GetString(dataReader, "ApartmentNr");
            //address.City = DBHelper.GetString(dataReader, "City");
            address.CityID = DBHelper.GetInt(dataReader, "CityID");
            address.CountryID = DBHelper.GetInt(dataReader, "CountryID");
           

            return address;
        }

        #endregion

    }
}
