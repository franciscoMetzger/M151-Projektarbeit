using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class ArtikelVermietungMetadata
	{
		[Required]
		public int ArtikelId { get; set; }

		[Required]
		public int VermietungsId { get; set; }
	}
}