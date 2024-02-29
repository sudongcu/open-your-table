using Microsoft.Extensions.DependencyInjection;
using OpenYourTable.Core.Services;
using OpenYourTable.Infra.Repositories;
using OpenYourTable.Obj.Enums;

namespace OpenYourTable.App.Configs
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection ConfigureDI(this IServiceCollection services)
		{
			services.AddSingleton<DataFetchService>();

			return services;
		}


		public static IServiceCollection ConfigureConnectionDI(this IServiceCollection services, DB_TYPE dbType)
		{
			if (dbType == DB_TYPE.MSSQL)
			{
				services.AddSingleton<IDataRepository, MSSQLRepository>();
			}
			else
			{
				services.AddSingleton<IDataRepository, MySqlRepository>();
			}

			return services;
		}
	}
}
