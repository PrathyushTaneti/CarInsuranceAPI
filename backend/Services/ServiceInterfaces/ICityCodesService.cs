using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface ICityCodesService
    {
        internal ActionResult<CityCodes> GetAllCityCodes();
    }
}
