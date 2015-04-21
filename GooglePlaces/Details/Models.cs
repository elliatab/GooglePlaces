using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

// Documentation https://developers.google.com/places/webservice/details
namespace GooglePlaces.Details
{
	[DataContract]
	public class AddressComponent
	{

		[DataMember(Name="long_name")]
		public string LongName { get; set; }

		[DataMember(Name="short_name")]
		public string ShortName { get; set; }

		[DataMember(Name="types")]
		public IList<string> Types { get; set; }
	}

	[DataContract]
	public class Location
	{

		[DataMember(Name="lat")]
		public double Lat { get; set; }

		[DataMember(Name="lng")]
		public double Lng { get; set; }
	}

	[DataContract]
	public class Viewport
	{

		[DataMember(Name="northeast")]
		public Location Northeast { get; set; }

		[DataMember(Name="southwest")]
		public Location Southwest { get; set; }
	}

	[DataContract]
	public class Geometry
	{
		[DataMember(Name="location")]
		public Location Location { get; set; }

		[DataMember(Name="viewport")]
		public Viewport Viewport { get; set; }
	}

	[DataContract]
	public class Photo
	{

		[DataMember(Name="height")]
		public int Height { get; set; }

		[DataMember(Name="html_attributions")]
		public IList<string> HtmlAttributions { get; set; }

		[DataMember(Name="photo_reference")]
		public string PhotoReference { get; set; }

		[DataMember(Name="width")]
		public int Width { get; set; }
	}

	[DataContract]
	public class PlaceDetail
	{
		[DataMember(Name="address_components")]
		public IList<AddressComponent> AddressComponents { get; set; }

		[DataMember(Name="adr_address")]
		public string AdrAddress { get; set; }

		[DataMember(Name="formatted_address")]
		public string FormattedAddress { get; set; }

		[DataMember(Name="geometry")]
		public Geometry Geometry { get; set; }

		[DataMember(Name="icon")]
		public string Icon { get; set; }

		[DataMember(Name="photos")]
		public IList<Photo> Photos { get; set;}

		[DataMember(Name="name")]
		public string Name { get; set; }

		[DataMember(Name="place_id")]
		public string PlaceId { get; set; }

		[DataMember(Name="rating")]
		public float Rating { get; set; }

		[DataMember(Name="scope")]
		public string Scope { get; set; }

		[DataMember(Name="types")]
		public IList<string> Types { get; set; }

		[DataMember(Name="url")]
		public string Url { get; set; }

		[DataMember(Name="vicinity")]
		public string Vicinity { get; set; }
	}

	[DataContract]
	public class PlaceDetailsResponse {
		[DataMember(Name="result")]
		public PlaceDetail Result { get; set; }

		[DataMember(Name="status")]
		public string Status { get; set; }
	}
}