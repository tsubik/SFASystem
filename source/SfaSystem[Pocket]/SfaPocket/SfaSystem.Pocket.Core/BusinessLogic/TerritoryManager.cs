using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class TerritoryManager
    {
        private static IList<Territory> territoriesCache = null;
        public static IList<Territory> TerritoriesCache
        {
            get
            {
                if (territoriesCache == null)
                    territoriesCache = GetTerritories();
                return territoriesCache;
            }
        }

        public static IList<Territory> GetSubTerritories(Guid TerritoryID)
        {
            return TerritoriesCache.Where(t => t.ParentTerritoryID == TerritoryID).ToList();
            //return TerritoryDB.GetSubTerritories(TerritoryID);
        }

        public static IList<Territory> GetTerritories()
        {
            return TerritoryDB.GetTerritories();
        }

        public static Territory GetTerritoryByID(Guid territoryID)
        {
            return TerritoryDB.GetTerritoryByID(territoryID);
        }
    }
}
