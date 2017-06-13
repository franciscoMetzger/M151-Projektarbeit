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

		public void AddArtikel(Artikel artikel)
		{
			ArtikelVermietung.Add(new ArtikelVermietung
			{
				ArtikelId = artikel.ID_Artikel,
				VermietungsId = this.ID_Vermietung
			});
		}

		public void AddArtikel(int idArtikel)
		{
			ArtikelVermietung.Add(new ArtikelVermietung
			{
				ArtikelId = idArtikel,
				VermietungsId = this.ID_Vermietung
			});
		}
	}
}