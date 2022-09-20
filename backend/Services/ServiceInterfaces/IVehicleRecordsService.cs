using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface IVehicleRecordsService
    {
        internal ActionResult<List<VehicleMake>> GetVehicleMake();

        internal ActionResult<VehicleRecord> GetVehicleRecord(int id);

        internal ActionResult<List<VehicleModel>> GetVehicleModels(int vehicleMakeCode);

        internal ActionResult<bool> PutVehicleRecord(int id, VehicleRecord vehicleRecord);

        internal ActionResult<int> PostVehicleRecord(VehicleRecord vehicleRecord);

        internal ActionResult<bool> DeleteVehicleRecord(int id);

        internal ActionResult<List<VehicleVariantDTO>> Get(string vehicleMake, string vehicleModel);
    }
}
