using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class KategorieMetadata
	{
		[StringLength(200)]
		[MinLength(3)]
		[Display(Name = "Kategorie")]
		[Required]
		public string Bezeichnung { get; set; }
	}
}