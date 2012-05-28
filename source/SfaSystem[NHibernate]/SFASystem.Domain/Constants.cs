using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.Domain
{
    public enum OrderStatusEnum : int
    {
        Nowe = 1,
        WRealizacji = 2,
        Wyslano = 3,
        Anulowane = 4
    }

    public class DictionaryTypeNames
    {
        public static readonly string Task = "Status zadania";
        public static readonly string Order = "Status zamówienia";
        public static readonly string FieldCall = "Typ wizyty";
        public static readonly string Tax = "Podatek VAT";
        public static readonly string Invoice = "Status faktury";
    }

    public enum TaskStatusEnum : int
    {
        Nowe = 1,
        Rozpoczete = 2,
        Anulowane = 3,
        Zakonczone = 4
    }

    public enum InvoiceStatusEnum : int
    {
        Niezaplacona = 1,
        Zaplacona = 2
    }


}
