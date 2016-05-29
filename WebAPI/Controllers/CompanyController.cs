using Database;
using System;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CompanyController : BaseController<Company>
    {
        public CompanyController(Repository<Company> depo) : base(depo)
        { }

        public IHttpActionResult Get()
        {
            try
            {
                var companies = Repository.Get().ToList().Select(x => Factory.Create(x));
                if (companies == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(companies);
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
                Company company = Repository.Get(id);
                if (company == null)
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

        public IHttpActionResult Post(CompanyModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                if (model == null)
                {
                    return NotFound();
                }
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

        public IHttpActionResult Put(int id, CompanyModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Company company = Repository.Get(id);
                if (company == null || model == null)
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
                Company company = Repository.Get(id);
                if (company == null)
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