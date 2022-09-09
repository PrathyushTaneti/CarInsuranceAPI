namespace BeenFieldAPI.Models
{
    public class DamageThree
    {
        public double? RepairAndReplaceExpense { get; set; }
        public double? PaintingLabourExpense { get; set; }
        public double? NewBodyPartsExpense { get; set; }

        public DamageThree(double param1, double param2, double param3)
        {
            this.RepairAndReplaceExpense = param1;
            this.PaintingLabourExpense = param2;
            this.NewBodyPartsExpense = param3;
        }
    }
}
