using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using System.Data.Common;
using System.Data;

namespace SFASystem.Pocket.Core.DataAccess
{
    internal class ManufacturerDB
    {
        public static IList<Manufacturer> GetManufacturers()
        {
            string sqlQuery = "SELECT * FROM Manufacturer";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetManufacturerListFromQuery(sqlQuery);
        }

        public static Manufacturer GetManufacturerByID(Guid manufacturerID)
        {
            Manufacturer manufacturer = null;
            if (manufacturerID == Guid.Empty)
                return manufacturer;

            string sqlQuery = "SELECT * FROM MANUFACTURER WHERE ManufacturerID='" + manufacturerID + "'";
            return GetManufacturerFromQuery(sqlQuery);
        }




        #region Helper Methods

        private static IList<Manufacturer> GetManufacturerListFromQuery(string sqlQuery)
        {
            IList<Manufacturer> listManufacturer = new List<Manufacturer>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listManufacturer.Add(GetManufacturerFromReader(dataReader));
                }
            }
            return listManufacturer;
        }

        private static Manufacturer GetManufacturerFromQuery(string sqlQuery)
        {
            Manufacturer manufacturer = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    manufacturer = GetManufacturerFromReader(dataReader);
                }
            }
            return manufacturer;
        }

        private static Manufacturer GetManufacturerFromReader(IDataReader dataReader)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.ManufacturerID = DBHelper.GetGuid(dataReader, "ManufacturerID");
            manufacturer.AddressID = DBHelper.GetGuid(dataReader, "AddressID");
            manufacturer.Name = DBHelper.GetString(dataReader, "Name");
            manufacturer.Description = DBHelper.GetString(dataReader, "Description");
            manufacturer.Email = DBHelper.GetString(dataReader, "Email");
            manufacturer.Phone = DBHelper.GetString(dataReader, "Phone");
          
            return manufacturer;
        }

        #endregion
    }
}
