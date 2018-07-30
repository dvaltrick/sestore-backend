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
    public class ProdutosController
    {
        [HttpGet]
        public IEnumerable<Produto> Get([FromServices] ProdutoDAO dao)
        {
            return dao.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Produto Get([FromServices] ProdutoDAO dao, int id)
        {
            return dao.Get(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Produto> Post([FromServices] ProdutoDAO dao, 
                                          [FromBody]Produto value)
        {
            try{
                return dao.Add(value);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<Produto> Put([FromServices] ProdutoDAO dao, 
                                         [FromBody] Produto value)
        {
            try{
                return dao.Update(value);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromServices] ProdutoDAO dao, int id)
        {
            try{
                dao.Delete(id);
                return new StatusCodeResult(200);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }   
    }
}