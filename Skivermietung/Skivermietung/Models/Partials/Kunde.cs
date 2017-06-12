using System;
using System.ComponentModel.DataAnnotations;
using Skivermietung.Models.Metadata;

// ReSharper disable once CheckNamespace
namespace Skivermietung.Models
{
	[MetadataType(typeof(KundeMetadata))]
	public partial class Kunde
	{
		public string NameKomplett
		{
			get { return String.Format("{0} {1}", Vorname, Name); }
		}

	}
}