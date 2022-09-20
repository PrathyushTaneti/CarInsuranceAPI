using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using PetaPoco;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    public class RepairRefitCostsController : ControllerBase
    {
        private IRepairRefitCostService repairRefitCostService;

        public RepairRefitCostsController(IRepairRefitCostService repairRefitCostService)
        {
            this.repairRefitCostService = repairRefitCostService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<RepairRefitCost>> GetAllRepairAndRefitCosts()
        {
            return this.repairRefitCostService.GetRepairRefitCosts();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<RepairRefitCost> GetRepairAndRefitCostById(int id)
        {
            return this.repairRefitCostService.GetRepairRefitCost(id);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult<bool> PutRepairAndRefitCost(int id, RepairRefitCost repairRefitCost)
        {
            return this.repairRefitCostService.PutRepairRefitCost(id, repairRefitCost);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> PostRepairAndRefitCost(RepairRefitCost repairRefitCost)
        {
            return this.repairRefitCostService.PostRepairRefitCost(repairRefitCost);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult<bool> DeleteRepairAndRefitCostById(int id)
        {
            return this.repairRefitCostService.DeleteRepairRefitCost(id);
        }
    }
}
