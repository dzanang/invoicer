using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class InvoiceController : BaseController<Invoice>
    {
        public InvoiceController(Repository<Invoice> depo) : base(depo)
        { }

        public IHttpActionResult Get()
        {
            try
            {
                var invoices = Repository.Get().ToList().Select(x => Factory.Create(x));
                if (invoices == null)
                {
                    return NotFound();
                }
                else
                { 
                    return Ok(invoices);
                }
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
                Invoice invoice = Repository.Get(id);
                if (invoice == null)
                {
                    return NotFound();
                }
                else
                { 
                    return Ok(Factory.Create(Repository.Get(id)));
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(InvoiceModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                else
                {
                    Invoice invoice = Parser.Create(model, sch);
                    Repository.Insert(invoice);
                    return Ok(Factory.Create(invoice));                 
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        public IHttpActionResult Put(int id, InvoiceModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Invoice invoice = Repository.Get(id);
                if (invoice == null || model == null)
                {
                    return NotFound();
                }
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
                Invoice invoice = Repository.Get(id);
                if (invoice == null)
                {
                    return NotFound();
                }
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
