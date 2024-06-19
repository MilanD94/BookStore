using BookStore.Application.Authors.Mappers;
using BookStore.Application.DTOs.AuthorModels;
using BookStore.Application.Services;
using MediatR;

namespace BookStore.Application.Authors.Queries.GetAuthor;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, GetAuthorRepresentation>
{
	private readonly IOpenLibraryService _openLibraryService;

	public GetAuthorQueryHandler(IOpenLibraryService openLibraryService)
	{
		_openLibraryService = openLibraryService;
	}
	public async Task<GetAuthorRepresentation> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
	{
		var author = await _openLibraryService.GetAuthor(request.OpenLibraryId, cancellationToken);

		var result = ResponseMappers.MapGetAuthor(author);

		return result;
	}
}
