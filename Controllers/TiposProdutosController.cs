using Microsoft.AspNetCore.Mvc;
using softstoreapi.DAO;
using softstoreapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace softstoreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposProdutosController
    {
        [HttpGet]
        public IEnumerable<TipoProduto> Get([FromServices] TipoProdutoDAO dao)
        {
            return dao.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TipoProduto Get([FromServices] TipoProdutoDAO dao, int id)
        {
            return dao.Get(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<TipoProduto> Post([FromServices] TipoProdutoDAO dao, 
                                          [FromBody]TipoProduto value)
        {
            try{
                return dao.Add(value);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        [HttpPost("addimposto")]
        public ActionResult<TipoProdutoImposto> AddImposto([FromServices] TipoProdutoDAO dao,
                                                            [FromBody]TipoProdutoImposto value)
        {
            try
            {
                return dao.AddImposto(value);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(400);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<TipoProduto> Put([FromServices] TipoProdutoDAO dao, 
                                         [FromBody] TipoProduto value)
        {
            try{
                return dao.Update(value);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromServices] TipoProdutoDAO dao, int id)
        {
            try{
                dao.Delete(id);
                return new StatusCodeResult(200);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        [HttpPost("removeimposto")]
        public ActionResult RemoveImposto([FromServices] TipoProdutoDAO dao, 
                                          [FromBody] TipoProdutoImposto value )
        {
            try
            {
                dao.RemoveImposto(value);
                return new StatusCodeResult(200);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(400);
            }
        }

    }
}