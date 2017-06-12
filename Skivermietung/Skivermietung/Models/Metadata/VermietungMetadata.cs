using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class VermietungMetadata
	{
		[Required]
		[Display(Name = "Vermietungsstart")]
		public DateTime Von { get; set; }

		[Required]
		[Display(Name = "Vermietungsende")]
		public DateTime Bis { get; set; }

		[Display(Name = "Bezahlt am")]
		public DateTime? Bezahlt { get; set; }

		public int? Rabatt { get; set; }

		[Required]
		[Display(Name = "Kunde")]
		public int KundeId { get; set; }
	}
}