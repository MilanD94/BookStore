using BookStore.Application.DTOs.AuthorModels;
using MediatR;

namespace BookStore.Application.Authors.Queries.GetAuthor
{
	public class GetAuthorQuery : IRequest<GetAuthorRepresentation>
	{
		public GetAuthorQuery(string openLibraryId)
		{
			OpenLibraryId = openLibraryId;
		}

		public string? OpenLibraryId { get; set; }
	}
}