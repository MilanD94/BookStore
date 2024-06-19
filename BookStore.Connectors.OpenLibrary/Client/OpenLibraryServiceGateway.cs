namespace BookStore.Connectors.OpenLibrary.Client
{
	public class OpenLibraryServiceGateway : OpenLibraryClient, IOpenLibraryServiceGateway
	{
		public OpenLibraryServiceGateway(HttpClient httpClient)
			: base(httpClient)
		{
			httpClient.DefaultRequestHeaders.Add("test", "test");
		}
	}
}
