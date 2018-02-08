using System;
using Autofac;
using Common.Log;

namespace Lykke.Service.Chainalysis_Mock.Client
{
    public static class AutofacExtension
    {
        public static void RegisterChainalysis_MockClient(this ContainerBuilder builder, string serviceUrl, ILog log)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (log == null) throw new ArgumentNullException(nameof(log));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterType<Chainalysis_MockClient>()
                .WithParameter("serviceUrl", serviceUrl)
                .As<IChainalysis_MockClient>()
                .SingleInstance();
        }

        public static void RegisterChainalysis_MockClient(this ContainerBuilder builder, Chainalysis_MockServiceClientSettings settings, ILog log)
        {
            builder.RegisterChainalysis_MockClient(settings?.ServiceUrl, log);
        }
    }
}
