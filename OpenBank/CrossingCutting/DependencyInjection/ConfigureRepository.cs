using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenBank.Domain.Interfaces;
using OpenBank.Infra.Data.Context;
using OpenBank.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossingCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IClientService, ClientService>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server=LSEIXAS;Database=openBankAPI;User Id=sa;Password=@dmin123")
                );

        }
    }
}
