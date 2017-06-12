using System.ComponentModel.DataAnnotations;

namespace Skivermietung.Models.Metadata
{
	public class BenutzerMetadata
	{
		[Required]
		[StringLength(50)]
		[MinLength(4)]
		public string Benutzername { get; set; }

		[Required]
		[Display(Name = "Administratorrechte")]
		public bool IsAdmin { get; set; }

		[Required]
		[StringLength(29)]
		public string PasswordHash { get; set; }

		[Required]
		[StringLength(60)]
		public string PasswordSalt { get; set; }
	}
}