using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class InvoiceModel
    {
        public InvoiceModel()
        {
            Entries = new List<InvoiceEntryModel>();
        }

        public int Id { get; set; }  
        public int BillCustomerId { get; set; }
        public int ShipCustomerId { get; set; }
        public CustomerModel BillCustomer { get; set; }
        public CustomerModel ShipCustomer { get; set; }     
        public DateTime Date { get; set; }
        public double Tax { get; set; }
        public double Other { get; set; }
        public double Total { get; set; }
        public InvoiceStatus Status { get; set; }
        public IList<InvoiceEntryModel> Entries { get; set; }
    }
}