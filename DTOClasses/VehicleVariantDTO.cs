using BeenFieldAPI.Models;

namespace BeenFieldAPI.DTOClasses
{
    public class VehicleVariantDTO
    {
       
        public string? VehicleVariant { get; set; }

        public string VehicleVariantCode { get; set; }

        public VehicleVariantDTO(VehicleRecord vehicle)
        {
            this.VehicleVariant = vehicle.VehicleVariant;
            this.VehicleVariantCode = vehicle.VehicleVariantCode;
        }
    }
}
