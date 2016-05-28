﻿using System.Data.Entity;
using System.Reflection.Emit;

namespace Database
{
    public class InvoicerContext : DbContext
    {

        public InvoicerContext() : base() 

        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceEntry> InvoiceEntries { get; set; }
    }
}