using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    public class DamageController : ControllerBase
    {
        private readonly IDamageService damage;

        public DamageController(IDamageService damage)
        {
            this.damage = damage;
        }

        [HttpGet]
        [Route("[action]/{bodyPartId}/{severity}/{cityName}")]
        public ActionResult<Damage> GetMinorRepairCost(int bodyPartId, string severity, string cityName)
        {
            return this.damage.GetMinorCost(bodyPartId, severity, cityName);
        }

        [HttpGet]
        [Route("[action]/{vehicleMakeCode}/{vehicleModelCode}/{vehicleVariantCode}/{bodyPartId}/{severity}/{panelId}/{cityName}/{paintId}")]
        public ActionResult<Damage> GetMajorRepairCost(string vehicleMakeCode, string vehicleModelCode, string vehicleVariantCode, int bodyPartId, string severity, int panelId, string cityName,int paintId)
        {
            return this.damage.GetMajorCost(vehicleMakeCode, vehicleModelCode, vehicleVariantCode, bodyPartId, severity, panelId, cityName, paintId);
        }

        [HttpGet]
        [Route("[action]/{vehicleMakeCode}/{vehicleModelCode}/{vehicleVariantCode}/{bodyPartId}/{panelId}/{cityName}/{paintId}")]
        public ActionResult<Damage> GetReplacementCost(string vehicleMakeCode, string vehicleModelCode, string vehicleVariantCode, int bodyPartId, int panelId, string cityName, int paintId)
        {
            return this.damage.GetReplacementCost(vehicleMakeCode, vehicleModelCode, vehicleVariantCode, bodyPartId, panelId, cityName, paintId);
        }
    }
}
