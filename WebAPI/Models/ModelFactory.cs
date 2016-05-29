using System;
using System.Linq;
using Database;
//returns data from Database and converts it to models
namespace WebAPI.Models
{
    public class ModelFactory
    {
        public CustomerModel Create(Customer cust)
        {
            return new CustomerModel()
            {
                Id = cust.Id,
                Name = cust.Name,
                CompanyName = cust.CompanyName,
                Address =cust.Address,
                City = cust.City,
                ZIP = cust.ZIP,
                Phone = cust.Phone
            };
        }

        public CompanyModel Create (Company comp)
        {
            return new CompanyModel()
            {
                Id = comp.Id,
                Name = comp.Name,
                Address = comp.Address,
                City = comp.City,
                ZIP = comp.ZIP,
                Phone = comp.Phone
            };            
        }

        public ArticleModel Create(Article art)
        {
            return new ArticleModel()
            {
                Id = art.Id,
                Name = art.Name,
                Price = art.Price,
                InStock = art.InStock
            };
        }

        public InvoiceModel Create(Invoice inv)
        {
            InvoiceModel model = new InvoiceModel()
            {
                Id = inv.Id,
                Date = inv.Date,
                Tax = inv.Tax,
                Other = inv.Other,
                Total = inv.Total,
                Status = inv.Status,
                BillCustomer = Create(inv.BillCustomer),
                ShipCustomer = Create(inv.ShipCustomer)
            };
            foreach(var invoice in inv.Entries)
            {
                model.Entries.Add(new InvoiceEntryModel()
                {
                    Id = invoice.Id,
                    Article = invoice.Article.Id,
                    ArticleName = invoice.Article.Name,
                    Invoice = invoice.Invoice.Id,
                    Quantity = invoice.Quantity,
                    Price = invoice.Price
                });
            }
            return model;
        }
    }
}