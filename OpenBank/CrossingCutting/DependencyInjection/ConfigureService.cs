using Microsoft.Extensions.DependencyInjection;
using OpenBank.Domain.Interfaces.Service;
using OpenBank.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossingCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient< IClientService, ClientService>();
            serviceCollection.AddTransient< IAccountClientService, AccountClientService>();
            serviceCollection.AddTransient< IAgenciaService, AgenciaService>();
            serviceCollection.AddTransient< IAccountService, AccountService>();
            serviceCollection.AddTransient< IMovementService, MovementService>();
        }
    }
}
