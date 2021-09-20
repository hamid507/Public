using System;
using System.Collections.Generic;
using System.Text;
using TransactionHandler.Business.Enums;

namespace TransactionHandler.Business.Models
{
    public class TransactionModel
    {
        public Guid ID { get; set; }
        public bool IsActive { get; set; }
        public TransactionStatus StatusId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
