using BeenFieldAPI.Models;

namespace BeenFieldAPI.DTOClasses
{
    public class Damage
    {
        public double LabourExpense { get; set; }

        public double RepairAndRefitCost { get; set; }

        public double PaintingCost { get; set; }

        public double NewBodyPartsExpense { get; set; }

        public Damage(double labourExpense, double repairRefitCost, double paintingCost,double param3)
        {
            LabourExpense = labourExpense;
            RepairAndRefitCost = repairRefitCost;
            PaintingCost = paintingCost;
            NewBodyPartsExpense = param3;
        }
    }
}
