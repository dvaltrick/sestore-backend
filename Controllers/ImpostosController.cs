﻿using Microsoft.AspNetCore.Mvc;
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
    public class ImpostosController
    {
        [HttpGet]
        public IEnumerable<Imposto> Get([FromServices] ImpostoDAO dao)
        {
            return dao.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Imposto Get([FromServices] ImpostoDAO dao, int id)
        {
            return dao.Get(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Imposto> Post([FromServices] ImpostoDAO dao, 
                                          [FromBody]Imposto value)
        {
            try{
                return dao.Add(value);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<Imposto> Put([FromServices] ImpostoDAO dao, 
                                         [FromBody] Imposto value)
        {
            try{
                return dao.Update(value);
            }catch(Exception e){
                return new StatusCodeResult(400);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromServices] ImpostoDAO dao, int id)
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