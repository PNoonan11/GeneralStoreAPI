using System;
using System.Collections.Generic;

namespace GeneralStoreAPI.Models
{
    public class Transaction
    {
        public void SetDateTimeForTrans()
        {
            DateOfTransaction = DateTime.Now;
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? Quantity { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;

    }
}
