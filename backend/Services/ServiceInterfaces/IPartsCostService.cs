using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface IPartsCostService
    {
        internal ActionResult<List<PartsCost>> GetPartsCosts();

        internal ActionResult<List<PartsCostUtil>> Get();

        internal ActionResult<PartsCost> GetPartsCost(int id);

        internal ActionResult<bool> PutPartsCost(int id, PartsCost partsCost);

        internal ActionResult<int> PostPartsCost(PartsCost partsCost);

        internal ActionResult<bool> DeletePartsCost(int id);
    }
}
