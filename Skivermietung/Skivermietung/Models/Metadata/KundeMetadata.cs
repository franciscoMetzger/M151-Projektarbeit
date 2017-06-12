using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class KundeMetadata
	{
		[Required]
		[StringLength(200)]
		public string Vorname { get; set; }

		[StringLength(200)]
		[Required]
		public string Name { get; set; }

		[Phone]
		[Display(Name = "Telefon Nr.")]
		public string TelefonNr { get; set; }

		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime Geburtstag { get; set; }
	}
}