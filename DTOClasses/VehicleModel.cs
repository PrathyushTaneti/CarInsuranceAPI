namespace BeenFieldAPI.DTOClasses
{
    public class VehicleModel
    {
        public string VehicleModelName { get; set; }

        public string VehicleModelCode { get; set; }

        public VehicleModel(string vehicleModel, string vehicleModelCode)
        {
            VehicleModelName = vehicleModel;
            VehicleModelCode = vehicleModelCode;
        }
    }
}
