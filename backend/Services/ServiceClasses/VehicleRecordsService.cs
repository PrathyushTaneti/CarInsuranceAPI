using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Models;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using PetaPoco;
using IDatabase = PetaPoco.IDatabase;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class VehicleRecordsService : ControllerBase, IVehicleRecordsService
    {
        private IDatabase dbContext;
        private DbAccess dbAccess;
        public VehicleRecordsService()
        {
            this.dbAccess = new DbAccess();
            this.dbContext = this.dbAccess.dbConnection;
        }

        ActionResult<bool> IVehicleRecordsService.DeleteVehicleRecord(int id)
        {
            try
            {
                if (this.IsDetailPresent(id))
                {
                    this.dbContext.Delete<VehicleRecord>(id);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<List<VehicleVariantDTO>> IVehicleRecordsService.Get(string vehicleMakeCode, string vehicleModelCode)
        {
            try
            {
                if (String.IsNullOrEmpty(vehicleMakeCode) || String.IsNullOrEmpty(vehicleModelCode))
                {
                    throw new Exception("Invalid Inputs");
                }

                List<VehicleRecord> vehicleList = this.dbContext.Query<VehicleRecord>("Select * from VehicleRecords where VehicleMakeCode = @0 AND VehicleModelCode = @1", vehicleMakeCode, vehicleModelCode).ToList() ?? new List<VehicleRecord>();
                List<VehicleVariantDTO> resultantList = new List<VehicleVariantDTO>();
                foreach (VehicleRecord vehicle in vehicleList)
                {
                    resultantList.Add(new VehicleVariantDTO(vehicle));
                }
                return resultantList.Count != 0 ? Ok(new ApiResponse(200, "Success", resultantList)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<List<VehicleMake>> IVehicleRecordsService.GetVehicleMake()
        {
            try
            {
                List<VehicleRecord> VehicleMakeListUtil = this.dbContext.Query<VehicleRecord>("select distinct vehicleMake, vehicleMakeCode from VehicleRecords;").ToList() ?? new List<VehicleRecord>();
                List<VehicleMake> vehicleMakeList = new List<VehicleMake>();
                foreach (VehicleRecord vehicle in VehicleMakeListUtil)
                {
                    vehicleMakeList.Add(new VehicleMake(vehicle.VehicleMake, vehicle.VehicleMakeCode!));
                }
                return vehicleMakeList.Count != 0 ? Ok(new ApiResponse(200, "Success", vehicleMakeList)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<List<VehicleModel>> IVehicleRecordsService.GetVehicleModels(int vehicleMakeCode)
        {
            try
            {
                List<VehicleRecord> vehicleRecordsList = this.dbContext.Query<VehicleRecord>("select distinct VehicleModel, VehicleModelCode From VehicleRecords where VehicleMakeCode = @0; ", vehicleMakeCode).ToList() ?? new List<VehicleRecord>();

                List<VehicleModel> vehicleModelList = new List<VehicleModel>();
                foreach (VehicleRecord vehicle in vehicleRecordsList)
                {
                    vehicleModelList.Add(new VehicleModel(vehicle.VehicleModel, vehicle.VehicleModelCode!));
                }
                return vehicleModelList.Count != 0 ? Ok(new ApiResponse(200, "Success", vehicleModelList)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<VehicleRecord> IVehicleRecordsService.GetVehicleRecord(int id)
        {
            try
            {
                VehicleRecord vehicle = this.dbContext.SingleOrDefault<VehicleRecord>("; exec GetAllDetails @@TableName = 'VehicleRecords', @@Id = @0", id);
                return vehicle != null ? Ok(new ApiResponse(200, "Success", vehicle)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<int> IVehicleRecordsService.PostVehicleRecord(VehicleRecord vehicleRecord)
        {
            try
            {
                if (vehicleRecord != null)
                {
                    this.dbContext.Insert(vehicleRecord);
                    return Ok(new ApiResponse(200, "Success", vehicleRecord.Id));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<bool> IVehicleRecordsService.PutVehicleRecord(int id, VehicleRecord vehicleRecord)
        {
            try
            {
                if (this.IsDetailPresent(id) && id == vehicleRecord.Id)
                {
                    this.dbContext.Update(vehicleRecord);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        private bool IsDetailPresent(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return false;
                }
                List<VehicleRecord> list = this.dbContext.Query<VehicleRecord>("; exec GetAllDetails @@TableName = 'VehicleRecords', @@Id = @0", 0).ToList() ?? new List<VehicleRecord>();
                return list.Count != 0 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
