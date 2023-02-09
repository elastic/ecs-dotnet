using System;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Elastic.CommonSchema.Tests.Specs
{
	public static class Spec
	{
		static Spec()
		{
			using var stream = typeof(Spec).Assembly
				.GetManifestResourceStream($"Elastic.CommonSchema.Tests.Specs.spec.json");

			using var memoryStream = new MemoryStream();
			// ReSharper disable once PossibleNullReferenceException
			stream.CopyTo(memoryStream);
			var json = Encoding.UTF8.GetString(memoryStream.ToArray());
			JObject = JObject.Parse(json);
		}

		private static JObject JObject { get; }

		/// <summary>
		/// Validates a log event against the spec
		/// </summary>
		/// <param name="logEvent"></param>
		public static void Validate(string logEvent)
		{
			var log = JObject.Parse(logEvent);
			var specFields = ((JObject)JObject["fields"])?.Properties();

			foreach (var specField in specFields!)
			{
				var property = GetProperty(specField, log);
				var specFieldValue = (JObject)specField.Value;
				ValidateRequiredField(property, specField);
				if (property != null)
				{
					ValidateIndex(property, log, specFieldValue);
					try { ValidateType(property, specFieldValue);}
					catch (Exception e)
					{
						throw new Exception(logEvent, e);
					}
				}
			}
		}

		/// <summary>
		/// Validates that if the field has an "index" in the spec, that the property
		/// appears at this index in the log
		/// </summary>
		private static void ValidateIndex(JProperty property, JObject log, JObject specFieldValue)
		{
			if (specFieldValue.ContainsKey("index"))
				log.Properties().ElementAt(specFieldValue.Value<int>("index")).Should().BeSameAs(property);
		}

		/// <summary>
		/// Validates that the property value matches the type expected according to the spec.
		/// </summary>
		private static void ValidateType(JProperty property, JObject specFieldValue)
		{
			if (specFieldValue.ContainsKey("type"))
			{
				var type = specFieldValue.Value<string>("type");
				switch (type)
				{
					case "datetime":
						property.Value.Type.Should().Be(JTokenType.Date);
						break;
					case "string":
						property.Value.Type.Should().Be(JTokenType.String);
						break;
					case "object" when property.Path == "labels":
						property.Value.Type.Should().Be(JTokenType.Object);
						var labels = (JObject)property.Value;
						foreach (var prop in labels.Properties())
							prop.Value.Type.Should().Be(JTokenType.String, $"label {prop.Name} holds {prop.Value.Type} but may only hold string");
						break;
					default:
						Assert.True(false, $"Cannot yet assert on {type}. Add assertion for this type: {property.Path}");
						break;
				}
			}
		}

		/// <summary>
		/// Gets the property from the JSON log object, taking into account dotted notation.
		/// </summary>
		private static JProperty GetProperty(JProperty specField, JObject log)
		{
			var specFieldValue = (JObject)specField.Value;
			if (specFieldValue.ContainsKey("top_level_field") && specFieldValue.Value<bool>("top_level_field"))
				return log.Property(specField.Name);

			var parts = specField.Name.Split(".", StringSplitOptions.RemoveEmptyEntries);
			JToken obj = log;
			foreach (var part in parts)
			{
				var property = obj?.Children<JProperty>().SingleOrDefault(c => c.Name == part);
				if (property is null)
					return null;

				obj = property.Value;
			}

			return (JProperty)obj.Parent;
		}

		private static void ValidateRequiredField(JProperty property, JProperty specField)
		{
			var specFieldValues = specField.Value as JObject;
			if (specFieldValues!.ContainsKey("required") && specFieldValues.Value<bool>("required"))
			{
				property.Should().NotBeNull($"{specField.Name} is required");
				property?.Value.Should().NotBeNull($"{specField.Name} is not null");
				property?.Value.Type.Should().NotBe(JTokenType.Null, $"{specField.Name} is not a null token");
			}
		}
	}
}
