using System;
using System.Collections.Generic;
using System.Net.Http;
using ModernHttpClient;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GooglePlaces.Autocomplete
{
	public class AutocompleteRequest
	{
		private readonly string requestUri;
		private AutocompleteRequest (string requestUri)
		{
			this.requestUri = requestUri;
		}

	
		/// <summary>
		/// Build the specified key, input and language.
		/// </summary>
		/// <param name="key">Your application's API key. This key identifies your application for purposes of quota management. Visit the Google Developers Console to select an API Project and obtain your key. Google Maps API for Work customers must use the API project created for them as part of their Google Places API for Work purchase.</param>
		/// <param name="input">The text string on which to search. The Place Autocomplete service will return candidate matches based on this string and order results based on their perceived relevance.</param>
		/// <param name="language">The language in which to return results. For example: en, ja</param>
		/// <param name="types">The types of place results to return. If no type is specified, all types will be returned.</param>
		/// <param name="components">A grouping of places to which you would like to restrict your results. For example: components=country:jp would restrict your results to places within Japan.</param>
		public static AutocompleteRequest Build(
			string key, 
			string input, 
			string language = "en", 
			string types = "",
			string components = "") {


			string query = string.Format (
				               "https://maps.googleapis.com/maps/api/place/autocomplete/json?key={0}&input={1}&language={2}&types={3}&components={4}",
				               key,
				               input,
				               language,
				               types,
				               components);
			
			return new AutocompleteRequest (query);
		}

		public async Task<List<Prediction>> GetPredictionsAsync(){
			using (var httpClient = new HttpClient (new NativeMessageHandler ())) {
				var reponseString = await httpClient.GetStringAsync (this.requestUri);

				var autoCompleteResponse = JsonConvert.DeserializeObject<AutocompleteResponse> (reponseString);

				// TODO: error handling, status checking...

				return autoCompleteResponse.Predictions;
			}
		}
	}
}

