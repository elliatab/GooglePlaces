using System;
using System.Threading.Tasks;
using System.Net.Http;
using ModernHttpClient;
using Newtonsoft.Json;

namespace GooglePlaces.Details
{
	public class PlaceDetailsRequest
	{
		private readonly string requestUri;
		private PlaceDetailsRequest (string requestUri)
		{
			this.requestUri = requestUri;
		}


		/// <summary>
		/// Build the request with a specified key and input.
		/// </summary>
		/// <param name="key">Your application's API key. This key identifies your application for purposes of quota management. Visit the Google Developers Console to select an API Project and obtain your key. Google Maps API for Work customers must use the API project created for them as part of their Google Places API for Work purchase.</param>
		/// <param name="placeid">A textual identifier that uniquely identifies a place, returned from a Place Search. For more information about place IDs, see the place ID overview.</param>
		/// <param name="language">The language in which to return results. For example: en, ja</param>
		public static PlaceDetailsRequest Build(
			string key, 
			string placeid, 
			string language = "en") {

			string query = string.Format (
				"https://maps.googleapis.com/maps/api/place/details/json?key={0}&placeid={1}&language={2}",
				key,
				placeid,
				language);

			return new PlaceDetailsRequest (query);
		}

		public async Task<PlaceDetail> GetPredictionsAsync(){
			using (var httpClient = new HttpClient (new NativeMessageHandler ())) {
				var reponseString = await httpClient.GetStringAsync (this.requestUri);

				var placeDetailResponse = JsonConvert.DeserializeObject<PlaceDetailsResponse> (reponseString);

				// TODO: error handling, status checking...

				return placeDetailResponse.Result;
			}
		}
	}
}

