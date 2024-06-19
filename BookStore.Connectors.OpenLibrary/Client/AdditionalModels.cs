namespace BookStore.Connectors.OpenLibrary.Client
{
	public class SearchAuthorsResult
	{
		public int? NumFound { get; set; }
		public int? Start { get; set; }
		public bool? NumFoundExact { get; set; }
		public List<SearchAuthorResult> Docs { get; set; } = new List<SearchAuthorResult>();
	}

	public class AuthorBase
	{
		[Newtonsoft.Json.JsonProperty("alternate_names", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<string> AlternateNames { get; set; } = new List<string>();
		[Newtonsoft.Json.JsonProperty("birth_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string? BirthDate { get; set; }
		[Newtonsoft.Json.JsonProperty("death_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string? DeathDate { get; set; }
		public string? Key { get; set; }
		public string? Name { get; set; }
	}

	public class SearchAuthorResult : AuthorBase
	{
		[Newtonsoft.Json.JsonProperty("top_subjects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<string> TopSubjects { get; set; } = new List<string>();
		[Newtonsoft.Json.JsonProperty("top_work", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string? TopWork { get; set; }
		public string? Type { get; set; }
		[Newtonsoft.Json.JsonProperty("work_count", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? WorkCount { get; set; }
	}

	public class GetAuthorResult : AuthorBase
	{
		public List<int> Photos { get; set; } = new();

		[Newtonsoft.Json.JsonProperty("source_records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<string> SourceRecords { get; set; } = new();

		public KeyType? Type { get; set; }

		[Newtonsoft.Json.JsonProperty("remote_ids", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public RemoteIds? RemoteIds { get; set; }

		public string? Bio { get; set; }

		[Newtonsoft.Json.JsonProperty("latest_revision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? LatestRevision { get; set; }

		public int? Revisions { get; set; }

		public Timestamp? Created { get; set; }

		[Newtonsoft.Json.JsonProperty("last_modified", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Timestamp? LastModified { get; set; }
	}

	public class KeyType
	{
		public string? Key { get; set; }
	}

	public class RemoteIds
	{
		public string? Wikidata { get; set; }
		public string? Viaf { get; set; }
		public string? Isni { get; set; }
	}

	public class Timestamp
	{
		public string? Type { get; set; }
		public string? Value { get; set; }
	}

}