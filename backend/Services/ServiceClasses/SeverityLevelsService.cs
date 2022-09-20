using BeenFieldAPI.Models;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using IDatabase = PetaPoco.IDatabase;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class SeverityLevelsService : ControllerBase, ISeverityLevelsService
    {
        private readonly IDatabase dbContext;
        private DbAccess dbAccess;
        public SeverityLevelsService()
        {
            this.dbAccess = new DbAccess();
            this.dbContext = this.dbAccess.dbConnection;
        }

        ActionResult<List<SeverityLevel>> ISeverityLevelsService.Get()
        {
            try
            {
                List<SeverityLevel> list = this.dbContext.Query<SeverityLevel>("; exec GetAllDetails @@TableName = 'SeverityLevel', @@Id = @0",0).ToList() ?? new List<SeverityLevel>();
                return list.Count != 0 ? Ok(new ApiResponse(200, "Success", list)) : StatusCode(204, new ApiResponse(
                    204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }
    }
}
