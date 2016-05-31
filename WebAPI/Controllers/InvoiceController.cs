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
        private Repository<InvoiceEntry> invoiceRepo;
        private Repository<Article> articleRepo;
        public InvoiceController(Repository<Invoice> depo, Repository<InvoiceEntry> invoiceRepo, Repository<Article> articleRepo) : base(depo)
        {
            this.invoiceRepo = invoiceRepo;
            this.articleRepo = articleRepo;
        }

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

                    foreach (var entry in invoice.Entries)
                    {
                        entry.Article.InStock = entry.Article.InStock - entry.Quantity;

                        if (entry.Article.InStock < 0) {
                            return BadRequest();
                        }

                        articleRepo.Update(entry.Article, entry.Article.Id);
                    }
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
                    var toDelete = new List<int>();
                    foreach (var entry in invoice.Entries)
                    {
                        toDelete.Add(entry.Id);
                        entry.Article.InStock = entry.Article.InStock + entry.Quantity;
                        articleRepo.Update(entry.Article, entry.Article.Id);                  
                    }
                    foreach(var entryId in toDelete)
                    {
                        invoiceRepo.Delete(entryId);
                    }
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
