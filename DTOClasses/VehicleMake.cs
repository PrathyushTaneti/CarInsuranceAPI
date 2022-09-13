namespace BeenFieldAPI.DTOClasses
{
    public class VehicleMake
    {
        public string VehicleMakeName { get; set; }

        public string VehicleMakeCode { get; set; }

        public VehicleMake(string vehicleMake, string vehicleMakeCode)
        {
            VehicleMakeName = vehicleMake;
            VehicleMakeCode = vehicleMakeCode;
        }
    }
}
