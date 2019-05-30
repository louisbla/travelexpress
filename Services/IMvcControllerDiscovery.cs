using System.Collections.Generic;
using Garderie.Models;

namespace Garderie.Services
{
    public interface IMvcControllerDiscovery
    {
        IEnumerable<MvcControllerInfo> GetControllers();
    }
}