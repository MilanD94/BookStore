using BookStore.Connectors.OpenLibrary.Client;
using Newtonsoft.Json;

namespace BookStore.Application.Services
{
	public class OpenLibraryService : IOpenLibraryService
	{
		private readonly IOpenLibraryServiceGateway _openLibraryServiceGateway;

		public OpenLibraryService(IOpenLibraryServiceGateway openLibraryServiceGateway)
        {
			_openLibraryServiceGateway = openLibraryServiceGateway;
		}
        public async Task<SearchAuthorsResult> SearchAuthors(string? authorName, CancellationToken cancellationToken)
		{
			var authorsResult = await _openLibraryServiceGateway.SearchAuthors_jsonAsync(authorName, cancellationToken);
			var result = MapResult<SearchAuthorsResult>(authorsResult);
			return result;
		}

		public async Task<GetAuthorResult> GetAuthor(string? olid, CancellationToken cancellationToken)
		{
			var author = await _openLibraryServiceGateway.Authors_jsonAsync(olid, cancellationToken);
			var result = MapResult<GetAuthorResult>(author);
			return result;
		}

		private static T MapResult<T>(object input) where T : new()
		{
			var result = new T();
			if (input is null)
			{
				return result;
			}

			var convertedResult = JsonConvert.SerializeObject(input);
			result = JsonConvert.DeserializeObject<T>(convertedResult);

			if (result is null)
			{
				return new T();
			}

			return result;
		}
	}
}
