using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class VermietungMetadata
	{
		[Required]
		[Display(Name = "Vermietungsstart")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		[DataType(DataType.Date)]
		public DateTime Von { get; set; }

		[Required]
		[Display(Name = "Vermietungsende")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		[DataType(DataType.Date)]
		public DateTime Bis { get; set; }

		[Display(Name = "Bezahlt am")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime? Bezahlt { get; set; }

		[Display(Name = "Rabatt in %")]
		public int? Rabatt { get; set; }

		[Required]
		[Display(Name = "Kunde")]
		public int KundeId { get; set; }
	}
}