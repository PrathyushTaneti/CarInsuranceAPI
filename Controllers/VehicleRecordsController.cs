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

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class VehicleRecordsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public VehicleRecordsController()
        {
            dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<VehicleMake> GetVehicleMake()
        {
            try
            {
                List<VehicleRecord> VehicleMakeListUtil = this.dbContext.Query<VehicleRecord>("select distinct vehicleMake, vehicleMakeCode from VehicleRecords;").ToList() ?? new List<VehicleRecord>();
                List<VehicleMake> vehicleMakeList = new List<VehicleMake>();
                foreach (VehicleRecord vehicle in VehicleMakeListUtil)
                {
                    vehicleMakeList.Add(new VehicleMake(vehicle.VehicleMake, vehicle.VehicleMakeCode));
                }
                return vehicleMakeList;
            }
            catch (Exception e)
            {
                return new List<VehicleMake>();
            }
        }


        [HttpGet]
        [Route("{id}")]
        public VehicleRecord GetVehicleRecord(int id)
        {
            try
            {
                return this.dbContext.SingleOrDefault<VehicleRecord>("Select * from VehicleRecords where Id = @0", id);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        [HttpGet]
        [Route("vehicleMake")]
        public List<VehicleModel> GetVehicleModel(string vehicleMake)
        {
            try
            {
                List<VehicleRecord> vehicleRecordsList = this.dbContext.Query<VehicleRecord>("select distinct VehicleModel, VehicleModelCode From VehicleRecords where VehicleMake = @0; ", vehicleMake).ToList() ?? new List<VehicleRecord>();

                List<VehicleModel> vehicleModelList = new List<VehicleModel>();
                foreach (VehicleRecord vehicle in vehicleRecordsList)
                {
                    vehicleModelList.Add(new VehicleModel(vehicle.VehicleModel, vehicle.VehicleModelCode));
                }
                return vehicleModelList;
            }
            catch (Exception e)
            {
                return new List<VehicleModel>();
            }
        }



        [HttpPut]
        [Route("{id}")]
        public bool PutVehicleRecord(int id, VehicleRecord vehicleRecord)
        {
            if (id == vehicleRecord.Id)
            {
                try
                {
                    this.dbContext.Update(vehicleRecord);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }


        [HttpPost]
        public int PostVehicleRecord(VehicleRecord vehicleRecord)
        {
            if (vehicleRecord != null)
            {
                try
                {
                    this.dbContext.Insert(vehicleRecord);
                    return vehicleRecord.Id;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
            return -1;
        }


        [HttpDelete]
        [Route("{id}")]
        public bool DeleteVehicleRecord(int id)
        {
            if (this.GetVehicleRecord(id) != null)
            {
                try
                {
                    this.dbContext.Delete(id);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        [HttpGet]
        [Route("{vehicleMake}/{vehicleModel}")]
        public List<VehicleVariantDTO> Get(string vehicleMake, string vehicleModel)
        {
            try
            {
                if (String.IsNullOrEmpty(vehicleMake) || String.IsNullOrEmpty(vehicleModel))
                {
                    throw new Exception("Invalid Inputs");
                }

                List<VehicleRecord> vehicleList = this.dbContext.Query<VehicleRecord>("Select * from VehicleRecords where VehicleMake = @0 AND VehicleModel = @1", vehicleMake, vehicleModel).ToList() ?? new List<VehicleRecord>();
                List<VehicleVariantDTO> resultantList = new List<VehicleVariantDTO>();
                foreach (VehicleRecord vehicle in vehicleList)
                {
                    resultantList.Add(new VehicleVariantDTO(vehicle));
                }
                return resultantList;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
