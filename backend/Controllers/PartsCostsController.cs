using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using PetaPoco;
using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    public class PartsCostsController : ControllerBase
    {
        private IPartsCostService partsCostService;

        public PartsCostsController(IPartsCostService partsCostService)
        {
            this.partsCostService = partsCostService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<PartsCost>> GetAllPartsCosts()
        {
            return this.partsCostService.GetPartsCosts();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<PartsCostUtil>> GetAllPartsDetails()
        {
            return this.partsCostService.Get();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<PartsCost> GetPartsCostById(int id)
        {
            return this.partsCostService.GetPartsCost(id);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult<bool> PutPartsCostById(int id, PartsCost partsCost)
        {
            return this.partsCostService.PutPartsCost(id, partsCost);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> PostPartsCost(PartsCost partsCost)
        {
            return this.partsCostService.PostPartsCost(partsCost);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult<bool> DeletePartsCostBy(int id)
        {
            return this.partsCostService.DeletePartsCost(id);
        }
    }
}
