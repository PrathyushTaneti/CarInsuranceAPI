using BeenFieldAPI.Models;

namespace BeenFieldAPI.DTOClasses
{
    public class PaintCodesDTO
    {
        public string? Paint { get; set; }

        public int PaintId { get; set; }

        public PaintCodesDTO(PaintingCost paint)
        {
            this.Paint = paint.Paint;
            this.PaintId = paint.PaintId;
        }
    }
}
