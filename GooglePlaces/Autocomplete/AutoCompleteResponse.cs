using System;
using System.Collections.Generic;

namespace GooglePlaces.Autocomplete
{
	//Documentation https://developers.google.com/places/webservice/autocomplete
	public class AutocompleteResponse
	{
		public List<Prediction> Predictions { get; set; }
		public string Status { get; set; }
	}
}

