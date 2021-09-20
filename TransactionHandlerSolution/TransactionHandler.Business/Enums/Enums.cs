using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionHandler.Business.Enums
{
    public enum TransactionStatus
    {
        InProgress = 1,
        Successful = 2,
        Failed = 4,
        Suspended = 8,
        Error = 16,
        Unknown = 32
    }
}
