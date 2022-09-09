namespace BeenFieldAPI.Models
{
    public class VehicleMake
    {
        public string VehicleMakeName { get; set; }

        public string VehicleMakeCode { get; set; }

        public VehicleMake(string vehicleMake, string vehicleMakeCode)
        {
            this.VehicleMakeName = vehicleMake;
            this.VehicleMakeCode = vehicleMakeCode;
        }
    }
}
