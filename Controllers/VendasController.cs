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
    public class VendasController
    {
        [HttpGet]
        public ActionResult<IEnumerable<Venda>> Get([FromServices] VendaDAO dao)
        {
            try
            {
                return dao.Get().ToList();
            }
            catch (Exception e) {
                return new StatusCodeResult(400);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Venda> Get([FromServices] VendaDAO dao, int id)
        {
            try
            {
                return dao.Get(id);
            }
            catch (Exception e) {
                return new StatusCodeResult(400);
            }
            
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Venda> Post([FromServices] VendaDAO dao, 
                                          [FromBody]Venda value)
        {
            try{
                return dao.Add(value);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<Venda> Put([FromServices] VendaDAO dao, 
                                         [FromBody] Venda value)
        {
            try{
                return dao.Update(value);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromServices] VendaDAO dao, int id)
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