using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class DictionaryManager
    {

        public static Dictionary GetDictionaryByID(Guid dictId)
        {
            return DictionaryDB.GetDictionaryByID(dictId);
        }

        public static IList<Dictionary> GetDictionariesByType(string typeName)
        {
            return DictionaryDB.GetDictionariesByType(typeName);
        }

        public static Dictionary GetDictionaryByEnumAndType(int orderStatusEnum, string typeName )
        {
            return DictionaryDB.GetDictionaryByNumber(orderStatusEnum, typeName);
        }
    }
}
