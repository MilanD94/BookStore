using NJsonSchema;
using NJsonSchema.CodeGeneration;
using NSwag;
using NSwag.CodeGeneration;

namespace BookStore.CodeGenerator.CustomGenerators
{

	internal class CustomPropertyNameGenerator : IPropertyNameGenerator
	{
		public string Generate(JsonSchemaProperty property)
		{
			return property.Name.ToPascalCase();
		}
	}

	internal class CustomTypeNameGenerator : ITypeNameGenerator
	{
		public string Generate(JsonSchema schema, string? typeNameHint, IEnumerable<string> reservedTypeNames)
		{
			return typeNameHint/*.ToPascalCase();*/ ?? string.Empty;
		}
	}
	internal class CustomEnumNameGenerator : IEnumNameGenerator
	{
		public string Generate(int index, string? name, object? value, JsonSchema schema)
		{
			if (name is not null)
			{
				return name.ToPascalCase();
			}

			return string.Empty;
		}
	}
	internal class CustomParameterNameGenerator : IParameterNameGenerator
	{
		public string Generate(OpenApiParameter parameter, IEnumerable<OpenApiParameter> allParameters)
		{
			return parameter.Name.ToCamelCase();
		}
	}

	internal static class Converters
	{
		public static string ToCamelCase(this string word)
		{
			return string.Join("", word.Split(new char[] { '_', '-', '.' })
						 .Select(w => w.Trim())
						 .Where(w => w.Length > 0)
						 .Select((w, index) => (index == 0 ? w.Substring(0, 1).ToLower() : w.Substring(0, 1).ToUpper()) + w.Substring(1)));
		}
		public static string ToPascalCase(this string word)
		{
			return string.Join("", word.Split(new char[] { '_', '-', '.' })
						 .Select(w => w.Trim())
						 .Where(w => w.Length > 0)
						 .Select(w => w.Substring(0, 1).ToUpper() + w.Substring(1).ToLower()));
		}
	}
}
