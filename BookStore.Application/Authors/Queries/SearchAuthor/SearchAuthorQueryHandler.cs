using BookStore.Application.Authors.Mappers;
using BookStore.Application.DTOs.AuthorModels;
using BookStore.Application.Services;
using MediatR;

namespace BookStore.Application.Authors.Queries.SearchAuthor
{
	public class SearchAuthorQueryHandler : IRequestHandler<SearchAuthorQuery, SearchAuthorsRepresentation>
    {
        private readonly IOpenLibraryService _openLibraryService;
        public SearchAuthorQueryHandler(IOpenLibraryService openLibraryService)
        {
            _openLibraryService = openLibraryService;
        }

        public async Task<SearchAuthorsRepresentation> Handle(SearchAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _openLibraryService.SearchAuthors(request.Query, cancellationToken);

            var result = ResponseMappers.MapSearchAuthors(authors);

            return result;
        }
    }
}