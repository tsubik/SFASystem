using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Core.Common;
using SFASystem.Core.DataAccess;

namespace SFASystem.Core.BusinessLogic
{
    public class TerritoryManager
    {
        public static Territory InsertTerritory(Territory territory)
        {
            return TerritoryDB.InsertTerritory(territory);
        }

        public static void UpdateTerritory(Territory territory)
        {
            TerritoryDB.UpdateTerritory(territory);
        }

        public static IList<Territory> GetTerritories()
        {
            return TerritoryDB.GetTerritories();
        }

        public static Territory GetTerritoryByID(int territoryID)
        {
            return TerritoryDB.GetTerritoryByID(territoryID);
        }
    }
}
