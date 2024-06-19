using BookStore.Application.DTOs.AuthorModels;
using MediatR;

namespace BookStore.Application.Authors.Queries.SearchAuthor
{
	public class SearchAuthorQuery : IRequest<SearchAuthorsRepresentation>
	{
		public SearchAuthorQuery(string query)
		{
			Query = query;
		}

		public string? Query { get; private set; }
	}
}