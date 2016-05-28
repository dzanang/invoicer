using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class InvoiceEntry
    {
        public int Id { get; set; }
        public Article Article { get; set; }
        public Invoice Invoice { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
