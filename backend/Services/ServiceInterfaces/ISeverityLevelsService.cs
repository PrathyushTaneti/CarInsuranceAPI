using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface ISeverityLevelsService
    {
        internal ActionResult<List<SeverityLevel>> Get();
    }
}
