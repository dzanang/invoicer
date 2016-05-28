using Database;

namespace WebAPI.Models
{
    public class EntityParser
    {
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
    }
}