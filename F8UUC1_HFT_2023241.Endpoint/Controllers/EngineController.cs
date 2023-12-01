using F8UUC1_HFT_2023241.Logic.Interfaces;
using F8UUC1_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F8UUC1_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {

        IEngineLogic engineLogic;

        public EngineController(IEngineLogic engineLogic)
        {
            this.engineLogic = engineLogic;
        }

        // GET: api/<EngineController>
        [HttpGet]
        public IEnumerable<Engine> ReadAll()
        {
            return this.engineLogic.ReadAll();
        }

        // GET api/<EngineController>/5
        [HttpGet("{id}")]
        public Engine Read(int id)
        {
            return engineLogic.Read(id);
        }

        // POST api/<EngineController>
        [HttpPost]
        public void Create([FromBody] Engine value)
        {
            this.engineLogic.Create(value);
        }

        // PUT api/<EngineController>/5
        [HttpPut]
        public void Put([FromBody] Engine value)
        {
            this.engineLogic.Update(value);
        }

        // DELETE api/<EngineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.engineLogic.Delete(id);
        }
    }
}
