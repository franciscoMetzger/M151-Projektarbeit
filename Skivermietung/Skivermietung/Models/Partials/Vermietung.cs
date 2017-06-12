using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Skivermietung.Models.Metadata;

// ReSharper disable once CheckNamespace
namespace Skivermietung.Models
{
	[MetadataType(typeof(VermietungMetadata))]
	public partial class Vermietung
	{
		public IEnumerable<int> Artikel { get; set; }
	}
}