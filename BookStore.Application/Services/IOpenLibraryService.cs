using BookStore.Connectors.OpenLibrary.Client;

namespace BookStore.Application.Services
{
	public interface IOpenLibraryService
	{
		public Task<SearchAuthorsResult> SearchAuthors(string? authorName, CancellationToken cancellationToken);
		public Task<GetAuthorResult> GetAuthor(string? olid, CancellationToken cancellationToken);
	}
}
