using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    public class EnvController:ControllerBase
    {
        private readonly CloudFoundryInfo _cloudFoundryInfo;
        [HttpGet("/env")]
        public CloudFoundryInfo Get() => _cloudFoundryInfo;
        public EnvController(CloudFoundryInfo cloudFoundryInfo)
        {
            _cloudFoundryInfo = cloudFoundryInfo;
        } 
    }
}