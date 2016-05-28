using System;
using System.Linq;
using Database;

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
    }
}