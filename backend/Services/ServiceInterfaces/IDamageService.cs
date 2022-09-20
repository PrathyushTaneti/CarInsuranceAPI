using BeenFieldAPI.DTOClasses;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface IDamageService
    {
        internal ActionResult<Damage> GetMinorCost(int bodyPartId, string severity, string cityName);

        internal ActionResult<Damage> GetMajorCost(string vehicleMakeCode, string vehicleModelCode, string vehicleVariantCode, int bodyPartId, string severity, int panelId, string cityName, int paintId);

        internal ActionResult<Damage> GetReplacementCost(string vehicleMakeCode, string vehicleModelCode, string vehicleVariantCode, int bodyPartId, int panelId, string cityName, int paintId);
    }
}
