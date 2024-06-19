using BookStore.Application.DTOs.AuthorModels;
using BookStore.Connectors.OpenLibrary.Client;

namespace BookStore.Application.Authors.Mappers
{
	public static class ResponseMappers
	{
		public static SearchAuthorsRepresentation MapSearchAuthors(SearchAuthorsResult authorsSearchResult)
		{
			var result = new SearchAuthorsRepresentation()
			{
				AuthorsFound = authorsSearchResult.NumFound,
				Authors = authorsSearchResult.Docs.Select(x => new SearchAuthor
				{
					AlternateNames = x.AlternateNames, 
					BirthDate = x.BirthDate,
					DeathDate = x.DeathDate,
					Name = x.Name,
					OpenLibraryId = x.Key,
					TopSubjects = x.TopSubjects,
					TopWork = x.TopWork,
					Type = x.Type,
					WorkCount = x.WorkCount
				}).ToList()
			};

			return result;
		}

		internal static GetAuthorRepresentation MapGetAuthor(GetAuthorResult author)
		{
			var result = new GetAuthorRepresentation()
			{
				AlternateNames = author.AlternateNames,
				Bio = author.Bio,
				BirthDate = author.BirthDate,
				Created = new DTOs.AuthorModels.Timestamp
				{
					Value = author.Created?.Value,
					Type = author.Created?.Type
				}, 
				DeathDate = author.BirthDate,
				LastModified = new DTOs.AuthorModels.Timestamp
				{
					Value = author.LastModified?.Value,
					Type = author.LastModified?.Type
				},
				LatestRevision = author.LatestRevision,
				Name = author.Name,
				OpenLibraryId = author.Key,
				Photos = author.Photos,
				Type = new DTOs.AuthorModels.KeyType
				{
					Key = author.Type?.Key
				},
				RemoteIds = new DTOs.AuthorModels.RemoteIds
				{
					Isni = author.RemoteIds?.Isni,
					Viaf = author.RemoteIds?.Viaf,
					Wikidata = author.RemoteIds?.Wikidata,
					
				},
				Revisions = author.Revisions,
				SourceRecords = author.SourceRecords
			};
			return result;
		}
	}
}