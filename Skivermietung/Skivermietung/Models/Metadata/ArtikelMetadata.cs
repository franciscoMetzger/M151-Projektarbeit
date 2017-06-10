using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class ArtikelMetadata
	{
		[Display(Name = "Preis/Tag")]
		public decimal PreisProTag;
	}
}