using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GooglePlaces.Autocomplete
{
	//Documentation https://developers.google.com/places/webservice/autocomplete
	[DataContract]
	public class Prediction
	{
		[DataMember(Name="description")]
		public string Description { get; set; }

		[DataMember(Name="matched_substrings")]
		public List<MatchedSubstring> MatchedSubstrings { get; set; }

		[DataMember(Name="place_id")]
		public string PlaceId { get; set; }

		[DataMember(Name="terms")]
		public List<Term> Terms { get; set; }

		[DataMember(Name="types")]
		public List<string> Types { get; set; }
	}
}

