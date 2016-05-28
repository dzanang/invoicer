using Database;
using System;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ArticleController : BaseController<Article>
    {
        public ArticleController(Repository<Article> depo) : base(depo)
        { }
        
        public IHttpActionResult Get()
        {
            try
            {
                var articles = Repository.Get().ToList().Select(x => Factory.Create(x));
                if (articles == null) return NotFound();
                else
                    return Ok(articles);
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
                Article article = Repository.Get(id);
                if (article == null) return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        public IHttpActionResult Post(ArticleModel model)
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
        
        public IHttpActionResult Put(int id, ArticleModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Article article = Repository.Get(id);
                if (article == null || model == null) return NotFound();
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
                Article article = Repository.Get(id);
                if (article == null) return NotFound();
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