using System;
using Common.Log;

namespace Lykke.Service.ChainalysisMock.Client
{
    public class ChainalysisMockClient : IChainalysisMockClient, IDisposable
    {
        private readonly ILog _log;

        public ChainalysisMockClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
