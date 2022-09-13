using Microsoft.Build.Framework;

namespace BeenFieldAPI.DTOClasses
{
    public class PartsCostUtil
    {

        public string BodyPart { get; set; }

        public int BodyPartId { get; set; }

        public PartsCostUtil(string bodyPart, int bodyPartId)
        {
            BodyPart = bodyPart;
            BodyPartId = bodyPartId;
        }
    }
}
