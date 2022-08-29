namespace BeenFieldAPI.Models
{
    public class DamageThree
    {
        public int? RepairAndReplaceExpense { get; set; }
        public int? PaintingLabourExpense { get; set; }
        public int? NewBodyPartsExpense { get; set; }

        public DamageThree(int param1, int param2, int param3)
        {
            this.RepairAndReplaceExpense = param1;
            this.PaintingLabourExpense = param2;
            this.NewBodyPartsExpense = param3;
        }
    }
}
