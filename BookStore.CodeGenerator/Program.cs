using NSwag;
using NSwag.CodeGeneration.CSharp;

Console.WriteLine("Generate CSharp code:");
Console.WriteLine("1: OpenLibrary Client");
Console.WriteLine("2: OpenLibrary Response Classes");
Console.WriteLine("0: Exit");

var readInput = true;
while (readInput)
{
	var input = Console.ReadKey();
	switch (input.Key)
	{
		case ConsoleKey.D1:
		case ConsoleKey.NumPad1:
			await GenerateOpenLibraryClientAsync();
			break;
		case ConsoleKey.D2:
		case ConsoleKey.NumPad2:
			await GenerateOpenLibraryResponseClasses();
			break;
		case ConsoleKey.D0:
		case ConsoleKey.Spacebar:
			readInput = false;
			break;
		default:
			break;
	}
}

public static partial class Program
{

	private static async Task GenerateOpenLibraryClientAsync()
	{
		Console.WriteLine(Environment.NewLine);
		Console.WriteLine("Generating OpenLibrary Client");

		var url = "https://raw.githubusercontent.com/internetarchive/openlibrary/master/static/openapi.json";
		var destinationPath = Path.Combine("..", "..", "..", "..", @"BookStore.Connectors.OpenLibrary", "Client", "OpenLibraryClient.cs");
		HttpClient client = new();
		client.DefaultRequestHeaders.Add("User-Agent", "Code-Generator");
		var response = await client.GetStringAsync(url);
		var document = await OpenApiDocument.FromJsonAsync(response);

		client.Dispose();

		var settings = new CSharpClientGeneratorSettings
		{
			ClassName = "OpenLibraryClient",
			GenerateClientInterfaces = true,
			GenerateBaseUrlProperty = true,
			OperationNameGenerator = new NSwag.CodeGeneration.OperationNameGenerators.SingleClientFromPathSegmentsOperationNameGenerator(),
			UseBaseUrl = false,
			
			CodeGeneratorSettings =
				{
				},
			CSharpGeneratorSettings =
				{
					Namespace = "BookStore.Connectors.OpenLibrary.Client",
					PropertyNameGenerator = new BookStore.CodeGenerator.CustomGenerators.CustomPropertyNameGenerator(),
					TypeNameGenerator = new BookStore.CodeGenerator.CustomGenerators.CustomTypeNameGenerator(),
					ArrayType = "System.Collections.Generic.IEnumerable",

				},
			ExcludedParameterNames = ["correlation-id", "traceparent", "X-Request-Source", "X-Ignore-Cache"]
		};

		var generator = new CSharpClientGenerator(document, settings);
		var code = generator.GenerateFile();
		File.WriteAllText(destinationPath, code, System.Text.Encoding.UTF8);
		Console.WriteLine("Complete.");
		Console.WriteLine(Environment.NewLine);
		Console.Write(">");
	}

	private static async Task GenerateOpenLibraryResponseClasses()
	{
		Console.WriteLine(Environment.NewLine);
		Console.WriteLine($"Generating OpenLibrary Response classes...");

		var sourcePath = Path.Combine("..", "..", "..", "..", @"BookStore.Application", "Authors", "Spec", "AuthorsSpec.yaml");
		var destinationPath = Path.Combine("..", "..", "..", "..", @"BookStore.Application", "DTOs", "AuthorModels.cs");

		var document = await OpenApiYamlDocument.FromFileAsync(sourcePath);

		var settings = new CSharpControllerGeneratorSettings
		{
			ClassName = "Models",
			GenerateClientInterfaces = false,
			GenerateClientClasses = false,
			CodeGeneratorSettings =
				{
				},
			CSharpGeneratorSettings =
				{
					Namespace = $"BookStore.Application.DTOs.AuthorModels",
					PropertyNameGenerator = new BookStore.CodeGenerator.CustomGenerators.CustomPropertyNameGenerator(),
					TypeNameGenerator = new BookStore.CodeGenerator.CustomGenerators.CustomTypeNameGenerator(),
					EnumNameGenerator = new BookStore.CodeGenerator.CustomGenerators.CustomEnumNameGenerator(),
					DateType = "System.DateTime",
					DateTimeType = "System.DateTime"
				}
		};

		var generator = new CSharpControllerGenerator(document, settings);

		var code = generator.GenerateFile();
		File.WriteAllText(destinationPath, code, System.Text.Encoding.UTF8);

		Console.WriteLine("Complete.");
		Console.WriteLine(Environment.NewLine);
		Console.Write(">");
	}
}