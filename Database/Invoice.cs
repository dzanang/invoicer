using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Invoice
    {

        public Invoice()
        {
            Entries = new Collection<InvoiceEntry>();
        }

        [Key]
        public int Id { get; set; }
        public virtual Customer BillCustomer { get; set; }
        public virtual Customer ShipCustomer { get; set; }
        public DateTime Date { get; set; }
        public double Tax { get; set; }
        public double Other { get; set; }
        public double Total { get; set; }
        public InvoiceStatus Status { get; set; }
        public virtual ICollection<InvoiceEntry> Entries { get; set; }
    }
}
