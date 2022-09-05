namespace BeenFieldAPI.Models
{
    public class DamageTwo
    {
        public double LabourCost { get; set; }

        public double RepairAndRefitCost { get; set; }

        public double PaintingCost { get; set; }

        public DamageTwo(double labourCost, double repairRefitCost, double paintingCost)
        {
            this.LabourCost = labourCost;
            this.RepairAndRefitCost= repairRefitCost;
            this.PaintingCost = paintingCost;
        }
    }
}
