using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class ArtikelVermietungMetadata
	{
		[Required]
		[Display(Name = "Artikel")]
		public int ArtikelId { get; set; }

		[Required]
		[Display(Name = "Vermietungs-ID")]
		public int VermietungsId { get; set; }
	}
}