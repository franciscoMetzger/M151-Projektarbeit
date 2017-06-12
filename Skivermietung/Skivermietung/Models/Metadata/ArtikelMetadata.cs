using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class ArtikelMetadata
	{
		[StringLength(200)]
		[MinLength(5)]
		[Required]
		public string Bezeichnung { get; set; }

		[StringLength(200)]
		public string Farbe { get; set; }

		[StringLength(200)]
		public string Marke { get; set; }

		[Display(Name = "Preis/Tag")]
		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
		public decimal PreisProTag { get; set; }

		[Required]
		public int KategorieId { get; set; }
	}
}