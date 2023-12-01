using F8UUC1_HFT_2023241.Logic.Interfaces;
using F8UUC1_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F8UUC1_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        ICarLogic carLogic;

        public CarController(ICarLogic carLogic)
        {
            this.carLogic = carLogic;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> ReadAll()
        {
            return this.carLogic.ReadAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Read(int id)
        {
            return carLogic.Read(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Create([FromBody] Car value)
        {
            this.carLogic.Create(value);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public void Put([FromBody] Car value)
        {
            this.carLogic.Update(value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.carLogic.Delete(id);
        }
    }
}
