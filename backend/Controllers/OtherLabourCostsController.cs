using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using PetaPoco;
using BeenFieldAPI.Services.ServiceClasses;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    public class OtherLabourCostsController : ControllerBase
    {
        private readonly IOtherLabourService otherLabourService;

        public OtherLabourCostsController(IOtherLabourService otherLabourService)
        {
            this.otherLabourService = otherLabourService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<OtherLabourCost>> GetAllOtherLabourCostDetails()
        {
            return this.otherLabourService.GetOtherLabourCosts();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<OtherLabourCost> GetOtherLabourCostById(int id)
        {
            return this.otherLabourService.GetOtherLabourCost(id);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult<bool> PutOtherLabourCost(int id, OtherLabourCost otherLabourCost)
        {
            return this.otherLabourService.PutOtherLabourCost(id,otherLabourCost);
         }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> PostOtherLabourCost(OtherLabourCost otherLabourCost)
        {
            return this.otherLabourService.PostOtherLabourCost(otherLabourCost);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult<bool> DeleteOtherLabourCostById(int id)
        {
            return this.otherLabourService.DeleteOtherLabourCost(id);
        }
    }
}
