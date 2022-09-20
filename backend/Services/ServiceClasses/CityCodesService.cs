using BeenFieldAPI.Services.ServiceInterfaces;
using PetaPoco;
using BeenFieldAPI.Models;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class CityCodesService : ControllerBase, ICityCodesService
    {
        private readonly IDatabase dbContext;

        private DbAccess dbAccess;

        public CityCodesService()
        {
            this.dbAccess = new DbAccess();
            this.dbContext = this.dbAccess.dbConnection;
        }

        ActionResult<CityCodes> ICityCodesService.GetAllCityCodes()
        {
            try
            {
                List<CityCodes> cityCodeList = this.dbContext.Query<CityCodes>("; exec GetAllDetails @@TableName = 'CityCodes', @@Id = @0",0).ToList() ?? new List<CityCodes>() ?? new List<CityCodes>();
                return (cityCodeList.Count == 0) ? StatusCode(204,new ApiResponse(204,"Success","No Content")) :
                Ok(new ApiResponse(200,"Success",cityCodeList));
            }
            catch(Exception e)
            {
                return StatusCode(500,new ApiResponse(500,"Error",e.StackTrace!.ToString()));
            }
        }
    }
}
