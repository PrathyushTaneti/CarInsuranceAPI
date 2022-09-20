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
using System.Reflection.Metadata.Ecma335;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Authorization;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    public class VehicleRecordsController : ControllerBase
    {
        private IVehicleRecordsService vehicleRecordsService;

        public VehicleRecordsController(IVehicleRecordsService vehicleRecordsService)
        {
            this.vehicleRecordsService = vehicleRecordsService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<VehicleMake>> GetAllVehicleMakeRecords()
        {
            return this.vehicleRecordsService.GetVehicleMake();
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<VehicleRecord> GetVehicleRecordById(int id)
        {
            return this.vehicleRecordsService.GetVehicleRecord(id);
        }


        [HttpGet]
        [Route("[action]/{vehicleMakeCode}")]
        public ActionResult<List<VehicleModel>> GetAllVehicleModelRecords(int vehicleMakeCode)
        {
            return this.vehicleRecordsService.GetVehicleModels(vehicleMakeCode);
        }



        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult<bool> PutVehicleRecord(int id, VehicleRecord vehicleRecord)
        {
            return this.vehicleRecordsService.PutVehicleRecord(id, vehicleRecord);
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> PostVehicleRecord(VehicleRecord vehicleRecord)
        {
            return this.vehicleRecordsService.PostVehicleRecord(vehicleRecord);
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult<bool> DeleteVehicleRecordById(int id)
        {
            return this.vehicleRecordsService.DeleteVehicleRecord(id);
        }

        [HttpGet]
        [Route("[action]/{vehicleMakeCode}/{vehicleModelCode}")]
        public ActionResult<List<VehicleVariantDTO>> GetAllVehicleVariants(string vehicleMakeCode, string vehicleModelCode)
        {
            return this.vehicleRecordsService.Get(vehicleMakeCode, vehicleModelCode);
        }
    }
}
