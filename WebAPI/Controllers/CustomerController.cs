using Database;
using System;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CustomerController : BaseController<Customer>
    {
        public CustomerController(Repository<Customer> depo) : base(depo)
        { }
        
        public IHttpActionResult Get()
        {
            try
            {
                var customers = Repository.Get().ToList().Select(x => Factory.Create(x));
                if (customers == null) return NotFound();
                else
                    return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        public IHttpActionResult Get(int id)
        {
            try
            {
                Customer customer = Repository.Get(id);
                if (customer == null) return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        public IHttpActionResult Post(CustomerModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                if (model == null) return NotFound();
                else
                {
                    Repository.Insert(Parser.Create(model, sch));
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        
        public IHttpActionResult Put(int id, CustomerModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Customer customer = Repository.Get(id);
                if (customer == null || model == null) return NotFound();
                else
                {
                    Repository.Update(Parser.Create(model, sch), id);
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Customer customer = Repository.Get(id);
                if (customer == null) return NotFound();
                else
                {
                    Repository.Delete(id);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}