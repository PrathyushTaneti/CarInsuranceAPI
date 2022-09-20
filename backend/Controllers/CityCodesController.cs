using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using Microsoft.EntityFrameworkCore.Storage;
using PetaPoco;
using IDatabase = PetaPoco.IDatabase;
using Database = PetaPoco.Database;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;
using System.Web.Helpers;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    public class CityCodesController : ControllerBase
    {
        private ICityCodesService cityCodes;

        public CityCodesController(ICityCodesService cityCodes)
        {
            this.cityCodes = cityCodes;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<CityCodes> GetAllCities()
        {
            return this.cityCodes.GetAllCityCodes();
        }
    }
}
