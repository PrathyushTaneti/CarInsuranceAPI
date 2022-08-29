namespace BeenFieldAPI.Models
{
    public class DamageTwo
    {
        public int LabourExpense { get; set; }

        public int RepairExpense { get; set; }

        public int PaintingExpense { get; set; }

        public DamageTwo(int labourCost, int repairExpense, int damageExpense)
        {
            this.LabourExpense = labourCost;
            this.RepairExpense = repairExpense;
            this.PaintingExpense = damageExpense;
        }
    }
}
