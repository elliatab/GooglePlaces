using System;
using System.Threading.Tasks;

namespace Sample
{
	class Program
	{
		public static void Main (string[] args)
		{
			new Program().Run().Wait();
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		private async Task Run()
		{
			Console.WriteLine ("Insert your Google APIs Key: ");
			var key = Console.ReadLine ();
			Console.WriteLine ("Google APIs Key {0} will be used.", key);

			Console.Write ("Keyword(s)? ");
			var input = Console.ReadLine ();
			Console.WriteLine ("Searching for Input \"{0}\" .", input);

			var request = GooglePlaces.Autocomplete.AutocompleteRequest.Build (key, input);

			var predictions = await request.GetPredictionsAsync ();

			foreach (var prediction in predictions) {
				Console.WriteLine ("{0} {1}",predictions.IndexOf(prediction),  prediction.Description);
			}

			Console.WriteLine ("Input index to show Place Details:");
			int index;
			if (int.TryParse(Console.ReadLine(), out index)) {
				var placeDetails = await GooglePlaces.Details.PlaceDetailsRequest.Build (key, predictions [index].PlaceId).GetPredictionsAsync ();
				Console.Write ("{0} place id is {1}, types are ", placeDetails.Name, placeDetails.PlaceId);
				foreach (var type in placeDetails.Types) {
					Console.Write ("{0} |", type);
				}
			} 			
		}
	}
}
