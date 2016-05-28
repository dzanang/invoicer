using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public Customer BillCustomer { get; set; }
        public Customer ShipCustomer { get; set; }
        public DateTime Date { get; set; }
        public double Tax { get; set; }
        public double Other { get; set; }
        public double Total { get; set; }
        public InvoiceStatus Status { get; set; }
        public virtual ICollection<InvoiceEntry> Entries { get; set; }
    }
}
