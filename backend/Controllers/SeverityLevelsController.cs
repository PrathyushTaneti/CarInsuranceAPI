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
using Microsoft.AspNetCore.Authorization;


namespace BeenFieldAPI.Controllers
{
    
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    //[Authorize]
    public class SeverityLevelsController : ControllerBase
    {
        private ISeverityLevelsService severityLevelsService;

        public SeverityLevelsController(ISeverityLevelsService severityLevelsService)
        {
            this.severityLevelsService = severityLevelsService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<SeverityLevel>> GetAllSeverityLevels()
        {
            return this.severityLevelsService.Get();
        }
    }
}
