namespace BeenFieldAPI.Models
{
    public class VehicleModel
    {
        public string VehicleModelName { get; set; }

        public string VehicleModelCode { get; set; }

        public VehicleModel(string vehicleModel, string vehicleModelCode)
        {
            this.VehicleModelName = vehicleModel;
            this.VehicleModelCode = vehicleModelCode;
        }
    }
}
