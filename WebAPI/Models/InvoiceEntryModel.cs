using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class InvoiceEntryModel
    {
        public int Id { get; set; }
        public int Article { get; set; }
        public string ArticleName { get; set; }
        public int Invoice { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}