using BookStore.Application.Authors.Queries.GetAuthor;
using BookStore.Application.Authors.Queries.SearchAuthor;
using BookStore.Application.DTOs.AuthorModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
	[ApiController]
	[Route("author")]
	public class AuthorsController(IMediator mediator) : ControllerBase
	{
		private readonly IMediator _mediator = mediator;

		[HttpGet]
		[Route("search/{author-name}")]
		[ProducesResponseType(typeof(SearchAuthorsRepresentation), StatusCodes.Status200OK)]
		public async Task<SearchAuthorsRepresentation> Search([FromRoute(Name = "author-name")]string authorName)
		{
			var result = await _mediator.Send(new SearchAuthorQuery(authorName));
			return result;
		}

		[HttpGet]
		[Route("{open-library-id}")]
		[ProducesResponseType(typeof(GetAuthorRepresentation), StatusCodes.Status200OK)]
		public async Task<GetAuthorRepresentation> GetAuthor([FromRoute(Name = "open-library-id")]string openLibraryId)
		{
			var result = await _mediator.Send(new GetAuthorQuery(openLibraryId));
			return result;
		}
	}
}