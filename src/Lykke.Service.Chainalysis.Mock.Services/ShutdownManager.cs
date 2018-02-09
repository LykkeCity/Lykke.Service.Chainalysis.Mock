﻿using System.Threading.Tasks;
using Common.Log;
using Lykke.Service.ChainalysisMock.Core.Services;

namespace Lykke.Service.ChainalysisMock.Services
{
    // NOTE: Sometimes, shutdown process should be expressed explicitly. 
    // If this is your case, use this class to manage shutdown.
    // For example, sometimes some state should be saved only after all incoming message processing and 
    // all periodical handler was stopped, and so on.

    public class ShutdownManager : IShutdownManager
    {
        private readonly ILog _log;

        public ShutdownManager(ILog log)
        {
            _log = log;
        }

        public async Task StopAsync()
        {
            await _log.WriteInfoAsync("Lykke.Service.ChainalysisMock", "Service Stoped", "");
            await Task.CompletedTask;
        }
    }
}
