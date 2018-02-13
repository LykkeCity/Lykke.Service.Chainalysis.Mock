using Autofac;
using Autofac.Extensions.DependencyInjection;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Service.ChainalysisMock.AzureRepositories.Repositories;
using Lykke.Service.ChainalysisMock.AzureRepositories.Tables;
using Lykke.Service.ChainalysisMock.Core.Repositories;
using Lykke.Service.ChainalysisMock.Core.Services;
using Lykke.Service.ChainalysisMock.Core.Settings.ServiceSettings;
using Lykke.Service.ChainalysisMock.Services;
using Lykke.SettingsReader;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.ChainalysisMock.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<ChainalysisMockSettings> _settings;
        private readonly IReloadingManager<DbSettings> _dbSettings;
        private readonly ILog _log;
        // NOTE: you can remove it if you don't need to use IServiceCollection extensions to register service specific dependencies
        private readonly IServiceCollection _services;


        public ServiceModule(IReloadingManager<ChainalysisMockSettings> settings, ILog log)
        {
            _settings = settings;
            _dbSettings = settings.Nested(x => x.Db);
            _log = log;

            _services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
            LoadRepositories(builder);
            LoadServices(builder);

            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            // TODO: Add your dependencies here

           

            builder.Populate(_services);
        }

        private void LoadServices(ContainerBuilder builder)
        {
            var addressRepository = new ChainalysisMockUserAddressRepository(
                AzureTableStorage<MockUserAddress>.Create(_dbSettings.ConnectionString(x => x.DataConnString),
                    "MockUserAddress", _log));
            var transactionRepository = new ChainalysisMockUserTransfersRepository(
                AzureTableStorage<MockUserTransactions>.Create(_dbSettings.ConnectionString(x => x.DataConnString),
                    "MockUserTransactions", _log));
            var commentRepository = new ChainalysisMockUserCommentsRepository(
                AzureTableStorage<MockUserComment>.Create(_dbSettings.ConnectionString(x => x.DataConnString),
                    "MockUserComment", _log));
            var userRepository = new ChainalysisMockUserRepository(
                AzureTableStorage<MockUser>.Create(_dbSettings.ConnectionString(x => x.DataConnString),
                    "MockUser", _log), addressRepository, transactionRepository);
            builder.RegisterInstance<IChainalysisMockUserAddressRepository>(addressRepository);
            builder.RegisterInstance<IChainalysisMockUserTransfersRepository>(transactionRepository);
            builder.RegisterInstance<IChainalysisMockUserCommentsRepository>(commentRepository);
            builder.RegisterInstance<IChainalysisMockUserRepository>(userRepository);
        }

        private void LoadRepositories(ContainerBuilder builder)
        {

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

        }
    }
}
