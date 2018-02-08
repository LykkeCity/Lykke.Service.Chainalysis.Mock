using System;
using Common.Log;

namespace Lykke.Service.Chainalysis_Mock.Client
{
    public class Chainalysis_MockClient : IChainalysis_MockClient, IDisposable
    {
        private readonly ILog _log;

        public Chainalysis_MockClient(string serviceUrl, ILog log)
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
