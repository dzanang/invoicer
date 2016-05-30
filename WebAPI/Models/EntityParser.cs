using Database;
//converts models to Database Entries
namespace WebAPI.Models
{
    public class EntityParser
    {
        public Invoice Create(InvoiceModel model, InvoicerContext context)
        {
            Invoice result = new Invoice()
            {
                Id = model.Id,
                BillCustomer = context.Customers.Find(model.BillCustomerId),
                ShipCustomer = context.Customers.Find(model.ShipCustomerId),
                Date = model.Date,
                Other = model.Other,
                Status = model.Status,
                Entries = new System.Collections.Generic.List<InvoiceEntry>()
            };
            double untaxedPrice = 0;
            foreach (var item in model.Entries)
            {
                InvoiceEntry invoiceEntry = Create(item, context, result);
                result.Entries.Add(invoiceEntry);
                untaxedPrice += invoiceEntry.Price;
            }

            //TODO: make tax configurable
            double taxedPrice = untaxedPrice + (untaxedPrice * 0.17);
            result.Total = taxedPrice + result.Other;
            result.Tax = 17;

            return result;
        }

        public Customer Create(CustomerModel model, InvoicerContext context)
        {
            return new Customer()
            {
                Id = model.Id,
                Name = model.Name,
                CompanyName = model.CompanyName,
                Address = model.Address,
                City = model.City,
                ZIP = model.ZIP,
                Phone = model.Phone
            };
        }

        public Company Create(CompanyModel model, InvoicerContext context)
        {
            return new Company()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                ZIP = model.ZIP,
                Phone = model.Phone
            };
        }

        public Article Create(ArticleModel model, InvoicerContext context)
        {
            return new Article()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                InStock = model.InStock
            };
        }

        public InvoiceEntry Create(InvoiceEntryModel model, InvoicerContext context, Invoice invoice)
        {
            InvoiceEntry result = new InvoiceEntry()
            {
                Id = model.Id,
                Article = context.Articles.Find(model.Article),
                Invoice = invoice,
                Quantity = model.Quantity
            };

            result.Price = result.Quantity * result.Article.Price;
            return result;
        }
    }
}