using F8UUC1_HFT_2023241.Logic;
using F8UUC1_HFT_2023241.Logic.Interfaces;
using F8UUC1_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F8UUC1_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        ICarLogic logic;

        public NonCrudController(ICarLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<CarBrand> BiggestDisplacementByBrand()
        {
            var a = this.logic.BiggestDisplacementByBrand();
            return a;
        }

        [HttpGet]
        public IEnumerable<CarBrand> NewestCarByBrand()
        {
            return this.logic.NewestCarByBrand();
        }

        [HttpGet]
        public IEnumerable<CarBrand> OldestCarByBrand()
        {
            return this.logic.OldestCarByBrand();
        }

        [HttpGet]
        public IEnumerable<CarBrand> CarBrandDisplacement()
        {
            return this.logic.CarBrandDisplacement();
        }

        [HttpGet("{minDisplacement}")]
        public IEnumerable<CarBrand> CarBrandMinDisplacement(int minDisplacement)
        {
            return this.logic.CarBrandMinDisplacement(minDisplacement);
        }

        



    }
}
