using Microsoft.Extensions.DependencyInjection;
using OpenYourTable.Core.Services;
using OpenYourTable.Infra.Repositories;

namespace OpenYourTable.App.Configs
{
	public static class DIConfig
	{
		public static IServiceCollection ConfigureDI(this IServiceCollection services)
		{
			services.AddSingleton<DataFetchService>();

			services.AddSingleton<DataRepository>();

			return services;
		}
	}
}
