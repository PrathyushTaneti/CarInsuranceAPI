namespace BeenFieldAPI.Models
{
    public class PartsCostUtil
    {
        public string BodyPart { get; set; }

        public int BodyPartId { get; set; }

        public PartsCostUtil(string bodyPart, int bodyPartId)
        {
            this.BodyPart = bodyPart;
            this.BodyPartId = bodyPartId;
        }
    }
}
