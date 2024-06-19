using BookStore.Connectors.OpenLibrary.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Connectors.OpenLibrary.Extensions
{
	public static class ServiceCollectionExtensions
	{
		private const string ClientName = "openLibraryHttpClient";

		public static IServiceCollection AddOpenLibraryGateway(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddHttpClient<IOpenLibraryServiceGateway, OpenLibraryServiceGateway>(ClientName, client =>
				{
					ConfigureHttpClient(client);
				});
			return services;
		}

		private static void ConfigureHttpClient(HttpClient client)
		{
			var baseAddress = "https://openlibrary.org/";
			client.BaseAddress = new Uri(baseAddress);
		}
	}
}